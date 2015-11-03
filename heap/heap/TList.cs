using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace heap
{
    class TList
    {
        // elementy listy
        int[] elements;
        int size;
        public TList()
        {
            size = 0;
            elements = new int[1];
        }
        public void Push(int data)
        {
            size++;
            if(size > elements.Length)
            {
                int[] new_elements = new int[elements.Length * 2];
                elements.CopyTo(new_elements, 0);
                elements = new_elements;
            }
            elements[size - 1] = data;
        }
        public int MinIndex()
        {
            var index = 0;
            var min = elements[0];
            for(var i=1;i< size;i++)
            {
                if(elements[i]<min)
                {
                    min = elements[i];
                    index = i;
                }
            }
            return index;
        }
        public void DeleteAt(int index)
        {
            int[] new_elements = new int[elements.Length - 1];
            for(int i=0, j=0;i< size-1;i++, j++)
            {
                if (i == index)
                    j++;
                new_elements[i] = elements[j];
            }
            elements = new_elements;
            size--;
        }
    }
}
