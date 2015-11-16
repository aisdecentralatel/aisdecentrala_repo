using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centrala
{
    class Temporary:Distribution
    {

        public Temporary()
        {
            for (int i=0; i < 30; i++)
            {

                Console.Beep();
                Random x = new Random();
                double z = x.NextDouble();
                double y=Gettime(2,z);
                Console.WriteLine("{0}", Math.Round(y*10,2));
            }
        }
    }
}
