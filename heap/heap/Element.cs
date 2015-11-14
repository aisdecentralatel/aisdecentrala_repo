using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace heap
{
    class Element <D>
    {
        double key;
        D data;

        public Element(int key, D data)
            // Konstruktor klasy Element
        {
            this.key = key;
            this.data = data;
        }
        public Element(int key)
        // Konstruktor klasy Element
        {
            this.key = key;
        }

        public static implicit operator D (Element<D> element)
            // operator konwersji Element -> D
        {
            return element.data;
        }
        public static implicit operator Element<D>(int key)
            // operator konwersji int -> Element
        {
            return new Element<D>(key);
        }
        public static bool operator >(Element<D> element1, Element<D> element2)
        {
            if (element1.key > element2.key)
                return true;
            else return false;
        }
        public static bool operator <(Element<D> element1, Element<D> element2)
        {
            if (element1.key < element2.key)
                return true;
            else return false;
        }
        public double GetKey()
        {
            return key;
        }
    }
}
