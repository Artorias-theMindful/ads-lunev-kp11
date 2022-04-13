using System;

namespace ConsoleApp18
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = 1;
            for(int i = 0; i < 1; i++)
            {
                try
                {
                    Console.Write("Розмiр масиву - ");N = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    i--;
                    Console.WriteLine("Введiть знову");
                }
            }
            int[] array = new int[N];
            for(int i = 0; i < N; i++)
            {
                try
                {
                    Console.Write($"Bведiть {i + 1} елемент: "); array[i] = Convert.ToInt32(Console.ReadLine());
                   
                }
                catch
                {
                    i--;
                    Console.WriteLine("Введiть знову");
                }
            }
            Console.ForegroundColor = ConsoleColor.Blue;
            for(int i = 0; i < N/2; i++)
            {
                Console.Write($"{array[i]} ");
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            for (int i = N/2; i < N; i++)
            {
                Console.Write($"{array[i]} ");
            }
            Console.WriteLine();
            int max = array[0];
            for(int i = 1; i < N/2; i++)
            {
                if(max < array[i])
                {
                    max = array[i];
                }
            }
            int[] count = new int[max + 1];
            for (int i = 0; i < max; i++)
                count[i] = 0;
            for(int i = 0; i < array.Length/2; i++)
            {
                count[array[i]]++;
            }
            for (int i = 1; i < count.Length; i++)
            {
                count[i] += count[i - 1];
            }
            int[] sorted = new int[array.Length/2];
            for(int i = array.Length/2 - 1; i >= 0; i--)
            {
                sorted[count[array[i]] - 1] = array[i];
            }
            Console.ForegroundColor = ConsoleColor.Blue;
            for(int i = 0; i < sorted.Length; i++)
            {
                Console.Write($"{sorted[i]} ");
            }
            max = array[N / 2 + 1];
            for (int i = N / 2; i < N; i++)
            {
                if (max < array[i])
                {
                    max = array[i];
                }
            }
            count = new int[max + 1];
            for (int i = 0; i < max; i++)
                count[i] = 0;
            for (int i = N/2; i < array.Length; i++)
            {
                count[array[i]]++;
            }
            for (int i = 1; i < count.Length; i++)
            {
                count[i] += count[i - 1];
            }
            sorted = new int[N - array.Length / 2];
            for (int i = array.Length - 1; i >= N/2; i--)
            {
                sorted[count[array[i]] - 1] = array[i];
            }
            for (int i = 0; i < sorted.Length / 2; i++)
            {
                int tmp = sorted[i];
                sorted[i] = sorted[sorted.Length - i - 1];
                sorted[sorted.Length - i - 1] = tmp;
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            for (int i = 0; i < sorted.Length; i++)
            {
                Console.Write($"{sorted[i]} ");
            }
            Console.ForegroundColor = ConsoleColor.Gray;

        }

    }
}
    