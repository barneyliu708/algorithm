using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC217ContainsDuplicate
    {
        public bool ContainsDuplicate(int[] nums)
        {
            HashSet<int> hashset = new HashSet<int>();

            foreach (int num in nums)
            {
                if (hashset.Contains(num))
                {
                    return true;
                }
                hashset.Add(num);
            }

            return false;
        }
    }
}
