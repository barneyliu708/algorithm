using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    public class LC255VerifyPreorderSequenceInBinarySearchTree
    {
        public bool VerifyPreorder(int[] preorder)
        {

            int low = int.MinValue;
            Stack<int> stack = new Stack<int>();

            foreach (int cur in preorder)
            {

                if (cur < low)
                {
                    return false;
                }

                while (stack.Count != 0 && cur > stack.Peek())
                {
                    low = stack.Pop();
                }

                stack.Push(cur);

            }

            return true;
        }
    }
}
