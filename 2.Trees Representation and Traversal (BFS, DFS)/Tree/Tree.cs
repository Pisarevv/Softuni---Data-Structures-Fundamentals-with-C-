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
            var parentNode = this.FindNodeWithBfs(parentKey);
            if (parentNode != null)
            {
                parentNode.children.Add(child);
                child.parent = parentNode;
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        private Tree<T> FindNodeWithBfs(T parentKey)
        {
            var queue = new Queue<Tree<T>>();
            queue.Enqueue(this);
            while (queue.Count > 0)
            {
                var currNode = queue.Dequeue();
                if(currNode.value.Equals(parentKey))
                {
                    return currNode;
                }
                foreach (var child in currNode.children)
                {
                    queue.Enqueue(child);
                }
            }
            return null;
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
            var nodeForDeleting = FindNodeWithBfs(nodeKey);
            if (nodeForDeleting == null)
            {
                throw new ArgumentNullException();
            }
            else if(nodeForDeleting.parent == null)
            {
                throw new ArgumentException();
            }

            else 
            {
                var parentNode = nodeForDeleting.parent;
                parentNode.children.Remove(nodeForDeleting);
            }

        }

        public void Swap(T firstKey, T secondKey)
        {
            var firstNode = FindNodeWithBfs(firstKey); 
            var secondNode = FindNodeWithBfs(secondKey);
            if (firstNode == null || secondNode == null)
            {
                throw new ArgumentNullException();
            }
            var firstParent = firstNode.parent;
            var secondParent = secondNode.parent;
            if (firstParent == null || secondParent == null)
            {
                throw new ArgumentException();
            }

            var indexOfFirstChild = firstParent.children.IndexOf(firstNode);
            var indexOfSecondChild = secondParent.children.IndexOf(secondNode);

            firstParent.children[indexOfFirstChild] = secondNode;
            secondParent.children[indexOfSecondChild] = firstNode;

            secondNode.parent = firstParent;
            firstNode.parent = secondParent;

            
        }
    }
}
