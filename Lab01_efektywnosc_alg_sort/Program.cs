using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Lab01_efektywnosc_alg_sort
{
    public delegate void SortAlg_1arg(int[] arr);
    public delegate void SortAlg_3args(int[] arr, int l, int r);
    public class Program
    {
        
        public static void Main()
        {
            var InsertionSort = new SortAlg_1arg(SortingAlgorithms.InsertionSort);
            var MergeSort = new SortAlg_3args(SortingAlgorithms.MergeSort);
            var QuickSortClassical = new SortAlg_3args(SortingAlgorithms.QuickSortClassical);
            var QuickSort = new SortAlg_1arg(SortingAlgorithms.QuickSort);

            // Initial allocation - to avoid difference in results of the first attempts
            SortingAlgorithms.InsertionSort(Generators.GenerateRandom(100, 0, 100));
            SortingAlgorithms.MergeSort(Generators.GenerateRandom(100, 0, 100), 0, 99);
            SortingAlgorithms.QuickSortClassical(Generators.GenerateRandom(100, 0, 100), 0, 99);
            SortingAlgorithms.QuickSort(Generators.GenerateRandom(100, 0, 100));


            int[] size = { 10, 1000, 100000 }; // minimal size is 3
            int min = 0;
            int[] max = { 20, 2000, 200000 };
            int[] maxFewUnique = { 2, 8, 32 };

            Console.WriteLine("Results in miliseconds");
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("Array size: " + size[i]);

                Console.WriteLine("\nRandom numbers: ");
                Experiment(Generators.GenerateRandom(size[i], min, max[i]), InsertionSort, null);
                Experiment(Generators.GenerateRandom(size[i], min, max[i]), null, MergeSort);
                Experiment(Generators.GenerateRandom(size[i], min, max[i]), null, QuickSortClassical);
                Experiment(Generators.GenerateRandom(size[i], min, max[i]), QuickSort, null);

                Console.WriteLine("\nSorted numbers:");
                Experiment(Generators.GenerateSorted(size[i], min, max[i]), InsertionSort, null);
                Experiment(Generators.GenerateSorted(size[i], min, max[i]), null, MergeSort);
                Experiment(Generators.GenerateSorted(size[i], min, max[i]), null, QuickSortClassical);
                Experiment(Generators.GenerateSorted(size[i], min, max[i]), QuickSort, null);

                Console.WriteLine("\nNumbers sorted in reverse:");
                Experiment(Generators.GenerateReversed(size[i], min, max[i]), InsertionSort, null);
                Experiment(Generators.GenerateReversed(size[i], min, max[i]), null, MergeSort);
                Experiment(Generators.GenerateReversed(size[i], min, max[i]), null, QuickSortClassical);
                Experiment(Generators.GenerateReversed(size[i], min, max[i]), QuickSort, null);

                Console.WriteLine("\nAlmost sorted numbers:");
                Experiment(Generators.GenerateAlmostSorted(size[i], min, max[i]), InsertionSort, null);
                Experiment(Generators.GenerateAlmostSorted(size[i], min, max[i]), null, MergeSort);
                Experiment(Generators.GenerateAlmostSorted(size[i], min, max[i]), null, QuickSortClassical);
                Experiment(Generators.GenerateAlmostSorted(size[i], min, max[i]), QuickSort, null);

                Console.WriteLine("\nFew unique numbers:");
                Experiment(Generators.GenerateFewUnique(size[i], min, maxFewUnique[i]), InsertionSort, null);
                Experiment(Generators.GenerateFewUnique(size[i], min, maxFewUnique[i]), null, MergeSort);
                Experiment(Generators.GenerateFewUnique(size[i], min, maxFewUnique[i]), null, QuickSortClassical);
                Experiment(Generators.GenerateFewUnique(size[i], min, maxFewUnique[i]), QuickSort, null);
                Console.WriteLine("\n--------------------------------------------------------------------\n");
            }
            Console.WriteLine("Click enter to exit");
            Console.ReadLine();
        }
        public static void Experiment(int[] arr, SortAlg_1arg alg, SortAlg_3args alg3)
        {
            int[] arr_clone;
            string algName = alg != null ? alg.Method.Name : alg3.Method.Name;
            var results = new List<double>();
            Stopwatch stopWatch = new Stopwatch();

            for (int i = 0; i < 10; i++)
            {
                arr_clone = (int[])arr.Clone();
                if (alg != null)
                {
                    stopWatch.Start();
                    alg(arr_clone);
                    stopWatch.Stop();
                }
                else
                {
                    stopWatch.Start();
                    alg3(arr_clone, 0, arr_clone.Length - 1);
                    stopWatch.Stop();

                }
                results.Add(stopWatch.Elapsed.TotalMilliseconds);
                stopWatch.Reset();
            }

            string average = Math.Round(results.Average(), 5).ToString("F5");
            string deviation = Math.Round(Utils.StandardDeviation(results), 5).ToString("F5");

            Console.WriteLine(" * {0}: t = {1} +/- {2}", algName, average, deviation);
        }
    }
}
