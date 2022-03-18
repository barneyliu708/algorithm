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
    }
}
