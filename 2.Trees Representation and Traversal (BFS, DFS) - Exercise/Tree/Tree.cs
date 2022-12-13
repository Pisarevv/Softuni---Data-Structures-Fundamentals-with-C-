namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Tree<T> : IAbstractTree<T>
    {
        private List<Tree<T>> children;

        public Tree(T key, params Tree<T>[] children)
        {
            this.Key = key;
            this.children = new List<Tree<T>>();

            foreach(var child in children)
            {
                this.AddChild(child); 
            }
        }

        public T Key { get; private set; }

        public Tree<T> Parent { get; private set; }

        public IReadOnlyCollection<Tree<T>> Children => this.children.AsReadOnly();

        public void AddChild(Tree<T> child)
        {
            this.children.Add(child);
        }

        public void AddParent(Tree<T> parent)
        {
            this.Parent = parent;         
        }

        public string AsString()
        {
            var sb = new StringBuilder();

            this.DfsAsString(sb, this, 0);

            return sb.ToString().Trim();
        }

        private void DfsAsString(StringBuilder sb, Tree<T> tree, int indent)
        {
            sb.Append(' ', indent)
                .AppendLine(tree.Key.ToString());
                
            foreach(var child in tree.children)
            {
                this.DfsAsString(sb, child, indent + 2);
            }

        }

        public IEnumerable<T> GetInternalKeys()
        {
            var result = new List<Tree<T>>();
            var node = this;
            Predicate<Tree<T>> predicate = currNode => currNode.children.Count > 0 && currNode.Parent != null;
            DfsKeys(result, node, predicate);
            return result.Select(x => x.Key);
        }

        private void DfsKeys(List<Tree<T>> result,Tree<T> currentSubtree,Predicate<Tree<T>> predicate)
        {
            if (predicate.Invoke(currentSubtree))
            {
                result.Add(currentSubtree);
            }
            foreach(var child in currentSubtree.children)
            {
                DfsKeys(result, child, predicate);
            }

        }

        public IEnumerable<T> GetLeafKeys()
        {
            return GetLeafNodes().Select(x => x.Key);
        }

        private List<Tree<T>> GetLeafNodes()
        {
            var result = new List<Tree<T>>();
            var node = this;
            Predicate<Tree<T>> predicate = currNode => currNode.children.Count == 0;
            DfsKeys(result, node, predicate);
            return result;
        }

        public T GetDeepestKey()
        {
            int maxDepth = 0;
            int currentDepth = 0;
            Tree<T> deepestNode = null;
            var leafs = GetLeafNodes();

            foreach(var leaf in leafs)
            {
                currentDepth = this.GetDepth(leaf);
                if(currentDepth > maxDepth)
                {
                    maxDepth = currentDepth;
                    deepestNode = leaf;
                }
            }

            return deepestNode.Key;
        }
     

        private int GetDepth(Tree<T> leaf)
        {
            int depth = 0;
            var tree = leaf;
            while(tree.Parent != null)
            {
                depth++;
                tree = tree.Parent;
            }

            return depth;
        }

        public IEnumerable<T> GetLongestPath()
        {
            throw new NotImplementedException();
        }
    }
}
