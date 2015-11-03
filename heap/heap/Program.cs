using System;
using System.Diagnostics;

namespace heap
{
    class Program
    {
        static void Main(string[] args)
        {
            int A = 0;
            

            Console.Write("Podaj ilosc liczb A: ");         
            A = int.Parse(Console.ReadLine());
            Console.Write("Podaj max wartosc M: ");
            int M = int.Parse(Console.ReadLine());
            Heap heap = new Heap(A);
            TList list = new TList();

            Console.Write("Podaj ilosc liczb B: ");
            int B = int.Parse(Console.ReadLine());
            Console.Write("Podaj max wartosc N: ");
            int N = int.Parse(Console.ReadLine());

            Random r = new Random(DateTime.Now.Millisecond);
            Console.WriteLine("Kopiec :)");
            var time = Stopwatch.StartNew();
            for(var i=A;i>0;i--)
            {
                heap.Push(r.Next(0,M));
            }
            for(var i= B;i>0;i--)
            {
                heap.DeleteMax();
                heap.Push(r.Next(0, N));
            }
            time.Stop();
            var timeMs = time.ElapsedMilliseconds;
            Console.WriteLine("Uplynelo {0} ms", timeMs);
            Console.ReadLine();

            Console.WriteLine("Lista :(");
            time = Stopwatch.StartNew();
            for (var i = A; i > 0; i--)
            {
                list.Push(r.Next(0, M));
            }
            for (var i = B; i > 0; i--)
            {
                list.DeleteAt(list.MinIndex());
                heap.Push(r.Next(0, N));
            }
            time.Stop();
            timeMs = time.ElapsedMilliseconds;
            Console.WriteLine("Uplynelo {0} ms", timeMs);
            Console.ReadLine();
        }
    }
}
