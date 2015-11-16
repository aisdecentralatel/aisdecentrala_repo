using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Globalization;

namespace Centrala
{

    
    class Temporary : Distribution
    {
        string input;
        string[] wyrazy;
        string linia;
     StreamReader sr;

        string system;
        int channel;
        int queue;
        int distribution;
        string name;
        double lambda;

   

        public void lol()
        {

            linia = " ";
            while (linia.Length < 2 || linia[0] == '#')
            {
                linia = sr.ReadLine();
            }
            wyrazy = linia.Split(' ');

            if (wyrazy[0] == "SYSTEM")
                system = wyrazy[2];
            if (wyrazy[0] == "KANALY")
                channel = int.Parse(wyrazy[2]);
            if (wyrazy[0] == "KOLEJKA")
                queue = int.Parse(wyrazy[2]);
            if (wyrazy[0] == "ROZKLADY")
                distribution = int.Parse(wyrazy[2]);
            if (wyrazy[0] == "NAZWA")
                name = wyrazy[2];
            if (wyrazy[0] == "LAMBDA")
                lambda = double.Parse(wyrazy[2]);
            }

        public Temporary()
        {

            bool read = false;
            while (!read)
            {   
                read= true;
                
                input = Console.ReadLine();
                sr = new StreamReader(input);

                while (!sr.EndOfStream)
                lol();
                Console.WriteLine("{0},{1},{2},{3},{4},{5}", system, channel, queue, distribution, name, lambda);
               
            }
        }
    }
}
