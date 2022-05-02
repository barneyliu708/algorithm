using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC526BeautifulArrangement
    {
        private int count;
        public int CountArrangement(int n)
        {
            bool[] visited = new bool[n + 1];
            Utility(n, 1, visited);
            return count;
        }

        private void Utility(int N, int pos, bool[] visited)
        {

            if (pos > N)
            {
                count++;
            }

            for (int i = 1; i <= N; i++)
            {
                if (!visited[i] && (pos % i == 0 || i % pos == 0))
                {
                    visited[i] = true;
                    Utility(N, pos + 1, visited);
                    visited[i] = false;
                }
            }
        }

        public class SecondDone
        {
            private int count = 0;

            public int CountArrangement(int n)
            {
                int[] nums = new int[n];
                for (int i = 0; i < n; i++)
                {
                    nums[i] = i + 1;
                }
                Backtracking(nums, 0);
                return count;
            }

            private void Backtracking(int[] nums, int i)
            {
                if (i == nums.Length)
                {
                    count++;
                    return;
                }

                for (int j = i; j < nums.Length; j++)
                {
                    if ((i + 1) % nums[j] == 0 || nums[j] % (i + 1) == 0)
                    {
                        Swap(nums, i, j);
                        Backtracking(nums, i + 1);
                        Swap(nums, i, j);
                    }
                }
            }

            private void Swap(int[] nums, int i, int j)
            {
                int temp = nums[i];
                nums[i] = nums[j];
                nums[j] = temp;
            }
        }
    }
}
