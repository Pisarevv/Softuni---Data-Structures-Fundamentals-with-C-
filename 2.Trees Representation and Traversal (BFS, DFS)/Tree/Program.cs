﻿namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Program
    {
        public static void Main(string[] args)
        {

            var tree = new Tree<int>(34,
                           new Tree<int>(36,
                             new Tree<int>(42),
                             new Tree<int>(3,
                                    new Tree<int>(78))
                             ),
                           new Tree<int>(1),
                           new Tree<int>(103)
                           );

             Console.WriteLine(string.Join((", "), tree.OrderDfs()));
        }
    }
}
