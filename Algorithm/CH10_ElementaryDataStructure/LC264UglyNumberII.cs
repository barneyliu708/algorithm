using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    [TestFixture]
    class LC264UglyNumberII
    {
        public int NthUglyNumber(int n)
        {

            int i2 = 0;
            int i3 = 0;
            int i5 = 0;
            List<int> ans = new List<int>();
            ans.Add(1);

            while (ans.Count < n)
            {
                int n2 = ans[i2] * 2;
                int n3 = ans[i3] * 3;
                int n5 = ans[i5] * 5;

                int min = Math.Min(Math.Min(n2, n3), n5);
                if (min == n2)
                {
                    i2++;
                }
                if (min == n3)
                {
                    i3++;
                }
                if (min == n5)
                {
                    i5++;
                }
                ans.Add(min);
            }

            return ans[ans.Count - 1];
        }

        [Test]
        public void TestCase1()
        {
            var result = NthUglyNumber(10);
        }
    }
}
