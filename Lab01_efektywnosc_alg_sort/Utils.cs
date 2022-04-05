using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab01_efektywnosc_alg_sort
{
    public static class Utils
    {
        public static void PrintArray(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
        }

        public static void Swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
        public static double StandardDeviation(List<double> array)
        {
            double average = array.Average();
            double sumOfSquaresOfDifferences = array.Select(val => (val - average) * (val - average)).Sum();
            double sd = Math.Sqrt(sumOfSquaresOfDifferences / array.Count);
            return sd;
        }
    }
}
