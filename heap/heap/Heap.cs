namespace heapsort
{
    class Heap//klasa heapa
    {
        static public int[] CreateFromArray(int[] array)
        // Zwraca tablice zamieniona na kopiec
        {
            for (var i = 0; i < array.Length - 1; i++)
            {
                var index = i + 1;

                while (array[index / 2] > array[index] && index >= 1)
                {
                    var tmp = array[index / 2];
                    array[index / 2] = array[index];
                    array[index] = tmp;
                    index /= 2;
                }
            }
            return array;
        }
        static public int[] HeapSort(int[] array)
        // Sortuje utworzony kopiec
        {
            var sorted = false;
            var index = array.Length - 1;
            while (!sorted)
            {
                var first = array[0];
                var last = array[array.Length - 1]; //
                // dodalem komentarz
            }


            return array;
        }
    }
}
