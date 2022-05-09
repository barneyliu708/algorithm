using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC721AccountsMerge
    {
        public IList<IList<string>> AccountsMerge(IList<IList<string>> accounts)
        {
            // pre-process to generate the graph
            Dictionary<string, List<string>> graph = new Dictionary<string, List<string>>();
            foreach (List<string> account in accounts)
            {
                string firstEmail = account[1];
                for (int i = 1; i < account.Count; i++) // first email will point to itself as well to handle users with only one email
                {
                    if (!graph.ContainsKey(firstEmail))
                    {
                        graph[firstEmail] = new List<string>();
                    }
                    if (!graph.ContainsKey(account[i]))
                    {
                        graph[account[i]] = new List<string>();
                    }
                    graph[firstEmail].Add(account[i]);
                    graph[account[i]].Add(firstEmail);
                }
            }

            // dft
            List<IList<string>> ans = new List<IList<string>>();
            HashSet<string> visited = new HashSet<string>();
            foreach (List<string> account in accounts)
            {
                string person = account[0];
                string firstEmail = account[1];
                if (!visited.Contains(firstEmail))
                {
                    List<string> emails = new List<string>();
                    Dft(graph, firstEmail, visited, emails);
                    emails.Sort(StringComparer.Ordinal);
                    emails.Insert(0, person);
                    ans.Add(emails);
                }
            }
            return ans;
        }

        private void Dft(Dictionary<string, List<string>> graph, string curEmail, HashSet<string> visited, List<string> emails)
        {

            if (visited.Contains(curEmail) || !graph.ContainsKey(curEmail))
            {
                return;
            }

            visited.Add(curEmail);
            emails.Add(curEmail);

            foreach (string neighbor in graph[curEmail])
            {
                Dft(graph, neighbor, visited, emails);
            }
        }
    }
}
