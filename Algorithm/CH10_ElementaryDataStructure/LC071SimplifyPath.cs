using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    public class LC071SimplifyPath
    {
        public string SimplifyPath(string path)
        {

            Stack<string> stack = new Stack<string>();

            string[] components = path.Split("/");
            foreach (string directory in components)
            {

                if (string.Equals(directory, ".") || string.IsNullOrEmpty(directory))
                {
                    continue;
                }

                else if (string.Equals(directory, ".."))
                {
                    if (stack.Count != 0)
                    {
                        stack.Pop();
                    }
                }

                else
                {
                    stack.Push(directory);
                }
            }

            StringBuilder result = new StringBuilder();
            foreach (string directory in stack)
            {
                result.Insert(0, directory);
                result.Insert(0, "/");
            }

            return result.Length > 0 ? result.ToString() : "/";
        }
    }
}
