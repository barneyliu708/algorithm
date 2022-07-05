using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    public class LC071SimplifyPathQuestion
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

        public string SimplifyPath_2ndDone(string path)
        {
            string[] paths = path.Split('/');
            Stack<string> stack = new Stack<string>();
            foreach (string p in paths)
            {
                if (p == "")
                {
                    continue;
                }
                else if (p == ".")
                {
                    continue;
                }
                else if (p == "..")
                {
                    if (stack.Count > 0)
                    {
                        stack.Pop();
                    }
                }
                else
                {
                    stack.Push(p);
                }
            }

            if (stack.Count == 0)
            {
                return "/";
            }

            StringBuilder sb = new StringBuilder();
            while (stack.Count > 0)
            {
                sb.Insert(0, '/' + stack.Pop());
            }

            return sb.ToString();
        }

        public class ThirdDone
        {
            public string SimplifyPath(string path)
            {
                string[] directories = path.Split('/');
                Stack<string> stack = new Stack<string>();
                foreach (string directory in directories)
                {
                    if (directory == "." || directory == "")
                    {
                        continue;
                    }
                    else if (directory == "..")
                    {
                        if (stack.Count > 0)
                        {
                            stack.Pop();
                        }
                    }
                    else
                    {
                        stack.Push(directory);
                    }
                }
                StringBuilder sb = new StringBuilder();
                if (stack.Count == 0)
                {
                    return "/";
                }
                while (stack.Count > 0)
                {
                    sb.Insert(0, "/" + stack.Pop());
                }
                return sb.ToString();
            }
        }
    }
}
