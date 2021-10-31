using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH6_SortingAndOrderStatistics.Ch6_2_MaintainingTheHeapProperty
{
    public class Heap
    {
        private int[] _A;
        private int _heapSize;

        public Heap(int capability)
        {
            _heapSize = 0;
            _A = new int[capability];
        }

        public Heap(int[] A)
        {
            _heapSize = A.Length;
            _A = new int[A.Length * 2];
            for (int i = 0; i < A.Length; i++)
            {
                _A[i] = A[i];
            }
            BuildMaxHeap(this._A);
        }

        public int this[int i]
        {
            get => _A[i];
            set => _A[i] = value;
        }

        public int Maximum()
        {
            return _A[0];
        }

        public int ExtractMax()
        {
            if (_heapSize < 1)
            {
                throw new Exception("heap underflow");
            }

            int max = _A[0];
            _A[0] = _A[_heapSize - 1];
            _heapSize--;
            MaxHeapify(_A, 0, _heapSize);

            return max;
        }

        private void IncreaseKey(int i, int key)
        {
            if (key < _A[i])
            {
                throw new Exception("new key is smaller than current key!");
            }

            _A[i] = key;
            while (i > 0 && _A[ParentIndex(i)] < _A[i]) {
                int temp = _A[i];
                _A[i] = _A[ParentIndex(i)];
                _A[ParentIndex(i)] = temp;
                i = ParentIndex(i);
            }
        }

        public void Insert(int key)
        {
            if (_heapSize == _A.Length)
            {
                throw new Exception("heap overflow");
            }
            _heapSize++;
            _A[_heapSize - 1] = key;
            IncreaseKey(_heapSize - 1, key);
        }

        public void Delete(int i)
        {
            IncreaseKey(i, int.MaxValue);
            ExtractMax();
        }

        public static void MaxHeapify(int[] A, int i, int heapSize)
        {
            int maxIndex = i;
            int rightIndex = RightChildIndex(i);
            int leftIndex = LeftChildIndex(i);
            if (leftIndex < heapSize && A[leftIndex] > A[i])
            {
                maxIndex = leftIndex;
            }
            if (rightIndex < heapSize && A[rightIndex] > A[maxIndex])
            {
                maxIndex = rightIndex;
            }

            if (i != maxIndex)
            {
                // swap the value of ith node and the maxIndex node
                int temp = A[i];
                A[i] = A[maxIndex];
                A[maxIndex] = temp;

                MaxHeapify(A, maxIndex, heapSize);
            }
        }

        public static void BuildMaxHeap(int[] A)
        {
            for (int i = A.Length / 2; i >= 0; i--)
            {
                MaxHeapify(A, i, A.Length);
            }
        }

        public static void HeapSort(int[] A)
        {
            int heapSize = A.Length;
            BuildMaxHeap(A);
            for (int i = A.Length - 1; i > 0; i--)
            {
                // swap: put root to the right position
                int temp = A[i];
                A[i] = A[0];
                A[0] = temp;

                // decrease heap size by 1 and re-heapify at the root node
                MaxHeapify(A, 0, --heapSize);
            }
        }

        public static int ParentIndex(int i)
        {
            return (i - 1) / 2;
        }

        public static int LeftChildIndex(int i)
        {
            return i * 2 + 1;
        }

        public static int RightChildIndex(int i)
        {
            return i * 2 + 2;
        }
    }
}
