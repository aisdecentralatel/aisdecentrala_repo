using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centrala
{
    class Simulation
    {
        Stream[] streams;

        double avg_occupacy_queue;
        Queue<Signal> queue;



        int numberOf_signals_inService;

        int used_channels;
        int numberOf_channels;
        double avg_occupancy_channels;
        double stats_time;

        heap.Heap<double, Event> events;
        public Simulation()
        {
            // tymczasowe dane
            queue = new Queue<Signal>(4);
            numberOf_channels = 10;
            streams = new Stream[2];
            streams[0] = new Stream("Str1", 0.0001, 0.0001, 1000, 2);
            streams[1] = new Stream("Str2", 0.0001, 0.0001, 1000, 3);
            numberOf_signals_inService = 0;
            used_channels = 0;
            avg_occupacy_queue = avg_occupancy_channels = 0;
            events = new heap.Heap<double, Event>();
        }
        public void Simulate()
        {
            

            double time_of_end = 0;
            double act_time = 0;
            double previous_time = 0;
            Random random = new Random(DateTime.Now.Millisecond);
            while (time_of_end == 0)
            {
                try
                {
                    Console.Write("Podaj czas symulacji(s): ");
                    time_of_end = double.Parse(Console.ReadLine())*1000;
                }
                catch (Exception)
                {
                    Console.WriteLine("Bledny czas symulacji! Sproboj ponownie.");
                }
                for(int i=0;i<streams.Length;i++)
                {
                    var time = Distribution.Gettime(streams[i].PauseLambda(), random.NextDouble());
                    events.Push(time, Event.InEvent(i));
                    streams[i].AddSignal();
                }
            }
            while (act_time < time_of_end)
            {
                if (stats_time == 0)
                    stats_time = act_time;
                else
                    stats_time = act_time - previous_time;

                avg_occupacy_queue += queue.Size() * stats_time;
                avg_occupancy_channels = used_channels * stats_time;
                // wyrzucanie sygnalow zgloszen ktore przekroczyly czas czekania w kolejce
                for (var i = 0; i < queue.Size(); i++)
                {
                    if (act_time < (queue[i].waitingTime() + queue[i].comingTime()))
                    {
                        queue.DeleteAt(i);
                        streams[queue[i].streamNumber()].RejectSignal();
                    }
                }
                
                var evnt = events.DeleteMin();
                previous_time = act_time;
                act_time = evnt.GetKey();
                var streamNo = evnt.GetData().streamNumber();
                switch (evnt.GetData().Type())
                {
                    case eventType.In:
                        {
                            if (queue.Size()==0 && queue.MaxSize()>0)
                            {
                                if(streams[streamNo].UsingChannels() <= numberOf_channels - used_channels)
                                {
                                    numberOf_signals_inService++;
                                    used_channels += streams[streamNo].UsingChannels();
                                    events.Push(act_time + Distribution.Gettime(streams[streamNo].LengthLambda(), random.NextDouble()), Event.OutEvent(streamNo));
                                }
                                else
                                {
                                    var duration_time = Distribution.Gettime(streams[streamNo].LengthLambda(), random.NextDouble());
                                    queue.Add(new Signal(act_time, streams[streamNo].MaxWaitingTime(), duration_time, streamNo));
                                }
                            }
                            else if(queue.Size() != queue.MaxSize())
                            {
                                var duration_time = Distribution.Gettime(streams[streamNo].LengthLambda(),random.NextDouble());
                                queue.Add(new Signal(act_time, streams[streamNo].MaxWaitingTime(), duration_time, streamNo));
                            }
                            else
                            {
                                streams[streamNo].RejectSignal();
                            }
                            events.Push(act_time + Distribution.Gettime(streams[streamNo].PauseLambda(), random.NextDouble()),Event.InEvent(streamNo));
                                break;
                        }
                    case eventType.Out:
                        {
                            numberOf_signals_inService--;
                            used_channels -= streams[streamNo].UsingChannels();
                            while(queue.Size() > 0 && streams[queue[0].streamNumber()].UsingChannels() <= numberOf_channels - used_channels)
                            {
                                
                                var outEvent = Event.OutEvent(streamNo);
                                var outSignal = queue.Out();
                                streamNo = outSignal.streamNumber();
                                var time = outSignal.durationTime() + act_time;
                                events.Push(time, outEvent);
                                used_channels += streams[streamNo].UsingChannels();
                                numberOf_signals_inService++;
                            }
                            break;
                        }
                        
                }
            }
            // stats - na razie na ekran
            for (int i = 0; i < streams.Length; i++)
            {
                var probability_of_rejecting = (streams[i].NoOfRejectedSignals() / streams[i].NoOfAddedSignals()) * 100;
                Console.WriteLine("Strumien {0}: {1}%", i, probability_of_rejecting);
            }
            avg_occupacy_queue = avg_occupacy_queue / (queue.MaxSize() * time_of_end);
            avg_occupancy_channels = avg_occupancy_channels / (numberOf_channels * time_of_end);
            Console.WriteLine("Kolejka zajetosc: {0}%", avg_occupacy_queue);
            Console.WriteLine("Kanaly zajetosc: {0}%", avg_occupancy_channels);
            Console.ReadLine();
        }
    }
}
