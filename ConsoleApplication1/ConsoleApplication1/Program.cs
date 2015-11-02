using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

abstract class Random_Variables
{

    static public double losuj(double alfa)
    {
        Console.Beep();
        System.Random x = new Random();
        double y = x.NextDouble();
       // return (-(1 / alfa) * Math.Log(1 - y));
        return (-(1 / alfa) * Math.Log(y));
    }
}
namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 20; i++)

                Console.WriteLine(Random_Variables.losuj(10));
        }
    }
}
