using System;

namespace lab_1_task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            
           
            try
            {

                Console.Write("y = "); string y1 = Console.ReadLine();
                if (Convert.ToInt32(y1) >= 1582 && Convert.ToInt32(y1) <= 4902)
                {
                    int d, c, y;
                    c = Convert.ToInt32(y1[0].ToString() + y1[1].ToString());
                    y = Convert.ToInt32(y1[2].ToString() + y1[3].ToString());
                    d = 25;
                    while (true)
                    {
                        if ((d + Math.Truncate(2.6 * 8.0 - 0.2) + y + Math.Truncate(y / 4.0) + Math.Truncate(c / 4.0) - 2 * c) % 7 == 0)
                        {
                            break;
                        }
                        else
                            d++;
                    }
                    Console.WriteLine($"The day is {d}");
                }
                else
                    Console.WriteLine("wrong number");
            }
            catch
            {
                Console.WriteLine("error");
            }
        }
    }
}
