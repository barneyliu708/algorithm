using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC056MergeIntervals
    {
        public int[][] Merge(int[][] intervals)
        {

            if (intervals.Length == 0)
            {
                return new int[0][];
            }

            Array.Sort(intervals, (int[] x, int[] y) => { return x[0].CompareTo(y[0]); });

            List<int[]> ans = new List<int[]>();
            ans.Add(intervals[0]);

            for (int i = 1; i < intervals.Length; i++)
            {
                int[] curr = intervals[i];
                int[] last = ans[ans.Count - 1];
                if (curr[0] <= last[1])
                { // merge the two interval
                    last[1] = Math.Max(last[1], curr[1]);
                }
                else
                {
                    ans.Add(curr);
                }
            }

            return ans.ToArray();
        }

        public class SecondDone
        {
            public int[][] Merge(int[][] intervals)
            {
                Array.Sort(intervals, (int[] x, int[] y) => {
                    return x[0].CompareTo(y[0]);
                });

                List<int[]> ans = new List<int[]>();
                ans.Add(intervals[0]);

                for (int i = 1; i < intervals.Length; i++)
                {
                    int[] pre = ans[ans.Count - 1];
                    int[] cur = intervals[i];

                    if (cur[0] <= pre[1]) // merge with previous interval
                    { 
                        pre[1] = Math.Max(pre[1], cur[1]);
                    }
                    else
                    {
                        ans.Add(cur);
                    }
                }

                return ans.ToArray();
            }
        }
    }
}
