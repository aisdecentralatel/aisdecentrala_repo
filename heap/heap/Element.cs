using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace heap
{
    class Element
    {
        int key;


        public Element(int key)
        {
            this.key = key;
        }
       
        public static implicit operator int (Element element)
            // operator konwersji Element -> int
        {
            return element.key;
        }
        public static implicit operator Element(int key)
            // operator konwersji int -> Element
        {
            return new Element(key);
        }
    }
}
