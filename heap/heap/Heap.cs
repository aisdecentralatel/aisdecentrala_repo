namespace heap
{
    class Heap
    {
        // elementy stogu
        Element[] elements;
        int size = 0;
        // konstruktor stogu
        public Heap()
        {
            elements = new Element[size + 1]; // tworzy tablice elementów (jak size==0 to 1-elementowa
        }
        public void Push(int data)
        {
            size++;
            // rozszerzanie miejsca w tablicy
            if (size > elements.Length)
            {
                Element[] new_elements = new Element[elements.Length +1]; // podwajanie miejsca w tablicy jeśli brakuje
                elements.CopyTo(new_elements, 0);
                elements = new_elements;
            }

            elements[size - 1] = data;
            var index = size - 1;
            while (elements[index] > elements[index / 2] && index >= 1)
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
                if (elements[(2 * index) + 1] > elements[(index + 1) * 2])
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
            }
        }
        public int Size()
        {
            return size;
        }
        public int this[int index]
            // Indeksator dający dostęp do elementu - np. heap[0] == heap.elements[0]
        {
            get
            {
                return this.elements[index];
            }
            set
            {
                this.elements[index] = value;
            }
        }
    }
}
