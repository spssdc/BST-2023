using System;
using System.Collections.Generic;
using System.Text;

namespace BST
{
    public class Tree
    {
        // Tree has a root, initially null.
        Node rootPtr;

        // Internal node class hidden from external code, only visible in Tree
        internal class Node
        {
            public string data { get; set; }
            public Node left { get; set; }
            public Node right { get; set; }

            public Node(string Value)
            {
                this.data = Value;
                this.left = null;
                this.right = null;
            }
        }

        // Tree initialised as a null root value
        public Tree()
        {
            this.rootPtr = null;
        }

        // public facing insert method takes one value
        public void insert(string value)
        {
            // call internal private method, overloading the insert with 2 parameters
            if (this.rootPtr == null)
            {
                this.rootPtr = new Node(value);
            }
            else
            {
                insert(value, this.rootPtr);
            }
        }
        private void insert(string value, Node current)
        {
            int compareTo = value.CompareTo(current.data);
            if (compareTo < 0)  // left
            {
                if (current.left == null)
                {
                    Node newNode = new Node(value);
                    current.left = newNode;
                }
                else
                {
                    insert(value, current.left);
                }
            }
            else if (compareTo > 0) // right
            {
                if (current.right == null)
                {
                    Node newNode = new Node(value);
                    current.right = newNode;
                }
                else
                {
                    insert(value, current.right);
                }
            }

        }

        public bool find(string value)
        {
            return find(value, this.rootPtr);
        }
        private bool find(string value, Node current)
        {
            if (current == null)
            {
                return false;
            }
            else
            {
                int compareTo = value.CompareTo(current.data);
                if (compareTo == 0)
                {
                    return true;
                }
                else if (compareTo < 0)  // left
                {
                    return find(value, current.left);
                }
                else if (compareTo > 0) // right
                {
                    return find(value, current.right);
                }
            }
            return false;
        }

        public int Count()
        {
            return Count(this.rootPtr);
        }
        private int Count(Node current)
        {
            if (current == null)
            {
                return 0;
            }
            else
            {
                return 1 + Count(current.left) + Count(current.right);
            }
        }

        public int maxDepth()
        {
            return maxDepth(this.rootPtr);
        }
        private int maxDepth(Node current)
        {
            if (current == null)
            {
                return 0;
            }
            else
            {
                return 1 + Math.Max(maxDepth(current.left), maxDepth(current.right));
            }
        }

        public void inOrder()
        {
            inOrder(this.rootPtr);
        }
        private void inOrder(Node current)
        {
            if (current != null)
            {
                inOrder(current.left);
                Console.WriteLine(current.data);
                inOrder(current.right);
            }
        }

        public void BFS()
        {
            if (this.rootPtr != null){
                BFS(this.rootPtr);
            }
        }
        private void BFS(Node current)
        {
            Queue<Node> q = new Queue<Node>();
            while (current != null) { 
                Console.WriteLine(current.data);
                if (current.left != null)
                {
                    q.Enqueue(current.left);
                }
                if (current.right != null)
                {
                    q.Enqueue(current.right);
                }
                // Use TryDequeue to test for values in queue
                if (!q.TryDequeue(out current))
                {
                    current = null;
                }

            }
        }

    }
}
