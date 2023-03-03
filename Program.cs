using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Text;

namespace BST
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("TREE class testing");
            //                             London
            //                Inverness               Manchester
            //        BRighton          Kingston                     York
            //   Aberdeen  Bristol   Keswick   Leicester
            Tree Cities = new Tree();
            Cities.Insert("London");
            Cities.Insert("Inverness");
            Cities.Insert("Manchester");
            Cities.Insert("York");
            Cities.Insert("BRighton");
            Cities.Insert("Aberdeen");
            Cities.Insert("Bristol");
            Cities.Insert("Kingston");
            Cities.Insert("Keswick");
            Cities.Insert("Leicester");
            Cities.Delete("Inverness");
            Console.WriteLine("\nMax depth: "+Cities.Depth()+"\n");
            Console.WriteLine("\nNum nodes: " + Cities.Count() + "\n");
            Console.WriteLine("\nInOrder Traversal\n");
            Cities.InOrder();
            if (Cities.Find("York")){
                Console.WriteLine("York is present");
            }
            if (Cities.Find("Instanbul"))
            {
                Console.WriteLine("Istanbul is present");
            }
            else
            {
                Console.WriteLine("Istanbul is NOT present");
            }
            Console.WriteLine("\nBFS\n");
            Cities.BFS();
        }
    }
}
