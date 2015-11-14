using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centrala
{
     abstract class Distribution
    {
  


       public double Gettime(double lambda, double time)
        {
            return (-(1 / lambda) * Math.Log(1-time));// rozkład wykładniczy

        }

    }
}
