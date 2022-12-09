namespace Tree
{
    using System;
    using System.Collections.Generic;

    public class Tree<T> : IAbstractTree<T>
    {
        private List<Tree<T>> children;
        private T value;
        private Tree<T> parent;

        public Tree(T value)
        {
            this.value = value;
            this.children = new List<Tree<T>>();
        }

        public Tree(T value, params Tree<T>[] children)
            : this(value)
        {
            this.value=value;
            foreach( Tree<T> child in children)
            {
                child.parent = this;
                this.children.Add(child);

            }
        }

        public void AddChild(T parentKey, Tree<T> child)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> OrderBfs()
        {
            var result = new List<T>();
            var queue = new Queue<Tree<T>>();
            queue.Enqueue(this);
            while (queue.Count > 0)
            {
                var currNode = queue.Dequeue();
                result.Add(currNode.value);
                foreach(var child in currNode.children)
                {
                    queue.Enqueue(child);
                }
            }
            return result;

            
        }

        private void Dfs(Tree<T> node, ICollection<T> result)
        {
            foreach(var child in node.children)
            {
                this.Dfs(child, result);
            }
            result.Add(node.value);
        }

        public IEnumerable<T> OrderDfs()
        {
           var list = new List<T>();
           this.Dfs(this, list);
           return list;
        }

        private IEnumerable<T> DfsWithStack()
        {
            var result = new Stack<T>();
            var stack = new Stack<Tree<T>>();
            stack.Push(this);
            while (stack.Count > 0)
            {
                var node = stack.Pop();
                foreach (var child in node.children)
                {
                    stack.Push(child);
                }
                result.Push(node.value);
            }

            return result;
        }

        public void RemoveNode(T nodeKey)
        {
            throw new NotImplementedException();
        }

        public void Swap(T firstKey, T secondKey)
        {
            throw new NotImplementedException();
        }
    }
}
