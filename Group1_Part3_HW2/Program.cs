using System.Diagnostics;

namespace Group1_Part3_HW2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var arr = new int[5000];
            FillArray(arr);
            TestSort(arr);
            Console.WriteLine("-------------------------------------------------------------------------");

            arr = new int[25000];
            FillArray(arr);
            TestSort(arr);
            Console.WriteLine("-------------------------------------------------------------------------");

            arr = new int[50000];
            FillArray(arr);
            TestSort(arr);
            Console.WriteLine("-------------------------------------------------------------------------");

        }
        private static void FillArray(int[] arr)
        {
            Console.WriteLine($"Array {arr.Length} generation started...");

            var rnd = new Random();
            for (int i = 0; i < arr.Length - 1; i++)
            {
                arr[i] = rnd.Next();
            }

            Console.WriteLine($"Array {arr.Length} generation finished...");
        }
        private static void TestSort(int[] arr)
        {
            int[] arrUnsorted = new int[arr.Length];

            Array.Copy(arr, arrUnsorted, arr.Length);
            Console.Write($"MeregeSort started... ");
            var duration = MergeSort.Sort(arrUnsorted);
            Console.WriteLine($"MeregeSort finished: duration is {duration} milliseconds");

            Array.Copy(arr, arrUnsorted, arr.Length);
            Console.Write($"HeapSort   started... ");
            duration = HeapSort.Sort(arrUnsorted);
            Console.WriteLine($"HeapSort   finished: duration is {duration} milliseconds");

            Array.Copy(arr, arrUnsorted, arr.Length);
            Console.Write($"BubbleSort started... ");
            duration = BubbleSort.Sort(arrUnsorted);
            Console.WriteLine($"BubbleSort finished: duration is {duration} milliseconds");
           
        }
        public static class BubbleSort
        {
            public static int Sort(int[] array)
            {
                var stopwatch = new Stopwatch();
                stopwatch.Start();

                int n = array.Length;
                for (int i = 0; i < n - 1; i++)
                    for (int j = 0; j < n - i - 1; j++)
                        if (array[j] > array[j + 1])
                            Swap(array, j, j + 1);

                stopwatch.Stop();
                return (int)stopwatch.ElapsedMilliseconds;
            }
            private static void Swap(int[] array, int i, int j)
            {
                int temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }
        }
        public static class MergeSort
        {
            public static int Sort(int[] arr) 
            {
                var stopwatch = new Stopwatch();
                stopwatch.Start();

                QuickSort(arr, 0, arr.Length - 1);

                stopwatch.Stop();
                return (int)stopwatch.ElapsedMilliseconds;
            }
            static void QuickSort(int[] array, int low, int high)
            {
                if (low < high)
                {
                    int pivotIndex = Partition(array, low, high);

                    QuickSort(array, low, pivotIndex - 1);
                    QuickSort(array, pivotIndex + 1, high);
                }
            }

            static int Partition(int[] array, int low, int high)
            {
                int pivot = array[high];
                int i = low - 1;

                for (int j = low; j < high; j++)
                {
                    if (array[j] < pivot)
                    {
                        i++;
                        Swap(array, i, j);
                    }
                }
                Swap(array, i + 1, high);

                return i + 1;
            }
            private static void Swap(int[] array, int i, int j)
            {
                int temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }
        }
        public static class HeapSort
        {
            public static int Sort(int[] array)
            {
                var stopwatch = new Stopwatch();
                stopwatch.Start();

                int n = array.Length;

                for (int i = n / 2 - 1; i >= 0; i--)
                    Heapify(array, n, i);

                for (int i = n - 1; i >= 0; i--)
                {
                    Swap(array, 0, i);

                    Heapify(array, i, 0);
                }
                stopwatch.Stop();
                return (int)stopwatch.ElapsedMilliseconds;
            }

            private static void Heapify(int[] array, int n, int i)
            {
                int largest = i; 
                int left = 2 * i + 1; 
                int right = 2 * i + 2; 

                if (left < n && array[left] > array[largest])
                    largest = left;

                if (right < n && array[right] > array[largest])
                    largest = right;

                if (largest != i)
                {
                    Swap(array, i, largest);

                    Heapify(array, n, largest);
                }
            }

            private static void Swap(int[] array, int i, int j)
            {
                int temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }
        }
        static void PrintArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
        }
    }
}