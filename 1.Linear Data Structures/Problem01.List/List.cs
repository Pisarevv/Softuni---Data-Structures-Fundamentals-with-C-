namespace Problem01.List
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class List<T> : IAbstractList<T>
    {
        private const int DEFAULT_CAPACITY = 4;
        private T[] items;

        public List()
            : this(DEFAULT_CAPACITY) {
        }

        public List(int capacity = DEFAULT_CAPACITY)
        {
            if(capacity < 0)
            {
                throw new ArgumentOutOfRangeException("Capacity cannot be negative!");
            }
            this.items = new T[capacity];
        }

        public T this[int index] {
            get
            {
                if (CheckIndex(index))
                {
                    return items[index];
                }
                else
                {
                    return default(T);
                }
            }
            set
            {
                if (CheckIndex(index))
                {
                    items[index] = value;
                }
            }
        }

        public int Count { get; private set; }

        public void Add(T item)
        {
            if (this.items.Length == this.Count)
            {
                Grow();
            }
            this.items[this.Count++] = item;
        }

        public bool Contains(T item)
        {
            for(int i = 0; i < this.Count; i++)
            {
                if (item.Equals(this.items[i]))
                {
                    return true;
                }
                   
            }
            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for(int i = 0; i < this.Count; i++)
                yield return this.items[i];
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (item.Equals(this.items[i]))
                {
                    return i;
                }

            }
            return -1;
        }

        public void Insert(int index, T item)
        {
            if (CheckIndex(index))
            {
                if (this.items.Length == this.Count)
                {
                    Grow();
                }

                for (var i = this.Count; i > index; i--)
                {
                    this.items[i] = this.items[i - 1];
                }
                this.items[index] = item;
                this.Count++;
            }
        }

        public bool Remove(T item)
        {
            int indexOfItem = this.IndexOf(item);
            if(indexOfItem != -1)
            {
                this.RemoveAt(indexOfItem);
                return true;
            }
            return false;
        }

        public void RemoveAt(int index)
        {
            if (CheckIndex(index))
            {
                for(var i = index; i < this.Count; i++)
                {
                    this.items[i] = this.items[i + 1];
                }
                this.items[this.Count - 1] = default(T);
                this.Count--;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private bool CheckIndex(int index)
        {
            if(index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException("Index is outside the bounds of the list");
            }
            else
            {
                return true;
            }
        }

        private void Grow()
        {
            T[] copyArray = new T[this.items.Length * 2];
            Array.Copy(this.items,copyArray,this.Count);
            this.items = copyArray;
        }
    }
}