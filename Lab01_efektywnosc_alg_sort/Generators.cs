using System;

namespace Lab01_efektywnosc_alg_sort
{
    public static class Generators
    {
        public static int[] GenerateRandom(int size, int min, int max)
        {
            var rand = new Random();
            int[] numbers = new int[size];

            for (int i = 0; i < size; i++)
                numbers[i] = rand.Next(min, max);

            return numbers;
        }

        public static int[] GenerateSorted(int size, int min, int max)
        {
            int[] numbers = GenerateRandom(size, min, max);
            Array.Sort(numbers);
            return numbers;
        }

        public static int[] GenerateReversed(int size, int min, int max)
        {
            int[] numbers = GenerateSorted(size, min, max);
            Array.Reverse(numbers);
            return numbers;
        }

        public static int[] GenerateAlmostSorted(int size, int min, int max)
        {

            var rand = new Random();
            int[] numbers = GenerateSorted(size, min, max);
            double quantity = Math.Ceiling(Convert.ToDouble(size) / 1000);      // Quantity of numbers to change - 0,1% off all numbers, at least 1

            for (int i = 0; i < quantity; i++)
            {
                int index = rand.Next(1, size - 2);     // Random index of array, avoids first and last element
                int newNum = rand.Next(1, 3) == 1 ? rand.Next(min, numbers[index - 1]) : rand.Next(numbers[index + 1], max); // New number must be greater or smaller than the adjacent numbers
                numbers[index] = newNum;
            }

            return numbers;
        }

        public static int[] GenerateFewUnique(int size, int min, int max)
        {
            int[] numbers = GenerateRandom(size, min, max);
            return numbers;
        }
    }
}
