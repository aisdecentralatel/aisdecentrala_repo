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
        int length_lambda;
        int pause_lamba;
        int max_duration;
        int stream_number;
        
        public Stream(string cName, int cLength_Lamba, int cPause_lambda, int cMax_duration,  int cStream_number)
        {
            name = cName;
            length_lambda = cLength_Lamba;
            pause_lamba = cPause_lambda;
            max_duration = cMax_duration;
            stream_number = cStream_number;
        }
        public Application NewApp()
        {
            Application app = new Application(Program.time, max_duration, 0, stream_number);
            return app;
        }

    }
}