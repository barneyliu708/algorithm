using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC1235MaximumProfitInJobScheduling
    {
        public class DftMemorization
        {
            public int JobScheduling(int[] startTime, int[] endTime, int[] profit)
            {
                // prepare the jobs list
                (int start, int end, int profit)[] jobs = new (int start, int end, int profit)[startTime.Length];
                for (int i = 0; i < startTime.Length; i++)
                {
                    jobs[i] = (startTime[i], endTime[i], profit[i]);
                }
                Array.Sort(jobs, ((int start, int end, int profit) x, (int start, int end, int profit) y) => {
                    return x.start.CompareTo(y.start);
                });

                // prepare the memorization
                int[] memo = new int[startTime.Length];
                return JobScheduling(jobs, 0, memo);
            }

            private int JobScheduling((int start, int end, int profit)[] jobs, int i, int[] memo)
            {
                if (i == jobs.Length)
                {
                    return 0;
                }
                if (memo[i] > 0)
                {
                    return memo[i];
                }

                int nexti = FindNextJob(jobs, i);

                // take current ith job, or skip
                memo[i] = Math.Max(jobs[i].profit + JobScheduling(jobs, nexti, memo), JobScheduling(jobs, i + 1, memo));
                return memo[i];
            }

            // find the next available job after the ith job by the binary search
            private int FindNextJob((int start, int end, int profit)[] jobs, int i)
            {
                int lastEnd = jobs[i].end;
                int l = i;
                int r = jobs.Length - 1;
                while (l <= r)
                {
                    int mid = l + (r - l) / 2;
                    if (jobs[mid].start == lastEnd)
                    { // need to find the leftmost index that satisfy the conditions
                        r = mid - 1;
                    }
                    if (jobs[mid].start < lastEnd)
                    {
                        l = mid + 1;
                    }
                    else
                    {
                        r = mid - 1;
                    }
                }
                return l;
            }
        }

        public class DP_BottomUp
        {
            public int JobScheduling(int[] startTime, int[] endTime, int[] profit)
            {
                int n = startTime.Length;
                // prepare the jobs list
                (int start, int end, int profit)[] jobs = new (int start, int end, int profit)[n];
                for (int i = 0; i < n; i++)
                {
                    jobs[i] = (startTime[i], endTime[i], profit[i]);
                }
                Array.Sort(jobs, ((int start, int end, int profit) x, (int start, int end, int profit) y) => {
                    return x.start.CompareTo(y.start);
                });

                // prepare the memorization
                int[] memo = new int[n + 1];
                for (int i = n - 1; i >= 0; i--)
                {
                    int nexti = FindNextJob(jobs, i);
                    memo[i] = Math.Max(jobs[i].profit + memo[nexti], memo[i + 1]);
                }

                return memo[0];
            }

            // find the next available job after the ith job by the binary search
            private int FindNextJob((int start, int end, int profit)[] jobs, int i)
            {
                int lastEnd = jobs[i].end;
                int l = i;
                int r = jobs.Length - 1;
                while (l <= r)
                {
                    int mid = l + (r - l) / 2;
                    if (jobs[mid].start == lastEnd)
                    { // need to find the leftmost index that satisfy the conditions
                        r = mid - 1;
                    }
                    if (jobs[mid].start < lastEnd)
                    {
                        l = mid + 1;
                    }
                    else
                    {
                        r = mid - 1;
                    }
                }
                return l;
            }

            public class SecondDone
            {
                public int JobScheduling(int[] startTime, int[] endTime, int[] profit)
                {
                    int n = startTime.Length;
                    Job[] jobs = new Job[n];
                    for (int i = 0; i < n; i++)
                    {
                        jobs[i] = new Job(startTime[i], endTime[i], profit[i]);
                    }

                    Array.Sort(jobs, (Job x, Job y) => {
                        return x.StartTime.CompareTo(y.StartTime);
                    });

                    int[] dp = new int[n + 1];
                    dp[n - 1] = jobs[n - 1].Profit;
                    for (int i = n - 2; i >= 0; i--)
                    {
                        int j = FindNextJob(jobs, i);
                        dp[i] = Math.Max(jobs[i].Profit + dp[j], dp[i + 1]);
                    }
                    return dp[0];
                }

                public int FindNextJob(Job[] jobs, int icur)
                {
                    int curEndTime = jobs[icur].EndTime;
                    int l = icur + 1;
                    int r = jobs.Length - 1;
                    while (l <= r)
                    {
                        int mid = l + (r - l) / 2;
                        if (jobs[mid].StartTime >= curEndTime)
                        {
                            r = mid - 1;
                        }
                        else
                        {
                            l = mid + 1;
                        }
                    }
                    return l;
                }

                public class Job
                {
                    public Job(int startTime, int endTime, int profit)
                    {
                        this.StartTime = startTime;
                        this.EndTime = endTime;
                        this.Profit = profit;
                    }
                    public int StartTime;
                    public int EndTime;
                    public int Profit;
                }
            }
        }
    }
}
