namespace Hw2.Exercise4.Sorting
{
    internal class QuickSort : SortBase
    {
        public override void Sort(int[] array)
        {
            if (array is null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            _ = QuickSortMethod(array, 0, array.Length - 1);
        }

        private void Swap(ref int x, ref int y)
        {
            var t = x;
            x = y;
            y = t;
        }

        private int Partition(int[] array, int minIndex, int maxIndex)
        {
            var pivot = minIndex - 1;
            for (var i = minIndex; i < maxIndex; i++)
            {
                if (array[i] < array[maxIndex])
                {
                    pivot++;
                    Swap(ref array[pivot], ref array[i]);
                }
            }

            pivot++;
            Swap(ref array[pivot], ref array[maxIndex]);
            return pivot;
        }

        private int[] QuickSortMethod(int[] array, int minIndex, int maxIndex)
        {
            if (minIndex >= maxIndex)
            {
                return array;
            }

            var pivotIndex = Partition(array, minIndex, maxIndex);
            _ = QuickSortMethod(array, minIndex, pivotIndex - 1);
            _ = QuickSortMethod(array, pivotIndex + 1, maxIndex);

            return array;
        }
    }
}
