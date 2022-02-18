using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    public class LC277FindTheCelebrity
    {
        
        public class BruteForce
        {
            public bool Knows(int i, int j)
            {
                return i == j;
            }
            public int FindCelebrity(int n)
            {

                for (int i = 0; i < n; i++)
                {
                    int j;
                    for (j = 0; j < n; j++)
                    {
                        if (i != j && (!Knows(j, i) || Knows(i, j)))
                        {
                            break;
                        }
                    }
                    if (j == n) // all n - 1 people knows i, and i don't know any of n - 1 people
                    { 
                        return i;
                    }
                }

                return -1;
            }
        }

        public class OneScan
        {
            public bool Knows(int i, int j)
            {
                return i == j;
            }

            public int FindCelebrity(int n)
            {

                int candidate = 0;
                for (int i = 0; i < n; i++)
                {
                    if (i != candidate && Knows(candidate, i))
                    {
                        candidate = i;
                    }
                }

                for (int i = 0; i < n; i++)
                {
                    if (i != candidate && (!Knows(i, candidate) || Knows(candidate, i)))
                    {
                        return -1;
                    }
                }
                return candidate;
            }
        }
    }
}
