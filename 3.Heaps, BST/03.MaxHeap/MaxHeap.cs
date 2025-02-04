﻿namespace _03.MaxHeap
{
    using System;
    using System.Collections.Generic;

    public class MaxHeap<T> : IAbstractHeap<T> where T : IComparable<T>
    {
        private List<T> elements;

        public int Size => this.elements.Count;

        public T Peek() => this.elements.Count > 0 ? this.elements[0] : throw new InvalidOperationException();   
        public MaxHeap()
        {
            this.elements = new List<T>();
        }

        public void Add(T element)
        {
            this.elements.Add(element);
            this.HeapifyUp(this.elements.Count - 1);
        }

        private void HeapifyUp(int index)
        {
            int parentIndex = GetParentIndex(index);
            while(parentIndex >= 0 && IsGreater(index,parentIndex))
            {
                Swap(index,parentIndex);
                index = parentIndex;
                parentIndex = GetParentIndex(index);
            }

        }

        private void Swap(int index , int parentIndex)
        {
            var temp = this.elements[parentIndex];
            this.elements[parentIndex] = this.elements[index];
            this.elements[index] = temp;
        }

        private int GetParentIndex(int index)
        {
            return (index - 1) / 2;
        }

        private bool IsGreater(int index, int parentIndex)
        {
            return this.elements[index].CompareTo(this.elements[parentIndex]) > 0;
        }

        public T ExtractMax()
        {
            if(this.elements.Count == 0)
            {
                throw new InvalidOperationException();
            }

            T element = this.elements[0]; 
            Swap(0, this.elements.Count - 1);
            this.elements.RemoveAt(this.elements.Count-1);

            HeapifyDown(0);

            return element;
        }

        private void HeapifyDown(int index)
        {
            var biggerChildIndex = this.GetBiggerChildIndex(index);
            while(isIndexValid(biggerChildIndex)  && IsGreater(biggerChildIndex,index))
            {
                this.Swap(biggerChildIndex, index);
                index = biggerChildIndex;
                biggerChildIndex = this.GetBiggerChildIndex(index); 
            }
        }

        private bool isIndexValid(int index)
        {
            return index > 0 && index < this.elements.Count;
        }

        private int GetBiggerChildIndex(int index)
        {
            var leftChildIndex = index * 2 + 1;
            var rightChildIndex = index * 2 + 2;

            if(rightChildIndex < this.elements.Count)
            {
                if(this.IsGreater(leftChildIndex,rightChildIndex))
                {
                    return leftChildIndex;
                }
                return rightChildIndex;
            }
            else if(leftChildIndex< this.elements.Count)
            {
                return leftChildIndex;
            }
            else
            {
                return -1;
            }
        }
    }
}
