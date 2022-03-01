using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC294FlipGameII
    {
        public bool CanWin(string currentState)
        {
            for (int i = 1; i < currentState.Length; i++)
            {
                if (currentState[i] == '+' && currentState[i - 1] == '+' &&
                    !CanWin(currentState.Substring(0, i - 1) + "--" + currentState.Substring(i + 1)))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
