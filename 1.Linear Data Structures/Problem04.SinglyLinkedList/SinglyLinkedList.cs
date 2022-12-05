namespace Problem04.SinglyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class SinglyLinkedList<T> : IAbstractLinkedList<T>
    {
        private Node top;

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

        public int Count { get; set; }

        public void AddFirst(T item)
        {
            Node newNode = new Node(item);
            if(this.top == null)
            {
                top = newNode;
            }
            else
            {
                Node oldNode = this.top;
                this.top = newNode;
                newNode.Next = oldNode;
            }
            this.Count++;
        }

        public void AddLast(T item)
        {
            Node newNode = new Node(item);
            if (this.top == null)
            {
                top = newNode;
            }
            else
            {
                Node currentNode = this.top;
                while(currentNode.Next != null)
                {
                    currentNode = currentNode.Next;
                }
                currentNode.Next = newNode;
            }
            this.Count++;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node currentNode = this.top;
            while(currentNode != null)
            {
                yield return currentNode.Value;
                currentNode = currentNode.Next;
            }
        }

        public T GetFirst()
        {
            if(this.Count == 0)
            {
                throw new InvalidOperationException();
            }
            else
            {
                return this.top.Value;
            }
        }

        public T GetLast()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }
            else
            {
                Node currentNode = this.top;
                while(currentNode.Next != null)
                {
                    currentNode = currentNode.Next;
                }
                return currentNode.Value;
            }
        }

        public T RemoveFirst()
        {
            if(this.Count == 0)
            {
                throw new InvalidOperationException();
            }
            else
            {
                Node oldNode = this.top;
                this.top = oldNode.Next;
                this.Count--;
                return oldNode.Value;
            }
           
        }

        public T RemoveLast()
        {

            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }
            else if(this.Count == 1)
            {
                Node nodeToDelete = this.top;
                this.top = null;
                this.Count--;
                return nodeToDelete.Value;

            }
            else
            {
                Node currentNode = this.top;
                while ( currentNode.Next.Next != null)
                {
                    currentNode = currentNode.Next;
                }
                Node nodeToDelete = currentNode.Next;
                currentNode.Next = null;
                this.Count--;
                return nodeToDelete.Value;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
       

    }
}