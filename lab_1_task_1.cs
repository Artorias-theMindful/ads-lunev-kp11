using System;

namespace asd_task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            double x, y, z, a, b;
            Console.Write("x = "); x = Convert.ToDouble(Console.ReadLine());
            Console.Write("y = "); y = Convert.ToDouble(Console.ReadLine());
            Console.Write("z = "); z = Convert.ToDouble(Console.ReadLine());
            if (x > 0 && x * z != -2)
            {
                a = Math.Tan(Math.Pow(x, -y) + z / (y * y + 1) + Math.Pow(y / (x * z + 2), 1.0 / 3.0));
                Console.WriteLine("a = " + a.ToString());
                if (z != 0 && Math.Sin((x + Math.PI * y) / z) != 0)
                {
                    b = a / Math.Sin((x + Math.PI * y) / z);
                    Console.WriteLine("b = " + b.ToString());
                }
                else
                    Console.WriteLine("b does not exist");
            }
            else
                Console.WriteLine("a and b do not exist");
            



        }
    }
}
