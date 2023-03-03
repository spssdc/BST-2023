using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace BST
{
    public class Tree
    {
        // Tree has a root, initially null.
        Node RootPtr;

        // Internal node class hidden from external code, only visible in Tree
        internal class Node
        {
            public string Data { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }

            public Node(string Value)
            {
                this.Data = Value;
                this.Left = null;
                this.Right = null;
            }
        }

        // Tree initialised as a null root value
        public Tree()
        {
            this.RootPtr = null;
        }

        // public facing Insert method takes one value
        public void Insert(string value)
        {
            // call internal private method, overloading the Insert with 2 parameters
            if (this.RootPtr == null)
            {
                this.RootPtr = new Node(value);
            }
            else
            {
                Insert(value, this.RootPtr);
            }
        }
        private void Insert(string value, Node Current)
        {
            int compareTo = value.CompareTo(Current.Data);
            if (compareTo < 0)  // Left
            {
                if (Current.Left == null)
                {
                    Node newNode = new Node(value);
                    Current.Left = newNode;
                }
                else
                {
                    Insert(value, Current.Left);
                }
            }
            else if (compareTo > 0) // Right
            {
                if (Current.Right == null)
                {
                    Node newNode = new Node(value);
                    Current.Right = newNode;
                }
                else
                {
                    Insert(value, Current.Right);
                }
            }

        }

        public  void Delete(string value)
        {
            Node Current = this.RootPtr;
            Node Previous = null;
            while (Current != null && Current.Data != value)
            {
                Previous = Current;
                if (value.CompareTo(Current.Data) < 0) // Left
                {
                    Current = Current.Left;
                }
                else
                {
                    Current = Current.Right;
                }
            }
            if (Current == null)  // item to Delete not found
            {
                Console.WriteLine("Not found");
            }
            else // Delete node
            {
                // Case 1: node to Delete is a leaf node
                if (Current.Left == null && Current.Right == null)
                {
                    if (Current.Data.CompareTo(Previous.Data) < 0) // Left leaf
                    {
                        Previous.Left = null;
                    }
                    else
                    {
                        Previous.Right = null;
                    }
                }
                // Case 2a: Node to Delete has a single child node
                // single Right child of Current (as Left is null)
                else if (Current.Left == null) 
                {
                    // Current node to Delete is < Previous, so Left of Previous
                    if (Current.Data.CompareTo(Previous.Data) < 0) // Left of parent
                    {
                        Previous.Left = Current.Right;
                    }
                    // Current node to Delete is > Previous, so Right of Previous
                    else
                    {
                        Previous.Right = Current.Right;
                    }
                }
                // Case 2b: Node to Delete has a single child node
                // single Right child of Current (as Left is null)
                else if (Current.Right == null) // single Left child
                {
                    // Current node to Delete is < Previous, so Left of Previous
                    if (Current.Data.CompareTo(Previous.Data) < 0) // Left of parent
                    {
                        Previous.Left = Current.Left;
                    }
                    // Current node to Delete is > Previous, so Right of Previous
                    else
                    {
                        Previous.Right = Current.Left;
                    }
                }
                // Case 3: 2 child nodes
                // Locate the Successor (next largest) node
                else
                {
                    Node Successor = Current.Right;
                    Previous = Current;
                    while (Successor.Left != null)
                    {
                        Previous = Successor;
                        Successor = Successor.Left;
                    }
                    // Is Successor a leaf? If so, straight replace
                    if (Successor.Right == null)
                    {
                        Current.Data = Successor.Data;
                        Previous.Left = null;
                    }
                    // There is a Right subtree, so link Previous to Right child
                    else
                    {
                        Current.Data = Successor.Data;
                        Previous.Left = Successor.Right;
                    }
                }
            }
        }

        public bool Find(string value)
        {
            return Find(value, this.RootPtr);
        }
        private bool Find(string value, Node Current)
        {
            if (Current == null)
            {
                return false;
            }
            else
            {
                if (value.CompareTo(Current.Data) == 0) // Equal
                {
                    return true;
                }
                else if (value.CompareTo(Current.Data) < 0)  // Left
                {
                    return Find(value, Current.Left);
                }
                else if (value.CompareTo(Current.Data) > 0) // Right
                {
                    return Find(value, Current.Right);
                }
            }
            return false;
        }

        public int Count()
        {
            return Count(this.RootPtr);
        }
        private int Count(Node Current)
        {
            if (Current == null)
            {
                return 0;
            }
            else
            {
                return 1 + Count(Current.Left) + Count(Current.Right);
            }
        }
        
        public int Depth()
        {
            return Depth(this.RootPtr);
        }
        private int Depth(Node Current)
        {
            if (Current == null)
            {
                return 0;
            }
            else
            {
                return 1 + Math.Max(Depth(Current.Left), Depth(Current.Right));
            }
        }

        public void InOrder()
        {
            InOrder(this.RootPtr);
        }
        private void InOrder(Node Current)
        {
            if (Current != null)
            {
                InOrder(Current.Left);
                Console.WriteLine(Current.Data);
                InOrder(Current.Right);
            }
        }

        public void BFS()
        {
            if (this.RootPtr != null){
                BFS(this.RootPtr);
            }
        }
        private void BFS(Node Current)
        {
            Queue<Node> Q = new Queue<Node>();
            while (Current != null) { 
                Console.WriteLine(Current.Data);
                if (Current.Left != null)
                {
                    Q.Enqueue(Current.Left);
                }
                if (Current.Right != null)
                {
                    Q.Enqueue(Current.Right);
                }
                // Use TryDequeue to test for values in queue
                if (!Q.TryDequeue(out Current))
                {
                    Current = null;
                }

            }
        }

    }
}