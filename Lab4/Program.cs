using System;

namespace laba_4
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<int> linkedList = new LinkedList<int>();
            while (true)
            {
                Console.WriteLine("1 - AddFirst() \n2 - AddLast() \n3 - AddAtPosition() \n4 - DeleteFirst() \n5 - DeleteLast() \n6 - DeleteAtPosition \n7 - Function of my variant");
                string command = Console.ReadLine();
                if(command == "1")
                {
                    Console.Write("a = "); int a = Convert.ToInt32(Console.ReadLine());
                    linkedList.AddFirst(a);
                    linkedList.Print();
                }
                else if(command == "2")
                {
                    Console.Write("a = "); int a = Convert.ToInt32(Console.ReadLine());
                    linkedList.AddLast(a); linkedList.Print();
                }
                else if(command == "3")
                {
                    Console.Write("a = "); int a = Convert.ToInt32(Console.ReadLine());
                    Console.Write("pos = "); int pos = Convert.ToInt32(Console.ReadLine());
                    linkedList.AddAtPosition(a, pos); linkedList.Print();
                }
                else if(command == "4")
                {
                    linkedList.DeleteFirst(); linkedList.Print();
                }
                else if(command == "5")
                {
                    linkedList.DeleteLast(); linkedList.Print();
                }
                else if(command == "6")
                {
                    
                    Console.Write("pos = "); int pos = Convert.ToInt32(Console.ReadLine());
                    linkedList.DeleteAtPosition(pos); linkedList.Print();
                }
                else if (command == "7")
                {

                    Console.Write("a = "); int a = Convert.ToInt32(Console.ReadLine());
                    linkedList.Func(a); linkedList.Print();
                }
                Console.WriteLine("any other key - continue \n2 - end");
                command = Console.ReadLine();
                if(command == "2")
                {
                    break;
                }
                else
                {

                }
            }

        }
    }
    class LinkedList<T>
    {
        Node tail;
        private int counter = 0; 
        public void AddFirst(T a)
        {
            if (tail == null)
                tail = new Node(a);
            else
                tail.next = new Node(a, tail.next);

            counter++;
        }
        public void AddLast(T a)
        {
            if (tail == null)
                tail = new Node(a);
            else
            {
                
                tail.next = new Node(a, tail.next);
                tail = tail.next;
            }

            counter++;

        }
        public void AddAtPosition(T a, int pos)
        {
            if (tail == null)
            {
                tail = new Node(a);
                counter++;
                return;
            }
                
            if(pos == counter + 1)
            {
                AddLast(a);
                return;
            }
            if (pos == 1)
            {
                AddFirst(a);
                return;
                
            }
                
            if (pos <= counter && pos > 1)
            {
                Node node = tail.next;
                for (int i = 1; i < pos - 1; i++)
                {
                    node = node.next;
                }
                /*Node newNode = new Node(a, node.next);*/
                Node tmp = node.next;
                node.next = new Node(a, tmp);
                counter++;
                return;
            }
            else
                AddFirst(a);
            
        }
        public void DeleteFirst()
        {
            if(counter == 0)
            {
                Console.WriteLine("nothing to delete");
            }
            else
            {
                tail.next = tail.next.next;
                counter--;
            }
        }
        public void DeleteLast()
        {
            if(counter == 0)
            {
                Console.WriteLine("nothing to delete");
            }
            else
            {
                Node node = tail.next;
                while (node.next != tail)
                {
                    node = node.next;
                }
                node.next = tail.next;
                tail = node;
                counter--;
            }
        }
        public void DeleteAtPosition(int pos)
        {
            if(pos == 1)
            {
                DeleteFirst();
            }
            else if (pos == counter)
            {
                DeleteLast();
            }
            else if(pos > 1 && pos < counter)
            {
                Node node = tail.next;
                for (int i = 1; i < pos - 2; i++)
                {
                    node = node.next;
                }
                node.next = node.next.next;
                counter--;
            }
            else
            {
                Console.WriteLine("Operation could not be completed");
            }
        }
        public void Print()
        {
            Node node = tail.next;
            for(int i = 0; i < counter; i++)
            {
                Console.Write($"{node.data} ");
                node = node.next;
            }
            Console.WriteLine();
        }
        public void Func(T a)
        {
            if (tail == null)
            {
                tail = new Node(a);
                counter++;
                return;
            }
            else
            {
                Node node = tail.next;
                for (int i = 1; i < counter / 2; i++)
                {
                    node = node.next;
                }
                Node tmp = node.next;
                node.next = new Node(a, tmp);
                counter++;
            }
        }
        class Node
        {
            
            public Node next;
            public T data;
            public Node(T data, Node next)
            {
                this.data = data;
                this.next = next;
                
            }
            public Node(T data)
            {
                next = this;
                this.data = data;
            }

        }
    }

}
