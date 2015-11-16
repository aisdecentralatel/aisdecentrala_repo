using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace heap
{
    public interface QInterface <K,D> where K : IComparable
    {
        Element<K, D> DeleteMax();
        void Init();
        void Push(K key, D data);
    }
}
