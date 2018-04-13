using System;
using System.Threading.Tasks;
using System.Diagnostics;

namespace parallelQuicksort
{
    class Program
    {
        static void Main(string[] args)
        {
            const int N = 50_000_000;
            for (int i = 0; i < 5; i++)
            {
                var array = GetRandomArray(N);
                Measure("Sequential\t", () => SequentialQuickSort.Sort(array));
                array = GetRandomArray(N);
                Measure("Parallel\t", () => ParallelQuickSort.Sort(array));
                array = GetRandomArray(N);
                Measure("P. Separate Method", () => ParallelSeparateMethodQuickSort.Sort(array));
            }
        }

        private static int[] GetRandomArray(int length)
        {
            var random = new Random(4711);
            var array = new int[length];
            for (int i = 0; i < length; i++)
            {
                array[i] = random.Next();
            }
            return array;
        }

        public static void Measure(string name, Action action)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            action();
            stopwatch.Stop();
            var time = stopwatch.ElapsedMilliseconds;
            Console.WriteLine($"{name}: \tElapsed={time}");
        }
    }

    public class SequentialQuickSort
    {
        public static void Sort(int[] array)
        {
            if (array == null || array.Length == 0)
            {
                new ArgumentException("number array must be at least of length 1");
            }
            QuickSort(array, 0, array.Length - 1);
        }

        private static void QuickSort(int[] array, int left, int right)
        {
            var i = left;
            var j = right;
            var m = array[(left + right) / 2];
            while (i <= j)
            {
                while (array[i] < m) { i++; }
                while (array[j] > m) { j--; }
                if (i <= j)
                {
                    var t = array[i]; array[i] = array[j]; array[j] = t;
                    i++; j--;
                }
            }

            if (j > left) { QuickSort(array, left, j); }
            if (i < right) { QuickSort(array, i, right); }
        }
    }

    public class ParallelQuickSort
    {

        private const int Threshold = 100;

        public static void Sort(int[] array)
        {
            if (array == null || array.Length == 0)
            {
                new ArgumentException("number array must be at least of length 1");
            }
            QuickSort(array, 0, array.Length - 1);
        }

        private static void QuickSort(int[] array, int left, int right)
        {
            var i = left;
            var j = right;
            var m = array[(left + right) / 2];
            while (i <= j)
            {
                while (array[i] < m) { i++; }
                while (array[j] > m) { j--; }
                if (i <= j)
                {
                    var t = array[i]; array[i] = array[j]; array[j] = t;
                    i++; j--;
                }
            }
            if (j - left > Threshold && right - i > Threshold)
            {
                Parallel.Invoke(
                    () => QuickSort(array, left, j),
                    () => QuickSort(array, i, right)
                );
            }
            else
            {
                if (j > left) { QuickSort(array, left, j); }
                if (i < right) { QuickSort(array, i, right); }
            }
        }

    }

    public class ParallelSeparateMethodQuickSort
    {

        private const int Threshold = 100;

        public static void Sort(int[] array)
        {
            if (array == null || array.Length == 0)
            {
                new ArgumentException("number array must be at least of length 1");
            }
            QuickSort(array, 0, array.Length - 1);
        }

        private static void QuickSort(int[] array, int left, int right)
        {
            var i = left;
            var j = right;
            var m = array[(left + right) / 2];
            while (i <= j)
            {
                while (array[i] < m) { i++; }
                while (array[j] > m) { j--; }
                if (i <= j)
                {
                    var t = array[i]; array[i] = array[j]; array[j] = t;
                    i++; j--;
                }
            }
            if (j - left > Threshold && right - i > Threshold)
            {
                ParallelInvoke(array, left, j, i, right);
            }
            else
            {
                if (j > left) { QuickSort(array, left, j); }
                if (i < right) { QuickSort(array, i, right); }
            }
        }

        private static void ParallelInvoke(int[] array, int left, int j, int i, int right)
        {
            Parallel.Invoke(
                    () => QuickSort(array, left, j),
                    () => QuickSort(array, i, right)
                );
        }

    }

}
