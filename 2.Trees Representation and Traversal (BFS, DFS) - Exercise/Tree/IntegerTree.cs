namespace Tree
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class IntegerTree : Tree<int>, IIntegerTree
    {
        public IntegerTree(int key, params Tree<int>[] children)
            : base(key, children)
        {
        }

        public IEnumerable<IEnumerable<int>> GetPathsWithGivenSum(int sum)
        {
            var result = new List<List<int>>();
            var currentPath = new LinkedList<int>();
            currentPath.AddFirst(this.Key);
            int currentSum = this.Key;
            var node = this;
            Dfs(node, result, currentPath, sum, ref currentSum);

            return result;
        }

        private void Dfs(Tree<int> subtree, List<List<int>> result, LinkedList<int> currentPath, int wantedSum, ref int currentSum){

           foreach(var child in subtree.Children )
            {
                currentSum += child.Key;
                currentPath.AddLast(child.Key);
                this.Dfs(child, result, currentPath, wantedSum, ref currentSum);
            }
           if(currentSum== wantedSum)
            {
                result.Add(new List<int>(currentPath));
            }
            currentSum -= subtree.Key;
            currentPath.RemoveLast();
        }
        public IEnumerable<Tree<int>> GetSubtreesWithGivenSum(int sum)
        {
            var subtrees = GetAllNodesBFS(this);
            var result = new List<Tree<int>>();

            foreach(var tree in subtrees)
            {
                if (HasGivenSum(tree, sum))
                {
                    result.Add(tree);
                }
            }
            return result;
        }


        private bool HasGivenSum(Tree<int> subtree, int wantedSum)
        {
            int actuallSum = subtree.Key;

            this.DFSSubtreeSum(subtree, wantedSum, ref actuallSum);
            return actuallSum == wantedSum;
        }

        private void DFSSubtreeSum(Tree<int> subtree, int wantedSum, ref int actuallSum)
        {
            foreach(var child in subtree.Children)
            {
                actuallSum+= child.Key;
                DFSSubtreeSum(child, wantedSum, ref actuallSum);
            }
        }

        private List<Tree<int>> GetAllNodesBFS(Tree<int> node)
        {
            var queue = new Queue<Tree<int>>();
            var result = new List<Tree<int>>();
            queue.Enqueue(node);

            while(queue.Count > 0)
            {
                var currentNode = queue.Dequeue();
                result.Add(currentNode);
                foreach(var child in currentNode.Children)
                {
                    queue.Enqueue(child);
                }
               
            }

            return result;
            
        }
    }
}
