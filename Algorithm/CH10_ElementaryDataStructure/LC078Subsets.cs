using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC078Subsets
    {
        public IList<IList<int>> Subsets(int[] nums)
        {
            List<int> comb = new List<int>();
            List<IList<int>> ans = new List<IList<int>>();
            Subsets(nums, 0, comb, ans);
            return ans;
        }

        private void Subsets(int[] nums, int start, List<int> comb, List<IList<int>> ans)
        {

            ans.Add(new List<int>(comb));

            for (int i = start; i < nums.Length; i++)
            {
                comb.Add(nums[i]);
                Subsets(nums, i + 1, comb, ans);
                comb.Remove(nums[i]);
            }
        }

        public class SecondDone
        {
            public IList<IList<int>> Subsets(int[] nums)
            {
                List<int> path = new List<int>();
                List<IList<int>> ans = new List<IList<int>>();
                Subsets(nums, 0, path, ans);
                return ans;
            }

            private void Subsets(int[] nums, int i, List<int> path, List<IList<int>> ans)
            {
                ans.Add(new List<int>(path));
                for (int j = i; j < nums.Length; j++)
                {
                    path.Add(nums[j]);
                    Subsets(nums, j + 1, path, ans);
                    path.RemoveAt(path.Count - 1);
                }
            }
        }

        public class ThirdDone
        {
            public IList<IList<int>> Subsets(int[] nums)
            {
                List<int> cur = new List<int>();
                List<IList<int>> ans = new List<IList<int>>();
                Utility(nums, 0, cur, ans);
                return ans;
            }

            private void Utility(int[] nums, int istart, List<int> cur, List<IList<int>> ans)
            {
                ans.Add(new List<int>(cur));

                for (int i = istart; i < nums.Length; i++)
                {
                    cur.Add(nums[i]);
                    Utility(nums, i + 1, cur, ans);
                    cur.RemoveAt(cur.Count - 1);
                }
            }
        }
    }
}
