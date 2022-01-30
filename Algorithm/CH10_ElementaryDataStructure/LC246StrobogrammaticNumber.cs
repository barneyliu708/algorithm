using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC246StrobogrammaticNumber
    {
        public bool IsStrobogrammatic(string num)
        {

            Dictionary<char, char> map = new Dictionary<char, char>() {
                { '0', '0' },
                { '1', '1' },
                { '6', '9' },
                { '8', '8' },
                { '9', '6' }
            };

            for (int i = 0; i <= num.Length / 2; i++)
            {
                if (!map.ContainsKey(num[i]))
                {
                    return false;
                }

                if (map[num[i]] != num[num.Length - i - 1])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
