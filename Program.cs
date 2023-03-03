using System;
using System.Collections.Generic;
using System.Text;

namespace BST
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("TREE class testing");
            //                   London
            //            Inverness   Manchester
            //        Brighton             York
            //   Aberdeen   Bristol
            Tree cities = new Tree();
            cities.insert("London");
            cities.insert("Inverness");
            cities.insert("Manchester");
            cities.insert("York");
            cities.insert("Brighton");
            cities.insert("Aberdeen");
            cities.insert("Bristol");
            Console.WriteLine("\nMax depth: "+cities.maxDepth()+"\n");
            Console.WriteLine("\nNum nodes: " + cities.Count() + "\n");
            Console.WriteLine("\nInorder Traversal\n");
            cities.inOrder();
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
            Console.WriteLine("\nBFS\n");
            cities.BFS();
        }
    }
}
