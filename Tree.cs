﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BST
{
    class Tree
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

        // Tree initiallt has a null root value
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
    }
}