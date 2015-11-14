using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centrala
{
    class Queue
    {
        Application[] queue;
        int size;

        public Queue(int fullsize)//konstruktor
        {
            size = 0;
            queue = new Application[fullsize];
        }
        public void Sortapplication(int r)//przesuwanie wszystkich elementów za tym na wczesniejszy
        {
            for (int i = r; i < size-1; i++)
                queue[i] = queue[i + 1];

        }
        public void Addapplication(Application r)//dodawanie na koncu
        {
                size++;
                queue[size - 1] = r;
        }
        public void Deleteapplication(int r)//kasowanie wybranego poprzez sortap a potem kasowanie ostatniego
        {
            Sortapplication(r);
            size--;
        }
        public Application Gettochannel()
        {
            Application r = queue[0];
            Sortapplication(0);
            size--;
            return r;
            
        }
    }
}
