using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    public class LC364NestedListWeightSumII
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

        public int DepthSumInverse(IList<NestedInteger> nestedList)
        {

            IList<int> sumList = new List<int>();
            dfs(nestedList, sumList, 1);

            int maxDepth = sumList.Count;
            int weightedSum = 0;
            for (int depth = 1; depth <= sumList.Count; depth++)
            {
                weightedSum += (maxDepth - depth + 1) * sumList[depth - 1];
            }
            return weightedSum;
        }

        private void dfs(IList<NestedInteger> nestedList, IList<int> sumList, int depth)
        {

            if (sumList.Count < depth)
            {
                sumList.Add(0);
            }

            foreach (NestedInteger item in nestedList)
            {

                if (item.IsInteger())
                {
                    int curVal = item.GetInteger();
                    sumList[depth - 1] += curVal;
                }

                else
                {
                    dfs(item.GetList(), sumList, depth + 1);
                }
            }
        }
    }
}
