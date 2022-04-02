using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    public class LC150EvaluateReversePolishNotation
    {
        public int EvalRPN(string[] tokens)
        {
            Stack<int> stack = new Stack<int>();
            foreach (string token in tokens)
            {
                if (!IsOperator(token))
                {
                    stack.Push(int.Parse(token));
                }
                else
                {
                    int rightOperand = stack.Pop();
                    int leftOperand = stack.Pop();
                    int result;
                    if (token == "+")
                    {
                        result = leftOperand + rightOperand;
                    }
                    else if (token == "-")
                    {
                        result = leftOperand - rightOperand;
                    }
                    else if (token == "*")
                    {
                        result = leftOperand * rightOperand;
                    }
                    else
                    { // division
                        result = leftOperand / rightOperand;
                    }
                    stack.Push(result);
                }
            }
            return stack.Peek();
        }

        private bool IsOperator(string s)
        {
            return s == "+" || s == "-" || s == "*" || s == "/";
        }

        public class SecondDone
        {
            public int EvalRPN(string[] tokens)
            {
                Dictionary<string, Func<int, int, int>> operations = new Dictionary<string, Func<int, int, int>>()
                {
                    { "+", (int a, int b) => { return a + b; }},
                    { "-", (int a, int b) => { return a - b; }},
                    { "*", (int a, int b) => { return a * b; }},
                    { "/", (int a, int b) => { return a / b; }}
                };
                Stack<int> stack = new Stack<int>();
                foreach (string token in tokens)
                {
                    if (!operations.ContainsKey(token))
                    {
                        stack.Push(int.Parse(token));
                    }
                    else
                    {
                        int operand2 = stack.Pop();
                        int operand1 = stack.Pop();
                        int result = operations[token](operand1, operand2);
                        stack.Push(result);
                    }
                }
                return stack.Peek();
            }
        }
    }
}
