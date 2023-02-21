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
        }
    }
}
