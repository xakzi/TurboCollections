using System;
using System.Collections.Generic;

namespace CustomerManagement
{
    class Program
    {
        static Dictionary<string, int> names = new Dictionary<string, int>();
        static void Main(string[] args)
        {
            Insert("Marc", 31);
            Insert("Laura", 27);
            Insert("Otto", 25);
            Insert("Marc", 32);
            Console.WriteLine("-------");
            Delete("Laura");
            Delete("Laura");
            Console.WriteLine("-------");
            Search("Marc");
            Search("Otto");
            Search("Laura");


            names["Marc"] = 31;
            int age = names["Otto"];
            names.Remove("Marc");

            string[] arr = new string[4];
            arr[0] = "Marc";
            string name = arr[0];
        }

        static void Insert(string name, int age)
        {
            Console.WriteLine($"Inserting '{name}:{age}'");
            names[name] = age; // Replace
            // names.Add(name, age); // Throws Exception if Key already exists
            Print();
        }
        
        static void Search(string name)
        {
            Console.WriteLine($"Result of searching '{name}': Found Value: {names.TryGetValue(name, out int age)} - Value: {age}");
            Print();
        }
        
        static void Delete(string name)
        {
            Console.WriteLine($"Result of deleting '{name}': {names.Remove(name)}");
            Print();
        }
        
        static void Print()
        {
            Console.WriteLine($"Collection: {string.Join(", ", names)} ({names.Count})");
        }
    }
}
