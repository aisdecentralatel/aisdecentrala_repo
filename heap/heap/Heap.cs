using System;


namespace heap
{
    class Heap<D>
    {
        // elementy stogu
        Element<D>[] elements;
        int size = 0;
        // konstruktor stogu
        public Heap()
        {
            elements = new Element<D>[size + 1]; // tworzy tablice elementów (jak size==0 to 1-elementowa
        }
        public Heap(int size)
        {
            elements = new Element<D>[size];
        }
        public void Push(int key, int data)
        {
            size++;
            // rozszerzanie miejsca w tablicy
            if (size > elements.Length)
            {
                Element<D>[] new_elements = new Element<D>[elements.Length*2]; // podwajanie miejsca w tablicy jeśli brakuje
                
                    elements.CopyTo(new_elements, 0);
                    elements = new_elements;
            }

            elements[size] = data;
            var index = size;
            while (elements[index] > elements[index / 2] && index > 1)
            {
                var tmp = elements[index / 2];
                elements[index / 2] = elements[index];
                elements[index] = tmp;
                index /= 2;
            }
        }
        public void DeleteMax()
            // metoda usuwający największy element ze stogu
        {
            size--;

            var last = elements[size];
            elements[size] = 0;
            var index = 0;
            elements[0] = last; // przenoszenie ostatniego elementu do korzenia

            // odbudowywanie struktury stogu
            while (last < elements[(2 * index) + 1] || last < elements[(index + 1) * 2])
            {
                if (elements[(2 * index)] > elements[(2*index + 1)])
                {
                    var tmp = elements[(2 * index)];
                    elements[(2 * index)] = last;
                    elements[index] = tmp;
                    index = (2 * index);
                }
                else
                {
                    var tmp = elements[(2*index + 1)];
                    elements[(2*index + 1)] = last;
                    elements[index] = tmp;
                    index = (2*index + 1);

                }
                if ((2 * index) + 1 > size || (index + 1) > size)
                    break;
            }
        }
        public int Size()
        {
            return size;
        }
        public D this[int index]
            // Indeksator dający dostęp do elementu - np. heap[0] == heap.elements[0]
        {
            get
            {
                return this.elements[index];
            }
        }
    }
}
