using System;

namespace BST
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Tree cities = new Tree();
            cities.insert("London");
            cities.insert("Inverness");
            cities.insert("Manchester");
            cities.insert("York");
            cities.insert("Brighton");
            cities.inOrder();
            string x = Console.ReadLine();
            if (cities.find("York")){
                Console.WriteLine("York is present");
            }
            if (cities.find("Instanbul"))
            {
                Console.WriteLine("Istanbul is present");
            }
            else
            {
                Console.WriteLine("Istanbul is NOT present");
            }
            Console.WriteLine("BFS");
            cities.BFS();
        }
    }
}
