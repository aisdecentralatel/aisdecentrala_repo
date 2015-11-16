using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centrala
{
    class Signal
    {
        private double coming_time; //czas przyjscia
        private double waiting_time; //czas jaki moze przebywac zgloszenie w kolejce
        private double duration_time; //czas realizacji zgloszenia
        private int streamNo;
       
        public Signal(double coming_time, double waiting_time, double duration_time, int streamNo)
        {
            this.coming_time = coming_time;
            this.waiting_time = waiting_time;
            this.duration_time = duration_time;
            this.streamNo = streamNo;
        }
        public double comingTime()
        {
            return coming_time;
        }
        public double waitingTime()
        {
            return waiting_time;
        }
        public double durationTime()
        {
            return duration_time;
        }
        public int streamNumber()
        {
            return streamNo;
        }
    }
}
