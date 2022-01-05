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

        public bool VerifyPreorder_Recursion(int[] preorder)
        {
            return helper(preorder, 0, preorder.Length - 1, int.MinValue, int.MaxValue);
        }

        private bool helper(int[] preorder, int li, int ri, int lower, int upper)
        {

            if (li > ri)
            {
                return true;
            }

            int curValue = preorder[li];

            if (curValue < lower || curValue > upper)
            {
                return false;
            }

            int i;
            for (i = li + 1; i <= ri; i++)
            {
                if (preorder[i] >= curValue)
                {
                    break;
                }
            }

            return helper(preorder, li + 1, i - 1, lower, curValue) &&
                   helper(preorder, i, ri, curValue, upper);

        }
    }
}
