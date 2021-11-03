using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure.Ch10_1_StacksAndQueues
{
    public class Queue
    {
        private int[] _A;
        private int _tail;
        private int _head;

        public Queue(int capablity)
        {
            _A = new int[capablity];
        }

        public void Enqueue(int x)
        {
            _A[_tail] = x;
            if (_tail == _A.Length - 1)
            {
                _tail = 0;
            }
            else
            {
                _tail++;
            }
        }

        public int Dequeue()
        {
            int x = _A[_head];
            if (_head == _A.Length - 1)
            {
                _head = 0;
            }
            else
            {
                _head++;
            }
            return x;
        }
    }
}
