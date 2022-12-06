namespace Problem01.CircularQueue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class CircularQueue<T> : IAbstractQueue<T>
    {
        private T[] elements;

        private int startIndex;
        private int endIndex;

        public CircularQueue(int size = 4)
        {
            this.elements = new T[size];
        }
        public int Count { get; set; }

        public T Dequeue()
        {
            if(this.Count == 0)
            {
                throw new InvalidOperationException();
            }
            else
            {
                var element = this.elements[startIndex];
                this.elements[startIndex] = default(T);
                this.startIndex = (startIndex + 1) % this.elements.Length;
                this.Count--;
                return element;
            }
        }

        public void Enqueue(T item)
        {
            if(this.Count == this.elements.Length)
            {
                this.Grow();
            }
            
            this.elements[this.endIndex] = item; 
            this.endIndex = (this.endIndex + 1) % this.elements.Length; 
            this.Count++;
            
        }

        private void Grow()
        {
            this.elements = this.CopyElements(new T[this.elements.Length*2]);
            this.startIndex = 0;
            this.endIndex = this.Count;
        }

        private T[] CopyElements(T[] resultArr)
        {
            for(int i = 0; i < this.Count; i++)
            {
                resultArr[i] = this.elements[(this.startIndex + i) % this.elements.Length];
            }

            return resultArr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for(int i = 0; i < this.Count; i++)
            {
                yield return this.elements[(this.startIndex + i) % this.elements.Length];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        public T Peek()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }
            else
            {
                return this.elements[this.startIndex];
            }
            
        }

        public T[] ToArray()
        {
            return this.CopyElements(new T[this.Count]);
        }

        
    }

}
