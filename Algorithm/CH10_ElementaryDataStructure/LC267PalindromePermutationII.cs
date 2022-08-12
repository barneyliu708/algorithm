using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC267PalindromePermutationII
    {
        public IList<string> GeneratePalindromes(string s)
        {

            Dictionary<char, int> map = new Dictionary<char, int>();
            for (int i = 0; i < s.Length; i++)
            {
                if (!map.ContainsKey(s[i]))
                {
                    map[s[i]] = 0;
                }
                map[s[i]]++;
            }

            int oddCount = 0;
            char oddCh = '\n';
            char[] st = new char[s.Length / 2];
            int k = 0;
            foreach (char key in map.Keys)
            {
                if (map[key] % 2 == 1)
                {
                    oddCount++;
                    oddCh = key;
                }
                for (int j = 0; j < map[key] / 2; j++)
                {
                    st[k] = key;
                    k++;
                }
            }
            if (oddCount > 1)
            {
                return new List<string>();
            }

            HashSet<string> ans = new HashSet<string>();
            Permute(st, 0, oddCh, ans);
            return ans.ToList();
        }

        private void Swap(char[] st, int i, int j)
        {
            char temp = st[i];
            st[i] = st[j];
            st[j] = temp;
        }

        private void Permute(char[] st, int l, char oddCh, HashSet<string> ans)
        {

            if (l == st.Length)
            {
                string firsthalf = new string(st);
                string secondhalf = new string(firsthalf.ToCharArray().Reverse().ToArray());
                ans.Add(firsthalf + (oddCh == '\n' ? "" : oddCh.ToString()) + secondhalf);
                return;
            }

            for (int i = l; i < st.Length; i++)
            {
                if (st[i] != st[l] || l == i)
                {
                    Swap(st, l, i);
                    Permute(st, l + 1, oddCh, ans);
                    Swap(st, l, i);
                }
            }
        }

        public class SecondDone
        {
            public IList<string> GeneratePalindromes(string s)
            {
                int[] count = new int[26];
                foreach (char ch in s)
                {
                    count[ch - 'a']++;
                }

                char oddCh = '\t';
                for (int i = 0; i < count.Length; i++)
                {
                    if (count[i] % 2 == 1)
                    {
                        if (oddCh != '\t')
                        {
                            return new List<string>();
                        }
                        oddCh = (char)('a' + i);
                    }
                }

                StringBuilder sb = new StringBuilder();
                if (oddCh != '\t')
                {
                    sb.Append(oddCh);
                    count[oddCh - 'a']--;
                }
                List<string> ans = new List<string>();
                GenerateUtility(count, sb, s.Length, ans);

                return ans;
            }

            private void GenerateUtility(int[] count, StringBuilder sb, int n, List<string> ans)
            {
                if (sb.Length == n)
                {
                    ans.Add(sb.ToString());
                    return;
                }

                for (int i = 0; i < count.Length; i++)
                {
                    if (count[i] == 0)
                    {
                        continue;
                    }
                    char ch = (char)('a' + i);
                    sb.Append(ch);
                    sb.Insert(0, ch);
                    count[i] -= 2;

                    GenerateUtility(count, sb, n, ans);

                    count[i] += 2;
                    sb.Remove(0, 1);
                    sb.Remove(sb.Length - 1, 1);
                }
            }
        }
    }
}
