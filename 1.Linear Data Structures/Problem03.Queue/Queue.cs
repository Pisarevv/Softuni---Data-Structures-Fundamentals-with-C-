namespace Problem03.Queue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Queue<T> : IAbstractQueue<T>
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

        private Node head;

        public int Count { get; set; }

        public void Enqueue(T item)
        {
            Node newNode = new Node(item);
            if (head == null)
            {
                head = newNode;
            }
            else
            {
                Node currentNode = head;
                while (currentNode.Next != null)
                {
                    currentNode = currentNode.Next;
                }
                currentNode.Next = newNode;
            }
            this.Count++;
          
        }

        public T Dequeue()
        {
            if(Count > 0)
            {
                Node oldHead = head;
                head = oldHead.Next;
                this.Count--;
                return oldHead.Value;
            }
            else
            {
                throw new InvalidOperationException("Queue is empty!");
            }
            
        }

        public T Peek()
        {
            if (Count > 0)
            {      
                return head.Value;
            }
            else
            {
                throw new InvalidOperationException("Queue is empty!");
            }
        }

        public bool Contains(T item)
        {
            var node = this.head;
            while(node != null)
            {
                if (item.Equals(node.Value))
                {
                    return true;
                }
                node = node.Next;
            }
            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var node = this.head;
            while(node != null)
            {
                yield return node.Value;
                node = node.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        
    }
}