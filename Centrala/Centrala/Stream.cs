using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centrala
{
    class Stream
    {
        // dane strumienia
        string name;
        int lambda;
        int max_duration;
        int pause_time;
        int stream_number;
        
        public Stream(string cName, int cLamba, int cMax_duration, int cPause_time, int cStream_number)
        {
            name = cName;
            lambda = cLamba;
            max_duration = cMax_duration;
            pause_time = cPause_time;
            stream_number = cStream_number;
        }
        public Application NewApp()
        {
            Application app = new Application(Program.time, max_duration, 0, stream_number);
            return app;
        }
        public int PauseTime()
        {
            return pause_time;
        }
        public void ChangePauseTime(int pause)
        {
            pause_time = pause;
        }

    }
}