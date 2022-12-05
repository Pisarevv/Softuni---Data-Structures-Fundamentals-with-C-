namespace Problem02.Stack
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Stack<T> : IAbstractStack<T>
    {
        private class Node
        {
            private T value;
            private Node next;

            public T Value { get => this.value; set => this.value = value; }
            public Node Next { get => this.next; set => this.next = value; }

            public Node(T value)
            {
                this.Value = value; 
                this.Next = null;
            }


            public Node(T value, Node next)
            {
                this.Value = value;
                this.Next = next;
            }
            
        }

        private Node top;

        public int Count { get; set; }

        public void Push(T item)
        {
            Node newNode = new Node(item);
            if(this.top == null)
            {
                this.top = newNode;
            }
            else
            {
                var oldNode = top;
                this.top = newNode;
                this.top.Next = oldNode;
            }
            this.Count++;
        }

        public T Pop()
        {
            if(this.Count > 0)
            {
                var oldTop = top;
                this.top = oldTop.Next;
                this.Count--;
                return oldTop.Value;
            }
            else
            {
                throw new InvalidOperationException("Structure is empty");
            }
            
        }

        public T Peek()
        {
            if(this.Count > 0)
            {
                return this.top.Value;
            }
            else
            {
                throw new InvalidOperationException("Stack is empty");
            }
           
        }

        public bool Contains(T item)
        {
            if(this.Count > 0)
            {
                var currentNode = this.top;
                if(this.Count == 1)
                {
                    if (item.Equals(currentNode.Value))
                    {
                        return true;
                    }
                }
                else
                {
                    while (currentNode.Next != null)
                    {
                        if (item.Equals(currentNode.Value))
                        {
                            return true;
                        }
                        currentNode = currentNode.Next;
                    }
                }
               
            }

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var currentNode = this.top;
            while (true)
            {
                if(currentNode.Next != null)
                {
                    yield return currentNode.Value;
                    currentNode = currentNode.Next;
                }
                else
                {
                    yield return currentNode.Value;
                    break;
                }
             
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
       
    }
}