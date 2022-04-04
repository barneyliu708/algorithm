using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC735AsteroidCollision
    {
        public int[] AsteroidCollision(int[] asteroids)
        {
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < asteroids.Length; i++)
            {
                int asteroid = asteroids[i];

                if (stack.Count == 0)
                {
                    stack.Push(asteroid);
                    continue;
                }

                // trigger the collision
                while (stack.Count > 0 && stack.Peek() > 0 && asteroid < 0)
                {
                    int left = stack.Pop();
                    if (left > -asteroid)
                    {
                        asteroid = left; // this will stop the while loop
                    }
                    else if (left < -asteroid)
                    {
                        continue;
                    }
                    else
                    {
                        asteroid = 0; // 0 means both asteroids are removed and will stop the while loop
                    }
                }
                if (asteroid != 0)
                {
                    stack.Push(asteroid);
                }
            }

            int[] ans = new int[stack.Count];
            for (int i = ans.Length - 1; i >= 0; i--)
            {
                ans[i] = stack.Pop();
            }

            return ans;
        }

        public class SecondDone
        {
            public int[] AsteroidCollision(int[] asteroids)
            {
                Stack<int> stack = new Stack<int>();
                foreach (int a in asteroids)
                {
                    bool addnew = true;
                    while (stack.Count != 0 && stack.Peek() > 0 && a < 0)
                    {
                        if (stack.Peek() < -a)
                        {
                            stack.Pop();
                            continue;
                        }
                        else if (stack.Peek() == -a)
                        {
                            stack.Pop();
                            addnew = false;
                            break;
                        }
                        else
                        {
                            addnew = false;
                            break;
                        }
                    }
                    if (addnew)
                    {
                        stack.Push(a);
                    }
                }

                int[] ans = new int[stack.Count];
                for (int i = ans.Length - 1; i >= 0; i--)
                {
                    ans[i] = stack.Pop();
                }

                return ans;
            }
        }
    }
}
