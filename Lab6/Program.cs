using System;

namespace ASD6lab
{
    class Program
    {
        static string[] array = new string[4];
        static int head = 2;
        static int tail = 2;
        
        static void Main(string[] args)
        {
            
            while (true)
            {
                Console.WriteLine("Enter the item you want to add. If you want to delete an item, enter 'out'. If you want to see a control example to understand how the programm works, enter 'example'");
                string str = Console.ReadLine();
                if (str == "out")
                {
                    
                    if(array[head] != null)
                        DeleteItem();
                    else
                        Console.WriteLine("There is nothing to delete");

                }
                else if(str == "example")
                {
                    ControlExample();
                }
                else
                {
                    AddItem(str);
                }
                Write();
            }


        }
        static void DoubleArray()
        {
            string[] tmp = new string[array.Length * 2];
            
            for (int i = head; i < array.Length; i++)
            {
                tmp[array.Length + i] = array[i];
            }
            for (int i = 0; i <= tail; i++)
            {
                tmp[i] = array[i];
            }
            head += array.Length;
            array = tmp;
            
        }

        static void ControlExample()
        {
            Console.WriteLine("apple");
            AddItem("apple");
            Write();
            Console.WriteLine("banana");
            AddItem("banana");
            Write();
            Console.WriteLine("lemon");
            AddItem("lemon");
            Write();
            Console.WriteLine("orange");
            AddItem("orange");
            Write();
            Console.WriteLine("strawberry");
            AddItem("strawberry");
            Write();
            Console.WriteLine("out");
            DeleteItem();
            
        }

        static void DeleteItem()
        {
            
            
            if (array[(head + 1)%array.Length] == null)
            {
                array[head] = null;                
            }
            else
            {
                array[head] = null;
                head = (head + 1) % array.Length;
            }
        }
        static void Write()
        {
            Console.WriteLine("_________________________________________________");
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }
            Console.WriteLine("_________________________________________________");
        }
        static void AddItem(string str)
        {



            if (array[(head + 1) % array.Length] == null && array[tail] == null)
            {
                array[tail] = str;

            }
            else
            {
                
                if (tail + 1 == head)
                {
                    Console.WriteLine("Array will be doubled");
                    DoubleArray();
                }
                tail = (tail + 1) % array.Length;
                array[tail] = str;
            }

        }
    }
}
