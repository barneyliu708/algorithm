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

        public class SecondDone
        {
            public IList<string> RestoreIpAddresses(string s)
            {
                List<string> ans = new List<string>();
                Backtracking(s, 0, new List<string>(), ans);
                return ans;
            }

            private void Backtracking(string s, int si, List<string> path, List<string> ans)
            {
                if (path.Count > 4)
                {
                    return;
                }

                if (si == s.Length)
                {
                    if (path.Count == 4)
                    {
                        ans.Add(string.Join(".", path));
                    }
                    return;
                }

                for (int i = si; i < s.Length; i++)
                {
                    string substr = s.Substring(si, i - si + 1);
                    if (substr[0] == '0' && substr.Length > 1)
                    {
                        break;
                    }
                    int num = int.Parse(substr);
                    if (num > 255)
                    {
                        break;
                    }

                    // recursively to the next level
                    path.Add(substr);
                    Backtracking(s, i + 1, path, ans);
                    path.RemoveAt(path.Count - 1);
                }
            }
        }
    }
}
