using System;
using System.Diagnostics.CodeAnalysis;
using _02.BinarySearchTree;
using _03.MaxHeap;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new BinarySearchTree<int>();
            tree.Insert(5);
            tree.Insert(6);
            tree.Insert(1);
            tree.Insert(2);
            tree.Insert(0);
        }

        
    }

}