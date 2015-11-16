using System;


namespace heap
{
    class Heap<K, D> : QInterface<K, D> where K : IComparable
    {
        // elementy stogu
        Element<K, D>[] elements;
        int size = 0;
        // konstruktor stogu
        public Heap()
        {
            Init(); // tworzy tablice elementów (jak size==0 to 1-elementowa
        }
        public Heap(int size)
        {
            elements = new Element<K, D>[size];
        }
        public void Init()
        {
            elements = new Element<K, D>[size + 1];
        }
        public void Push(K key, D data)
        {
            size++;
            // rozszerzanie miejsca w tablicy
            if (size > elements.Length)
            {
                Element<K, D>[] new_elements = new Element<K, D>[elements.Length * 2]; // podwajanie miejsca w tablicy jeśli brakuje

                elements.CopyTo(new_elements, 0);
                elements = new_elements;
            }

            elements[size - 1] = new Element<K, D>(key, data);
            var index = size - 1;
            while (elements[index] < elements[index / 2] && index >= 1)
            {
                var tmp = elements[index / 2];
                elements[index / 2] = elements[index];
                elements[index] = tmp;
                index /= 2;
            }
        }
        public Element<K, D> DeleteMin()
        // metoda usuwający najmniejszy element ze stogu
        {
            size--;
            var min = elements[0];
            var last = elements[size];
            elements[size] = null;
            //var index = 0;
            elements[0] = last; // przenoszenie ostatniego elementu do korzenia
            /*
            // odbudowywanie struktury stogu
            while (last > elements[(2 * index) + 1] || last > elements[(index + 1) * 2])
            {
                if (elements[(2 * index) + 1] < elements[(index + 1) * 2])
                {
                    var tmp = elements[(2 * index) + 1];
                    elements[(2 * index) + 1] = last;
                    elements[index] = tmp;
                    index = (2 * index) + 1;
                }
                else
                {
                    var tmp = elements[(index + 1) * 2];
                    elements[(index + 1) * 2] = last;
                    elements[index] = tmp;
                    index = (index + 1) * 2;

                }
                if ((2 * index) + 1 > size || (index + 1) * 2 > size)
                    break;
            }*/
            var index = size - 1;
            while (elements[index] < elements[index / 2] && index >= 1)
            {
                var tmp = elements[index / 2];
                elements[index / 2] = elements[index];
                elements[index] = tmp;
                index /= 2;
            }
            return min;
        }
        public int Size()
        {
            return size;
        }
        public Element<K, D> this[int index]
        // Indeksator dający dostęp do elementu - np. heap[0] == heap.elements[0]
        {
            get
            {
                return this.elements[index];
            }
        }
    }
}
