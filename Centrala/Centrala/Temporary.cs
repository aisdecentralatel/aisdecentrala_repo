using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centrala
{
    class Temporary:Distribution
    {
        public double[] czas;
        public Temporary(int clambda)
        {
           lambda = clambda;
           name = "long";
           
           for (int i = 0; i < 10; i++)
           {
             //  Console.Beep();
               Random x = new Random(DateTime.Now.Millisecond);

               double y = x.NextDouble();
               double z = x.NextDouble();
               double q = x.NextDouble();
               Application ko = new Application(Gettime(y), Gettime(z), Gettime(q), 3);
               czas[i] = ko.Returnappcome();
               Console.WriteLine("{0}", czas[i]);
             //  Console.Write("{0} ", ko.Returnappcome());
              // Console.Write("{0} ", ko.Returnappduration());
              // Console.WriteLine("{0} ", ko.Returnapppatience());

           }
        }
    }
}
