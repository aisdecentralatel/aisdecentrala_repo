using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centrala
{
     abstract class Distribution
    {
  


       public double Gettime(double lambda, double y)
        {
            return ((-1 / lambda) * Math.Log(1-y));// rozkład wykładniczy

        }

    }
}
