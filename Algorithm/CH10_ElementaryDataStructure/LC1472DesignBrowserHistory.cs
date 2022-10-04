using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC1472DesignBrowserHistory
    {
        public class BrowserHistory
        {

            private List<string> histories;
            private int curi;
            private int length;

            public BrowserHistory(string homepage)
            {
                histories = new List<string>();
                histories.Add(homepage);
                curi = 0;
                length = histories.Count;
            }

            public void Visit(string url)
            {
                curi++;
                if (curi == histories.Count)
                {
                    histories.Add(url);
                    length = histories.Count;
                }
                else
                {
                    histories[curi] = url;
                    length = curi + 1; // if there is a new visit, all forward histories need to be moved
                }
            }

            public string Back(int steps)
            {
                curi = Math.Max(0, curi - steps);
                return histories[curi];
            }

            public string Forward(int steps)
            {
                curi = Math.Min(length - 1, curi + steps);
                return histories[curi];
            }
        }

        public class SecondDone
        {
            public class BrowserHistory
            {

                private Stack<string> stack1;
                private Stack<string> stack2;

                public BrowserHistory(string homepage)
                {
                    stack1 = new Stack<string>();
                    stack2 = new Stack<string>();
                    stack1.Push(homepage);
                }

                public void Visit(string url)
                {
                    stack1.Push(url);
                    stack2.Clear();
                }

                public string Back(int steps)
                {
                    while (steps > 0 && stack1.Count > 1)
                    {
                        stack2.Push(stack1.Pop());
                        steps--;
                    }
                    return stack1.Peek();
                }

                public string Forward(int steps)
                {
                    while (steps > 0 && stack2.Count > 0)
                    {
                        stack1.Push(stack2.Pop());
                        steps--;
                    }
                    return stack1.Peek();
                }
            }
        }

        public class ThirdDone
        {
            public class BrowserHistory
            {

                private List<string> histories;
                private int cur = 0;
                private int latest = 0;

                public BrowserHistory(string homepage)
                {
                    histories = new List<string>();
                    histories.Add(""); // dummy url
                    this.Visit(homepage);
                }

                public void Visit(string url)
                {
                    if (cur == histories.Count - 1)
                    {
                        histories.Add(url);
                        cur++;
                    }
                    else
                    {
                        cur++;
                        histories[cur] = url;
                    }
                    latest = cur;
                }

                public string Back(int steps)
                {
                    cur = Math.Max(1, cur - steps); // the first element is the dummy url, so the mininum valid index is 1
                    return histories[cur];
                }

                public string Forward(int steps)
                {
                    cur = Math.Min(latest, cur + steps);
                    return histories[cur];
                }
            }
        }
    }
}
