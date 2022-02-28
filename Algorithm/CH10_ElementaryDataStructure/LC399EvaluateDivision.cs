using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC399EvaluateDivision
    {
        public double[] CalcEquation(IList<IList<string>> equations, double[] values, IList<IList<string>> queries)
        {

            Dictionary<string, Dictionary<string, double>> graph = new Dictionary<string, Dictionary<string, double>>();
            for (int i = 0; i < equations.Count; i++)
            {
                string dividend = equations[i][0];
                string divisor = equations[i][1];
                double quotient = values[i];
                if (!graph.ContainsKey(dividend))
                {
                    graph[dividend] = new Dictionary<string, double>();
                }
                if (!graph.ContainsKey(divisor))
                {
                    graph[divisor] = new Dictionary<string, double>();
                }
                graph[dividend][divisor] = quotient;
                graph[divisor][dividend] = 1 / quotient;
            }

            double[] ans = new double[queries.Count];
            for (int i = 0; i < queries.Count; i++)
            {
                IList<string> query = queries[i];
                string dividend = query[0];
                string divisor = query[1];

                if (!graph.ContainsKey(dividend) || !graph.ContainsKey(divisor))
                {
                    ans[i] = -1.0;
                }
                else if (dividend == divisor)
                {
                    ans[i] = 1.0;
                }
                else
                { // Dft
                    ans[i] = Dft(graph, dividend, divisor, 1, new HashSet<string>());
                }
            }

            return ans;
        }

        private double Dft(Dictionary<string, Dictionary<string, double>> graph, string cur, string target, double product, HashSet<string> visited)
        {

            visited.Add(cur);
            double ans = -1.0;

            Dictionary<string, double> neighbors = graph[cur];
            if (neighbors.ContainsKey(target))
            {
                return product * neighbors[target];
            }

            foreach (string neighbor in neighbors.Keys)
            {
                if (visited.Contains(neighbor))
                {
                    continue;
                }
                ans = Dft(graph, neighbor, target, product * neighbors[neighbor], visited);
                if (ans != -1)
                {
                    return ans;
                }
            }

            visited.Remove(cur);

            return ans;
        }
    }
}
