using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC306AdditiveNumber
    {
        public bool IsAdditiveNumber(string num)
        {
            List<long> segments = new List<long>();
            return IsAdditiveNumber(num, 0, segments);
        }

        private bool IsAdditiveNumber(string num, int start, List<long> segments)
        {

            if (start >= num.Length)
            {
                return segments.Count >= 3;
            }

            for (int i = start; i < num.Length; i++)
            {
                string curstr = num.Substring(start, i - start + 1);
                if (curstr[0] == '0' && curstr.Length > 1)
                {
                    continue;
                }
                long curnum;
                if (!long.TryParse(curstr, out curnum))
                {
                    continue;
                }
                if (segments.Count >= 2 && segments[segments.Count - 1] + segments[segments.Count - 2] != curnum)
                {
                    continue;
                }
                segments.Add(curnum);
                if (IsAdditiveNumber(num, i + 1, segments))
                {
                    segments.RemoveAt(segments.Count - 1);
                    return true;
                }
                segments.RemoveAt(segments.Count - 1);
            }

            return false;
        }

        public class SecondDone
        {
            public bool IsAdditiveNumber(string num)
            {
                List<long> cur = new List<long>();
                return Backtracking(num, 0, cur);
            }
            // return -1 if is not additive num, otherwise, return the next num 
            private bool Backtracking(string num, int istart, List<long> cur)
            {

                if (istart == num.Length)
                {
                    return cur.Count >= 3;
                }

                if (cur.Count < 2)
                {
                    bool isAdditive = false;
                    for (int i = istart; i < num.Length; i++)
                    {
                        if (num[istart] == '0' && istart != i)
                        { // num with leading 0
                            break;
                        }
                        long nextNum;
                        if (!long.TryParse(num.Substring(istart, i - istart + 1), out nextNum))
                        {
                            continue;
                        }
                        // Console.WriteLine(nextNum);
                        cur.Add(nextNum);
                        isAdditive = isAdditive || Backtracking(num, i + 1, cur);
                        cur.RemoveAt(cur.Count - 1);
                    }
                    return isAdditive;
                }
                else
                {
                    long expectedNextNum = cur[cur.Count - 1] + cur[cur.Count - 2];
                    int expectedNextNumLen = expectedNextNum.ToString().Length;
                    if (istart + expectedNextNumLen - 1 >= num.Length)
                    { // num[istart : num.Length - 1] is not long enought
                        return false;
                    }
                    long nextNum = long.Parse(num.Substring(istart, expectedNextNumLen));
                    if (nextNum != expectedNextNum)
                    {
                        return false;
                    }
                    // Console.WriteLine(cur[cur.Count - 2] + " " + cur[cur.Count - 1]);
                    cur.Add(nextNum);
                    bool ans = Backtracking(num, istart + expectedNextNumLen, cur);
                    cur.RemoveAt(cur.Count - 1);
                    return ans;
                }
            }
        }
    }
}
