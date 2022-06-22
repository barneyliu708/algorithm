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

        public class ThirdDone_UnionFind
        {
            public class Solution
            {
                public IList<IList<string>> AccountsMerge(IList<IList<string>> accounts)
                {
                    DSU dsu = new DSU(accounts.Count);

                    // email string - account index
                    Dictionary<string, int> emailAcctDict = new Dictionary<string, int>();
                    for (int i = 0; i < accounts.Count; i++)
                    {
                        for (int e = 1; e < accounts[i].Count; e++)
                        {
                            string email = accounts[i][e];
                            if (!emailAcctDict.ContainsKey(email))
                            {
                                emailAcctDict[email] = i;
                            }
                            else
                            {
                                dsu.UnionBySize(i, emailAcctDict[email]);
                            }
                        }
                    }

                    // represent index - all group members' emails
                    Dictionary<int, HashSet<string>> acctDict = new Dictionary<int, HashSet<string>>();
                    for (int i = 0; i < accounts.Count; i++)
                    {
                        int irep = dsu.GetRepresentative(i);
                        if (!acctDict.ContainsKey(irep))
                        {
                            acctDict[irep] = new HashSet<string>();
                        }
                        for (int e = 1; e < accounts[i].Count; e++)
                        {
                            acctDict[irep].Add(accounts[i][e]);
                        }
                    }

                    // prepare the answer
                    List<IList<string>> ans = new List<IList<string>>();
                    foreach (int irep in acctDict.Keys)
                    {
                        string name = accounts[irep][0];
                        List<string> emails = acctDict[irep].ToList();
                        emails.Sort(StringComparer.Ordinal);
                        emails.Insert(0, name);
                        ans.Add(emails);
                    }
                    //         Dictionary<int, List<string>> components = new Dictionary<int, List<string>>();
                    //         foreach (string email in emailAcctDict.Keys) {

                    //             int i = emailAcctDict[email];
                    //             int irep = dsu.GetRepresentative(i);
                    //             // Console.WriteLine(email + " " + i + " " + irep);

                    //             if (!components.ContainsKey(irep)) {
                    //                 components[irep] = new List<string>();
                    //             }
                    //             components[irep].Add(email);
                    //         }

                    //         List<IList<string>> ans = new List<IList<string>>();
                    //         foreach (int irep in components.Keys) {
                    //             List<string> emails = components[irep];
                    //             emails.Sort(StringComparer.Ordinal);
                    //             emails.Insert(0, accounts[irep][0]);
                    //             ans.Add(emails);
                    //         }

                    return ans;
                }

                public class DSU
                {
                    private int[] representatives;
                    private int[] size;

                    public DSU(int sz)
                    {
                        size = new int[sz];
                        representatives = new int[sz];
                        for (int i = 0; i < sz; i++)
                        {
                            size[i] = 1;
                            representatives[i] = i;
                        }
                    }

                    public int GetRepresentative(int i)
                    {
                        if (representatives[i] == i)
                        {
                            return i;
                        }

                        return representatives[i] = GetRepresentative(representatives[i]);
                    }

                    public void UnionBySize(int a, int b)
                    {
                        // Console.WriteLine("Union: " + a + " " + b);
                        int arep = GetRepresentative(a);
                        int brep = GetRepresentative(b);

                        if (arep == brep)
                        { // a and b already unioned
                            return;
                        }

                        if (size[arep] >= size[brep])
                        {
                            size[arep] += size[brep];
                            representatives[brep] = arep;

                        }
                        else
                        {
                            size[brep] += size[arep];
                            representatives[arep] = brep;
                        }
                    }
                }
            }
        }
    }
}
