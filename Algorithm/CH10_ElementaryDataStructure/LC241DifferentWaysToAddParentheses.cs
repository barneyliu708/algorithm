using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC241DifferentWaysToAddParentheses
    {
        public IList<int> DiffWaysToCompute(string expression)
        {
            Dictionary<string, IList<int>> map = new Dictionary<string, IList<int>>();
            return DiffWaysToCompute(expression, map);
        }

        private IList<int> DiffWaysToCompute(string expression, Dictionary<string, IList<int>> map)
        {

            if (map.ContainsKey(expression))
            {
                return map[expression];
            }

            IList<int> ans = new List<int>();
            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] == '+' || expression[i] == '-' || expression[i] == '*')
                {
                    IList<int> leftResults = DiffWaysToCompute(expression.Substring(0, i), map);
                    IList<int> rightResults = DiffWaysToCompute(expression.Substring(i + 1, expression.Length - i - 1));

                    for (int l = 0; l < leftResults.Count; l++)
                    {
                        for (int r = 0; r < rightResults.Count; r++)
                        {
                            if (expression[i] == '+')
                            {
                                ans.Add(leftResults[l] + rightResults[r]);
                            }
                            else if (expression[i] == '-')
                            {
                                ans.Add(leftResults[l] - rightResults[r]);
                            }
                            else
                            {
                                ans.Add(leftResults[l] * rightResults[r]);
                            }
                        }
                    }
                }
            }

            if (ans.Count == 0)
            {
                ans.Add(int.Parse(expression));
            }
            map[expression] = ans;
            return ans;
        }
    }
}
