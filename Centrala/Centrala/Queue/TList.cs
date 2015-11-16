using System;

namespace heap
{
    class TList<K,D> :QInterface<K,D> where K : IComparable
    {
        // elementy listy
        Element<K,D>[] elements;
        int size;
        public TList()
        {
            Init();
        }
        public void Init()
        {
            size = 0;
            elements = new Element<K, D>[1];
        }
        public void Push(K key, D data)
        {
            size++;
            if(size > elements.Length)
            {
                Element<K,D>[] new_elements = new Element<K,D>[elements.Length * 2];
                elements.CopyTo(new_elements, 0);
                elements = new_elements;
            }
            elements[size - 1] = new Element<K,D>(key, data);
        }
        public Element<K,D> DeleteMin()
        {
            var index = 0;
            var min = elements[0];
            for (var i = 1; i < size; i++)
            {
                if (elements[i] < min)
                {
                    min = elements[i];
                    index = i;
                }
            }
            Element<K,D>[] new_elements = new Element<K,D>[elements.Length - 1];
            for(int i=0, j=0;i< size-1;i++, j++)
            {
                if (i == index)
                    j++;
                new_elements[i] = elements[j];
            }
            elements = new_elements;
            size--;
            return min;
        }
    }
}
