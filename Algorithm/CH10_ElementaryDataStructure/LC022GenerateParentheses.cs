using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC022GenerateParentheses
    {
        public IList<string> GenerateParenthesis(int n)
        {
            IList<string> ans = new List<string>();
            utility(n, n, "", ans);
            return ans;
        }

        private void utility(int left, int right, string output, IList<string> ans)
        {
            if (left > right)
            {
                return;
            }
            if (left == 0 && right == 0)
            {
                ans.Add(output);
                return;
            }

            if (left > 0)
            {
                utility(left - 1, right, output + "(", ans);
            }

            if (right > 0)
            {
                utility(left, right - 1, output + ")", ans);
            }
        }

        public class SecondDone
        {
            public IList<string> GenerateParenthesis(int n)
            {
                List<string> ans = new List<string>();
                Backtracking(n, n, new List<char>(), ans);
                return ans;
            }

            public void Backtracking(int ln, int rn, List<char> path, List<string> ans)
            {
                if (ln == 0 && rn == 0)
                {
                    ans.Add(string.Join("", path));
                    return;
                }

                if (ln > rn || ln < 0 || rn < 0)
                { // closing bracket is more that open bracket in the path
                    return;
                }

                path.Add('(');
                Backtracking(ln - 1, rn, path, ans);
                path.RemoveAt(path.Count - 1);

                path.Add(')');
                Backtracking(ln, rn - 1, path, ans);
                path.RemoveAt(path.Count - 1);
            }
        }
    }
}
