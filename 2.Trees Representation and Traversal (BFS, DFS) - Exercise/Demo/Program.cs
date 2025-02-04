﻿namespace Demo
{
    using System;
    using System.Linq;
    using Tree;

    class Program
    {
        static void Main(string[] args)
        {
           
            var input = new string[] { "9 17", "9 4", "9 14", "4 36", "14 53", "14 59", "53 67", "53 73" };
            var treeFactory = new IntegerTreeFactory();

            var tree = treeFactory.CreateTreeFromStrings(input);
            Console.WriteLine(tree.AsString());
            Console.WriteLine(String.Join(", ", tree.GetLeafKeys()));
            Console.WriteLine(String.Join(", ", tree.GetInternalKeys()));
            Console.WriteLine(String.Join(", ", tree.GetDeepestKey()));
            Console.WriteLine(String.Join(", ", tree.GetLongestPath()));
            
        }
    }
}
