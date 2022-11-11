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

        public class ForthDone
        {
            public int LongestConsecutive(int[] nums)
            {
                UnionFind uf = new UnionFind();
                HashSet<int> hashset = new HashSet<int>(); // nums;
                foreach (int num in nums)
                {
                    if (!hashset.Contains(num))
                    {
                        hashset.Add(num);
                        uf.Find(num);
                    }
                    if (hashset.Contains(num - 1))
                    {
                        int rep = uf.Find(num - 1);
                        uf.Union(rep, num);
                    }
                    if (hashset.Contains(num + 1))
                    {
                        int rep = uf.Find(num + 1);
                        uf.Union(rep, num);
                    }
                }

                return uf.GetMaxSize();
            }

            public class UnionFind
            {

                private Dictionary<int, int> reps; // element - representative
                private Dictionary<int, int> size; // representative - size

                public UnionFind()
                {
                    reps = new Dictionary<int, int>();
                    size = new Dictionary<int, int>();
                }

                public int Find(int x)
                {
                    if (!reps.ContainsKey(x))
                    {
                        reps[x] = x;
                        size[x] = 1;
                    }
                    if (reps[x] != x)
                    {
                        return reps[x] = Find(reps[x]);
                    }
                    return x;
                }

                public void Union(int x, int y)
                {
                    // Console.WriteLine("union " + x + " " + y);
                    int xrep = Find(x);
                    int yrep = Find(y);
                    if (xrep == yrep)
                    {
                        return;
                    }

                    if (size[xrep] > size[yrep])
                    {
                        size[xrep] += size[yrep];
                        reps[yrep] = xrep;
                    }
                    else
                    {
                        size[yrep] += size[xrep];
                        reps[xrep] = yrep;
                    }
                }

                public int GetMaxSize()
                {
                    int ans = 0;
                    foreach (int k in size.Keys)
                    {
                        ans = Math.Max(ans, size[k]);
                    }
                    return ans;
                }
            }
        }

        public class FifthDone
        {
            public class Solution
            {
                public int LongestConsecutive(int[] nums)
                {
                    UnionFind uf = new UnionFind(nums.Length);
                    Dictionary<int, int> map = new Dictionary<int, int>(); // value - index
                    for (int i = 0; i < nums.Length; i++)
                    {
                        if (map.ContainsKey(nums[i]))
                        {
                            continue;
                        }
                        map[nums[i]] = i;
                        if (map.ContainsKey(nums[i] - 1))
                        {
                            uf.Union(i, map[nums[i] - 1]);
                        }
                        if (map.ContainsKey(nums[i] + 1))
                        {
                            uf.Union(i, map[nums[i] + 1]);
                        }
                    }

                    return uf.GetMaxSize();
                }

                public class UnionFind
                {
                    private int[] representatives;
                    private int[] sizes;
                    public UnionFind(int n)
                    {
                        sizes = new int[n];
                        representatives = new int[n];
                        for (int i = 0; i < representatives.Length; i++)
                        {
                            representatives[i] = i;
                            sizes[i] = 1;
                        }
                    }

                    public int GetRep(int i)
                    {
                        if (representatives[i] == i)
                        {
                            return i;
                        }
                        return representatives[i] = GetRep(representatives[i]);
                    }

                    public void Union(int i, int j)
                    {
                        int irep = GetRep(i);
                        int jrep = GetRep(j);
                        if (irep == jrep)
                        {
                            return;
                        }
                        // Console.WriteLine("Union: " + i + " " + j);

                        if (sizes[irep] > sizes[jrep])
                        {
                            sizes[irep] += sizes[jrep];
                            representatives[jrep] = irep;
                        }
                        else
                        {
                            sizes[jrep] += sizes[irep];
                            representatives[irep] = jrep;
                        }
                    }

                    public int GetMaxSize()
                    {
                        int max = 0;
                        for (int i = 0; i < sizes.Length; i++)
                        {
                            max = Math.Max(max, sizes[i]);
                        }
                        return max;
                    }
                }
            }
        }
    }
}
