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
    }
}
