using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
namespace Lab7ASD
{
    class Program
    {
        static HashTable Table = new HashTable();
        static int temp = 1;
        static bool bol = false;
        static Dictionary<string, int> months = new Dictionary<string, int>();
        static string[] usernames = {"artem", "vasya", "vanya", "petya", "sergiy"};
        static string[] passwords = { "afksdgk", "asdasd", "sdfvcxl", "dsgkd", "jnigr" };
        static string[] emailAdresses = { "la@ua.com", "pss@sa.com", "sdd@dd.com", "asddda@ffd.com", "asdsd@awq.com" };
        
        static public int hashCode(Key key, int mod, int a)
        {
            Encoding ascii = Encoding.ASCII;
            byte[] encoded = ascii.GetBytes(key.username);
            int index = 0;
            foreach (byte b in encoded)
            {
                index += b;
            }
            index = index % mod + a;
            return index;
        }
        static public void showData()
        {
            foreach(Entry entry in Table.table)
            {
                if(entry != null)
                {
                    Console.WriteLine("{0, 10} {1, 10} {2, 10} {3, 10} {4, 3}, {5, 5}", entry.key.username, entry.value.hashpassword, entry.value.emailAdress, entry.value.lastLoginDate.month, entry.value.lastLoginDate.day, entry.value.lastLoginDate.year);

                }
            }
        }
        static public int hashPassword(string password)
        {
            Encoding ascii = Encoding.ASCII;
            byte[] encoded = ascii.GetBytes(password);
            int index = 0;
            foreach (byte b in encoded)
            {
                index += b;
            }
            index = index % 5 + index % 6 + index % 2 + index % 3 + index % 4;
            return index;
            
        }
        static public void insertEntry(Key key, Value value, string password)
        {
            int hashcode1 = hashCode(key, Table.size, 0);
            int hashpassword = hashPassword(password);
            while (true)
            {
                if (Table.table[hashcode1] == null)
                {
                    Entry entry = new Entry();
                    entry.key = key;
                    entry.value = value;
                    entry.value.hashpassword = hashpassword;
                    Table.table[hashcode1] = entry;
                    Table.loadness++;
                    if(Table.loadness == Table.size / 2)
                    {
                        HashTable table = new HashTable();
                        table.size = Table.size * 2;
                        table.loadness = Table.loadness;
                        table.initHashTable();
                        for (int i = 0; i < Table.size; i++)
                        {
                            if(Table.table[i] != null)
                            {
                                Key KEY = Table.table[i].key;
                                Value VALUE = Table.table[i].value;
                                Entry ENTRY = new Entry();
                                ENTRY.value = VALUE;
                                ENTRY.key = KEY;
                                table.table[hashCode(KEY, table.size, 0)] = ENTRY;
                            }

                        }
                        Table = table;
                        Console.WriteLine("Table was rehashed");
                    }
                    temp++;
                    break;
                }
                else
                {
                    int hashcode2 = hashCode(key, Table.size / 2, 1);
                    hashcode1 = (hashcode1 + temp * hashcode2) % Table.size;
                    
                }
            }
        }
        static public void removeEntry(Key key)
        {
            Table.table[hashCode(key, Table.size, 0)] = null;
            Console.WriteLine("user " + key.username + " has been deleted");
        }
        static public Value findEntry(Key key)
        {
            if (Table.table[hashCode(key, Table.size, 0)] == null)
                return null;
            Value value = new Value();
            
            value.hashpassword = Table.table[hashCode(key, Table.size, 0)].value.hashpassword;
            value.emailAdress = Table.table[hashCode(key, Table.size, 0)].value.emailAdress;
            value.lastLoginDate = new Date();
            value.lastLoginDate.year = Table.table[hashCode(key, Table.size, 0)].value.lastLoginDate.year;
            value.lastLoginDate.month = Table.table[hashCode(key, Table.size, 0)].value.lastLoginDate.month;
            value.lastLoginDate.day = Table.table[hashCode(key, Table.size, 0)].value.lastLoginDate.day;
            Console.WriteLine("{0, 10} {1, 10} {2, 10} {3, 10} {4, 3}, {5, 5}", key.username, value.hashpassword, value.emailAdress, value.lastLoginDate.month, value.lastLoginDate.day, value.lastLoginDate.year);
            
            
            return value;
        }
        static public bool accountDeactivation(string username)
        {
            DateTime dateTime = new DateTime();
            Key key = new Key();
            key.username = username;
            dateTime = new DateTime(Table.table[hashCode(key, Table.size, 0)].value.lastLoginDate.year, months[Table.table[hashCode(key, Table.size, 0)].value.lastLoginDate.month], Table.table[hashCode(key, Table.size, 0)].value.lastLoginDate.day);
            TimeSpan timeSpan = DateTime.Now.Subtract(dateTime);
            if(timeSpan.TotalDays > 60)
            {
                return true;
            }
            return false;
        }
        static public void authorization()
        {
            Console.WriteLine("Enter username");
            string username = Console.ReadLine();
            Console.WriteLine("Enter password");
            string password = Console.ReadLine();
            try
            {
                Key key = new Key();
                key.username = username;
                if(Table.table[hashCode(key, Table.size, 0)].value.hashpassword == hashPassword(password))
                {
                    if (accountDeactivation(username))
                    {
                        Console.WriteLine("Your account is deactivated");
                        removeEntry(key);
                    }
                    else
                    {
                        Console.WriteLine("authorisation successful");
                    }
                }
                else
                {
                    Console.WriteLine("Wrong password");
                }
            }
            catch
            {
                Console.WriteLine("Wrong username");
            }
        }
        static public void fillData()
        {
            for (int i = 0; i < 5; i++)
            {
                Entry entry = new Entry();
                entry.key = new Key();
                entry.value = new Value();
                entry.key.username = usernames[i];
                entry.value.emailAdress = emailAdresses[i];
                
                Random random = new Random();
                entry.value.lastLoginDate = new Date();
                entry.value.lastLoginDate.day = random.Next(30);
                entry.value.lastLoginDate.month = months.ElementAt(random.Next(12)).Key;
                entry.value.lastLoginDate.year = 2022;
                insertEntry(entry.key, entry.value, passwords[i]);
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Good day! Please enter the size of Hashtable (more than 5):");
            months.Add("September", 9);
            months.Add("October", 10);
            months.Add("November", 11);
            months.Add("December", 12);
            months.Add("January", 1);
            months.Add("February", 2);
            months.Add("March", 3);
            months.Add("April", 4);
            months.Add("May", 5);
            months.Add("June", 6);
            months.Add("July", 7);
            months.Add("August", 8);

            while (true)
            {
                try
                {
                    int a = Convert.ToInt32(Console.ReadLine());
                    if (a > 5)
                    {
                        Table.size = a;
                        break;
                    }
                    Console.WriteLine("Try again");
                }
                catch
                {
                    Console.WriteLine("Try again");
                }
            }
            
            Table.initHashTable();
            while (true)
            {
                Console.WriteLine("1 - add user");
                Console.WriteLine("2 - delete user");
                Console.WriteLine("3 - find user");
                Console.WriteLine("4 - show data");
                Console.WriteLine("5 - fill the table with control data");
                Console.WriteLine("6 - authorization");
                string command = Console.ReadLine();
                if (command == "1")
                {
                    Console.WriteLine("Enter user name");
                    string username = Console.ReadLine();
                    for (int i = 0; i < Table.size; i++)
                    {
                        if (Table.table[i] != null)
                        {
                            if (username == Table.table[i].key.username)
                            {
                                Console.WriteLine("this username already exists, try again");
                                bol = true;
                                break;
                            }
                        }
                    }
                    if (bol)
                    {
                        bol = false;
                        continue;
                    }
                    Console.WriteLine("Enter password");
                    string password = Console.ReadLine();
                    Console.WriteLine("Enter email adress");
                    string emailAdress = Console.ReadLine();
                    for (int i = 0; i < Table.size; i++)
                    {
                        if (Table.table[i] != null)
                        {
                            if (emailAdress == Table.table[i].value.emailAdress)
                            {
                                Console.WriteLine("this email already exists, try again");
                                bol = true;
                                break;
                            }
                        }
                    }
                    if (bol)
                    {
                        bol = false;
                        continue;
                    }
                    Console.WriteLine("Enter year");
                    int year = 0;
                    try
                    {
                        year = Convert.ToInt32(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("Incorrect year");
                        continue;
                    }
                    Console.WriteLine("Enter month");
                    string month = Console.ReadLine();
                    if (!months.ContainsKey(month))
                    {
                        Console.WriteLine("Incorrect month");
                        continue;
                    }
                    Console.WriteLine("Enter day");
                    int day = Convert.ToInt32(Console.ReadLine());
                    try
                    {
                        var dateTime = new DateTime(year, months[month], day);
                        
                    }
                    catch
                    {
                        Console.WriteLine("Impossible date");
                        continue;
                    }
                    Key key = new Key();
                    Value value = new Value();
                    key.username = username;
                    value.emailAdress = emailAdress;

                    Date date = new Date();
                    date.day = day;
                    date.month = month;
                    date.year = year;
                    value.lastLoginDate = date;
                    insertEntry(key, value, password);
                }
                else if (command == "2")
                {
                    Console.WriteLine("Enter key");
                    Key key = new Key();
                    key.username = Console.ReadLine();
                    removeEntry(key);

                }
                else if (command == "3")
                {
                    Console.WriteLine("Enter key");
                    Key key = new Key();
                    key.username = Console.ReadLine();
                    Value value = findEntry(key);
                    if (value == null)
                        Console.WriteLine("There is no such key");
                }
                else if (command == "4")
                {
                    showData();
                }
                else if (command == "6")
                {
                    authorization();
                }
                else if(command == "5")
                {
                    fillData();
                }
            }
        }
    }
    
    struct Date
    {
        public int year;
        public string month;
        public int day;
    }
    class HashTable
    {
        public Entry[] table;
        public int loadness;
        public int size;
        public void initHashTable()
        {
            table = new Entry[size];

        }
    }
    class Key
    {
        public string username;
    }
    class Value
    {
        public int hashpassword;
        public string emailAdress;
        public Date lastLoginDate;
    }
    class Entry
    {
        public Key key;
        public Value value;
    }
}
