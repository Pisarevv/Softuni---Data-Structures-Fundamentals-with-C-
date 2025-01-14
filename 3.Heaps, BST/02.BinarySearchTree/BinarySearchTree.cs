﻿namespace _02.BinarySearchTree
{
    using System;

    public class BinarySearchTree<T> : IBinarySearchTree<T>
        where T : IComparable<T>
    {
        public BinarySearchTree() { }

        private BinarySearchTree(Node node)
        {
            this.PreorderCopy(node);
        }

        private void PreorderCopy(Node node)
        {
            if (node == null)
            {
                return;
            }
            this.Insert(node.Value);
            this.PreorderCopy(node.Left);
            this.PreorderCopy(node.Right); 
        }

        private class Node
        {
            public Node(T Value)
            {
                this.Value = Value;
            }

            public T Value { get; private set; }
            public Node Left { get; set; }
            public Node Right { get; set; }
        }

        private Node root;

        public bool Contains(T element)
        {
            var searchedNode = this.FindNode(element);
            return searchedNode != null;
        }

        private Node FindNode(T element)
        {
            var node = this.root;
            while(node != null)
            {
                if (element.CompareTo(node.Value) < 0)
                {
                    node= node.Left;
                }
                else if (element.CompareTo(node.Value) > 0)
                {
                    node= node.Right;
                }
                else
                {
                    break;
                }
            }

            return node;
        }

        public void EachInOrder(Action<T> action)
        {
            this.EachInOrder(action, root);
        }

        private void EachInOrder(Action<T> action, Node node)
        {
            if(node == null)
            {
                return;
            }
            this.EachInOrder(action,node.Left);
            action.Invoke(node.Value);
            this.EachInOrder(action,node.Right);
        }

        public void Insert(T element)
        {
            this.root = this.Insert(element,this.root);
        }

        private Node Insert(T element,Node node)
        {
            if(node == null)
            {
                node = new Node(element);
            }
            else if (element.CompareTo(node.Value) < 0)
            {
                node.Left = this.Insert(element,node.Left);
            }
            else if (element.CompareTo(node.Value) > 0)
            {
                node.Right = this.Insert(element, node.Right);
            }

            return node;
        }

        public IBinarySearchTree<T> Search(T element)
        {
            var node = FindNode(element);

            if(node == null)
            {
                return null;
            }

            return new BinarySearchTree<T>(node);

        }
    }
}
