using System;

namespace asdlab2
{
    class Program
    {
        static void Main(string[] args)
        {
            var rand = new Random();
            Console.Write("N = M = "); int N = Convert.ToInt32(Console.ReadLine()), M = N;
            if(N < 0 || N % 2 == 0)
            {
                Console.WriteLine("wrong N and M");
            }
            else
            {
                int i, j;
                int[,] matrix = new int[M, N];
                for(i = 0; i < M; i++)
                {
                    Console.Write("|");
                    for(j = 0; j < N; j++)
                    {
                        matrix[i, j] = rand.Next(0, N * M);
                        Console.Write($"{matrix[i, j],8}|");
                    }
                    Console.WriteLine();
                }
                i = 0;
                j = 0;
                
                int a = 0;
                int b = 0;
                int m = Convert.ToInt32(N/2);
                int n = Convert.ToInt32(N / 2);
                int k = -1;
                int max = matrix[m, n];
                int c = m;
                int d = n;
                Console.Write($"{matrix[m, n]}");
                while (m < M && n < N)
                {
                    a += 1;
                    b += 1;
                    
                        for (i = 0; i < a; i++)
                        {
                            if (m == M - 1 && n == 0)
                                break;
                            n += k;
                            Console.Write($", {matrix[m, n]}");
                        if (matrix[m, n] > max)
                        {
                            c = m;
                            d = n;
                            max = matrix[m, n];
                        }
                        }

                        for (j = 0; j < b; j++)
                        {
                            if (m == M - 1 && n == 0)
                                break;

                            m += k;
                            Console.Write($", {matrix[m, n]}");
                        if (matrix[m, n] > max)
                        {
                            max = matrix[m, n];
                            c = m;
                            d = n;
                        }
                        }


                    if (m == M - 1 && n == 0)
                        break;
                    k *= -1;
                }
                Console.WriteLine();
                Console.WriteLine($"max = {max}");
                if (c == d)
                    Console.WriteLine("max element lies on the main diagonal");
                if (c < d)
                    Console.WriteLine("max element lies up of the main diagonal");
                if(c>d)
                    Console.WriteLine("max element lies under the main diagonal");
            }
        }
    }
}

