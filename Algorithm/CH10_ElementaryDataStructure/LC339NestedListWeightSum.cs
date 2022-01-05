using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    public class LC339NestedListWeightSum
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

        public int DepthSum(IList<NestedInteger> nestedList)
        {
            return dfs(nestedList, 1);
        }

        private int dfs(IList<NestedInteger> nestedList, int depth)
        {
            int total = 0;
            foreach (NestedInteger item in nestedList)
            {
                if (item.IsInteger())
                {
                    total += item.GetInteger() * depth;
                }
                else
                {
                    total += dfs(item.GetList(), depth + 1);
                }
            }
            return total;
        }
    }
}
