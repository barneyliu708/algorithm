using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC093RestoreIPAddresses
    {
        public IList<string> RestoreIpAddresses(string s)
        {
            List<string> segments = new List<string>();
            List<string> ans = new List<string>();
            RestoreIpAddresses(s, 0, segments, ans);
            return ans;
        }

        private void RestoreIpAddresses(string s, int start, List<string> segments, List<string> ans)
        {

            if (segments.Count == 4)
            {
                if (IsValidSegments(segments))
                {
                    ans.Add(string.Join('.', segments));
                }
                return;
            }

            if (start >= s.Length)
            {
                return;
            }

            if (segments.Count == 3)
            {
                string seg = s.Substring(start);
                segments.Add(seg);
                RestoreIpAddresses(s, s.Length, segments, ans);
                segments.RemoveAt(segments.Count - 1);
            }
            else
            {
                for (int i = start; i < Math.Min(s.Length, start + 3); i++)
                {
                    string seg = s.Substring(start, i - start + 1);
                    segments.Add(seg);
                    RestoreIpAddresses(s, i + 1, segments, ans);
                    segments.RemoveAt(segments.Count - 1);
                }
            }
        }

        private bool IsValidSegments(List<string> segments)
        {
            // Console.WriteLine(string.Join('.', segments));
            foreach (string seg in segments)
            {
                if (seg.Length > 3)
                {
                    return false;
                }
                if ((seg[0] == '0' && seg.Length == 1) ||
                    (seg[0] != '0' && int.Parse(seg) <= 255))
                {
                    continue;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
    }
}
