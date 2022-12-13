namespace Tree
{
    using System;
    using System.Collections.Generic;
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
            throw new NotImplementedException();
        }

        private void DfsKeys(List<T> result,Tree<T> currentSubtree,Predicate<Tree<T>> predicate)
        {
            if (predicate.Invoke(currentSubtree))
            {
                result.Add(currentSubtree.Key);
            }
            /*if(currentSubtree.children.Count == 0)
            {
                
            }*/
            foreach(var child in currentSubtree.children)
            {
                DfsKeys(result, child, predicate);
            }

        }

        public IEnumerable<T> GetLeafKeys()
        {
            var result = new List<T>();
            var node = this;
            Predicate<Tree<T>> predicate = currNode => currNode.children.Count == 0;
            DfsKeys(result, node, predicate);
            return result;
        }

        public T GetDeepestKey()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetLongestPath()
        {
            throw new NotImplementedException();
        }
    }
}
