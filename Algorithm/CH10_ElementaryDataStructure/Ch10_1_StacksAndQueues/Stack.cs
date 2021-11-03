using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure.Ch10_1_StacksAndQueues
{
    public class Stack
    {
        private int[] _A;
        private int _top;

        public Stack(int capability)
        {
            _A = new int[capability];
            _top = -1;
        }

        public bool IsEmpty()
        {
            return _top == -1;
        }

        public void Push(int x)
        {
            _top++;
            _A[_top] = x;
        }

        public int Pop()
        {
            if (IsEmpty())
            {
                throw new Exception("underflow");
            }

            _top--;
            return _A[_top + 1];
        }
    }
}
