using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centrala
{
     abstract class Distribution
    {
         protected double lambda;
         protected string name;

       public double Gettime(double time)
        {
            return (-(1 / lambda) * Math.Log(1-time));// rozkład wykładniczy

        }
       public string Getname() { return (name); }
    }
}
