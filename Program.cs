using System;

namespace asd_lab3
{
    class Program
    {
        static Random rand = new Random();
        static void Main(string[] args)
        {
            Console.Write("N = ");
            byte N = (byte)Convert.ToInt32(Console.ReadLine());
            Console.Write("M = ");
            byte M = (byte)Convert.ToInt32(Console.ReadLine()), k, l;
            byte[,] matrix = creatematrix(N, M);
            Console.WriteLine();
            byte[] min = new byte[2];
            for (byte j = 0; j < M; j++)
            {
                for (byte i = 0; i < N; i++)
                {
                    if (i - j > 0)
                    {
                        min[0] = i;
                        min[1] = j;
                        l = (byte)(10 * (j+1) + i + 1);
                        for (byte j1 = 0; j1 < M; j1++)
                        {
                            for (byte i1 = 0; i1 < N; i1++)
                            {
                                if(l < (byte)10*(j1+1) + i1 + 1)
                                {
                                    if (i1 - j1 > 0)
                                    {
                                        if (matrix[i1, j1] < matrix[min[0], min[1]])
                                        {
                                            min[0] = i1;
                                            min[1] = j1;
                                        }
                                    }
                                }
                            }
                        }
                        k = matrix[i, j];
                        matrix[i, j] = matrix[min[0], min[1]];
                        matrix[min[0], min[1]] = k;
                    }
                }
            }
            printmatrix(matrix, N, M);



        }
        static byte[,] creatematrix(byte N, byte M)
        {
            byte[,] matrix = new byte[N, M];
            for(byte i = 0; i < N; i++)
            {
                for(byte j = 0; j < M; j++)
                {
                    byte d = (byte)rand.Next(10);
                    matrix[i,j] = d;
                    if (i - j >= 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    
                    
                    Console.Write($"{d,2}");
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
            return matrix;
        }
        static void printmatrix(byte[,] matrix, byte N, byte M)
        {
            for (byte i = 0; i < N; i++)
            {
                for (byte j = 0; j < M; j++)
                {
                    if (i - j >= 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    Console.Write($"{matrix[i, j],2}");
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
        }
    }
}
