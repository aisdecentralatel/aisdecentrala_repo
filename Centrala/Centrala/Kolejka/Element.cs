using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace heap
{
    public class Element<K, D> where K : IComparable
    {
        private K key;
        private D data;

        public Element(K key, D data)
        // Konstruktor klasy Element
        {
            this.key = key;
            this.data = data;
        }
        public Element(K key)
        // Konstruktor klasy Element
        {
            this.key = key;
        }
        public static bool operator >(Element<K, D> element1, Element<K, D> element2)
        {
            if (element1.key.CompareTo(element2.key) > 0)
                return true;
            else return false;
        }
        public static bool operator <(Element<K, D> element1, Element<K, D> element2)
        {
            if (element1.key.CompareTo(element2.key) < 0)
                return true;
            else return false;
        }
        public K GetKey()
        {
            return key;
        }
        public D GetData()
        {
            return data;
        }
    }
}
