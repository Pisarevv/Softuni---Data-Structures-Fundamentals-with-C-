namespace Problem02.DoublyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class DoublyLinkedList<T> : IAbstractLinkedList<T>
    {
        public class Node
        {
            public T value { get; set; }
            public Node next { get; set; }
            public Node previous { get; set; }

            public Node(T value)
            {
                this.value = value;
            }
        }

        private Node head;
        private Node tail;


        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            if (this.head == null)
            {
                Node newNode = new Node(item);
                this.head = newNode;
                this.tail = newNode;
            }
            else
            {
                Node oldHead = this.head;
                Node newHead = new Node(item);
                oldHead.previous = newHead;
                newHead.next = oldHead;
                head = newHead;
            }
            this.Count++;
        }

        public void AddLast(T item)
        {
            if (this.tail == null)
            {
                Node newNode = new Node(item);
                this.head = newNode;
                this.tail = newNode;
            }
            else
            {
                Node newTail = new Node(item);
                Node oldTail = this.tail;
                this.tail.next = newTail;
                newTail.previous = oldTail;
                tail = newTail;
            }
           this.Count++;
        }

        public T GetFirst()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }
            else
            {
                return this.head.value;
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
                return this.tail.value;
            }
        }

        public T RemoveFirst()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }
            if (this.Count == 1)
            {
                var oldTail = this.tail;
                this.head = null;
                this.tail = null;
                this.Count--;
                return oldTail.value;
            }
            else
            {
                var oldHead = this.head;
                this.head = this.head.next;
                this.head.previous = null;
                this.Count--;
                return oldHead.value;
            }
        }

        public T RemoveLast()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }
            if(this.Count == 1)
            {
                var oldTail = this.tail;
                this.head = null;
                this.tail = null;
                this.Count--;
                return oldTail.value;
            }
            else
            {
                var oldTail = this.tail;
                this.tail = this.tail.previous;
                this.tail.next = null;
                this.Count--;
                return oldTail.value;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            var currentNode = this.head;
            for(int i = 0; i < this.Count; i++)
            {
                yield return currentNode.value;
                currentNode = currentNode.next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()=> this.GetEnumerator();
    }
}