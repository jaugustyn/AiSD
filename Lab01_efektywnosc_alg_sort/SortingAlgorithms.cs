using System;

namespace Lab01_efektywnosc_alg_sort
{
    public static class SortingAlgorithms
    {

        //-------------------------------------------//
        // InsertionSort - O(n^2)
        //-------------------------------------------//
        public static void InsertionSort(int[] arr)
        {
            int key, j;
            for (int i = 1; i < arr.Length; i++)
            {
                key = arr[i];
                j = i - 1;

                while (j >= 0 && arr[j] > key)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }
                arr[j + 1] = key;
            }
        }


        //-------------------------------------------//
        // MergeSort - O(n * log n)
        // l - left, m - middle, r - right
        //-------------------------------------------//
        private static void merge(int[] arr, int l, int m, int r)
        {
            int n1 = m - l + 1;
            int n2 = r - m;

            int[] temp1 = new int[n1];
            int[] temp2 = new int[n2];

            int i, j;

            // Rozdzielenie danych na dwie części
            for (i = 0; i < n1; i++)
            {
                temp1[i] = arr[l + i];
            }

            for (j = 0; j < n2; j++)
            {
                temp2[j] = arr[m + j + 1];
            }

            i = 0;
            j = 0;
            int k = l;

            // Sortowanie przez scalanie dwóch tablic
            while (i < n1 && j < n2)
            {
                if (temp1[i] <= temp2[j])
                {
                    arr[k] = temp1[i];
                    i++;
                }
                else
                {
                    arr[k] = temp2[j];
                    j++;
                }
                k++;
            }

            // Dodanie pozostałych elementów tablic
            while (i < n1)
            {
                arr[k] = temp1[i];
                i++;
                k++;
            }
            
            while (j < n2)
            {
                arr[k] = temp2[j];
                j++;
                k++;
            }
        }
        public static void MergeSort(int[] arr, int l, int r)
        {
            if (l < r)
            {
                int m = l + (r - l) / 2;
                MergeSort(arr, l, m);
                MergeSort(arr, m + 1, r);
                merge(arr, l, m, r);
            }
        }


        //-------------------------------------------//
        // QuickSort - O(n * log n) in the best case
        //-------------------------------------------//
        private static int Partition(int[] arr, int l, int r)
        {
            int pivot = arr[(l + r)/2];
            int i = (l - 1);

            for (int j = l; j <= r - 1; j++)
            {
                if (arr[j] < pivot)
                {
                    i++;
                    Utils.Swap(arr, i, j);
                }
            }
            Utils.Swap(arr, i + 1, r);

            return (i + 1);
        }
        public static void QuickSortClassical(int[] arr, int l, int r)
        {
            if (l < r)
            {
                int partition = Partition(arr, l, r);

                QuickSortClassical(arr, l, partition - 1);
                QuickSortClassical(arr, partition + 1, r);
            }
        }


        //-------------------------------------------//
        // Array.Sort()
        //-------------------------------------------//
        public static void QuickSort(int[] arr)
        {
            Array.Sort(arr);
        }
    }
}
