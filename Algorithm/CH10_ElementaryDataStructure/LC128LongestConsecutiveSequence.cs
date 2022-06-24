using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC128LongestConsecutiveSequence
    {
        public int LongestConsecutive(int[] nums)
        {

            HashSet<int> hashset = new HashSet<int>();
            foreach (int num in nums)
            {
                hashset.Add(num);
            }

            int ans = 0;
            foreach (int num in hashset)
            {
                if (!hashset.Contains(num - 1))
                {
                    int curNum = num;
                    int curLength = 1;

                    while (hashset.Contains(curNum + 1))
                    {
                        curNum++;
                        curLength++;
                    }

                    ans = Math.Max(ans, curLength);
                }
            }

            return ans;
        }

        public class SecondDone
        {
            public int LongestConsecutive(int[] nums)
            {
                HashSet<int> hashset = new HashSet<int>();
                foreach (int num in nums)
                {
                    hashset.Add(num);
                }

                int ans = 0;
                foreach (int num in nums)
                {
                    if (!hashset.Contains(num - 1))
                    {
                        int count = 0;
                        int n = num;
                        while (hashset.Contains(n))
                        {
                            count++;
                            n++;
                        }
                        ans = Math.Max(ans, count);
                    }
                }

                return ans;
            }
        }

        public class ThirdDone_UnionFind
        {
            public class Solution
            {
                public int LongestConsecutive(int[] nums)
                {
                    Dictionary<int, int> map = new Dictionary<int, int>(); // num value - index
                    DSU dsu = new DSU(nums.Length);
                    for (int i = 0; i < nums.Length; i++)
                    {
                        int num = nums[i];
                        if (map.ContainsKey(num))
                        {
                            continue;
                        }
                        if (map.ContainsKey(num - 1))
                        {
                            dsu.Union(i, map[num - 1]);
                        }
                        if (map.ContainsKey(num + 1))
                        {
                            dsu.Union(i, map[num + 1]);
                        }
                        map[num] = i;
                    }
                    return dsu.GetMaxSize();
                }
            }

            public class DSU
            {
                private int[] representatives; // the index of elements
                private int[] size;

                public DSU(int sz)
                {
                    representatives = new int[sz];
                    size = new int[sz];
                    for (int i = 0; i < sz; i++)
                    {
                        representatives[i] = i;
                        size[i] = 1;
                    }
                }

                public int GetRepresentative(int i)
                {
                    if (representatives[i] == i)
                    {
                        return i;
                    }
                    return representatives[i] = GetRepresentative(representatives[i]);
                }

                public void Union(int ia, int ib)
                {
                    int iarep = GetRepresentative(ia);
                    int ibrep = GetRepresentative(ib);

                    if (iarep == ibrep)
                    {
                        return;
                    }

                    if (size[iarep] >= size[ibrep])
                    {
                        size[iarep] += size[ibrep];
                        representatives[ibrep] = iarep;
                    }
                    else
                    {
                        size[ibrep] += size[iarep];
                        representatives[iarep] = ibrep;
                    }
                }

                public int GetMaxSize()
                {
                    int max = 0;
                    foreach (int sz in size)
                    {
                        max = Math.Max(max, sz);
                    }
                    return max;
                }
            }
        }
    }
}
