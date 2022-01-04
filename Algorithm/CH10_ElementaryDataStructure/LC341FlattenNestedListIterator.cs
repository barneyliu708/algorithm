using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    public class LC341FlattenNestedListIterator
    {
        // This is the interface that allows for creating nested lists.
        // You should not implement it, or speculate about its implementation
        public interface NestedInteger
        {

            // @return true if this NestedInteger holds a single integer, rather than a nested list.
            bool IsInteger();

            // @return the single integer that this NestedInteger holds, if it holds a single integer
            // Return null if this NestedInteger holds a nested list
            int GetInteger();

            // @return the nested list that this NestedInteger holds, if it holds a nested list
            // Return null if this NestedInteger holds a single integer
            IList<NestedInteger> GetList();
        }

        public class NestedIterator
        {

            private Stack<NestedInteger> stack;

            public NestedIterator(IList<NestedInteger> nestedList)
            {
                stack = new Stack<NestedInteger>();

                for (int i = nestedList.Count - 1; i >= 0; i--)
                {
                    stack.Push(nestedList[i]);
                }
            }

            public bool HasNext()
            {

                while (stack.Count != 0)
                {
                    NestedInteger cur = stack.Peek();
                    if (cur.IsInteger())
                    {
                        return true;
                    }
                    stack.Pop();
                    IList<NestedInteger> nestedList = cur.GetList();
                    for (int i = nestedList.Count - 1; i >= 0; i--)
                    {
                        stack.Push(nestedList[i]);
                    }
                }
                return false;
            }

            public int Next()
            {
                return stack.Pop().GetInteger();
            }
        }
    }
}
