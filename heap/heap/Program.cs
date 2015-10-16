using System;

namespace heapsort
{
    class Program
    {
        static void Main(string[] args)
        {
            long n = 0;
            Console.Write("Podaj ilosc liczb: ");
            n = int.Parse(Console.ReadLine());
            int[] tab = new int[n];
            Random r = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < n; i++)
            {

                tab[i] = r.Next(0, 1000);


                //                Console.Write("{0} ", tab[i]);
            }
            Console.WriteLine("\nTworzenie kopca :)");
            Console.WriteLine("stworzyłem");
            tab = Heap.CreateFromArray(tab);

            for (int i = 0; i < n; i++)
            {
                Console.Write("{0} ", tab[i]);
            }
            Console.ReadLine();
        }
    }
}
