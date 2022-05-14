using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC299BullsAndCows
    {
        public string GetHint(string secret, string guess)
        {

            Dictionary<char, int> map = new Dictionary<char, int>();
            for (int i = 0; i < secret.Length; i++)
            {
                if (!map.ContainsKey(secret[i]))
                {
                    map[secret[i]] = 0;
                }
                map[secret[i]]++;
            }

            int bulls = 0, cows = 0;
            for (int i = 0; i < guess.Length; i++)
            {
                char ch = guess[i];
                if (map.ContainsKey(ch))
                {
                    if (ch == secret[i])
                    {

                        bulls++;

                        // if at this time map[guess[i]] <= 0, we need to give up cows and count them as bull.
                        if (map[ch] <= 0)
                        {
                            cows--;
                        }
                    }
                    else
                    {
                        if (map[ch] > 0)
                        {
                            cows++;
                        }
                    }
                    map[ch]--;
                }
            }

            return bulls + "A" + cows + "B";
        }

        public class SecondDone
        {
            public string GetHint(string secret, string guess)
            {
                int[] count = new int[10];
                foreach (char ch in secret)
                {
                    count[ch - '0']++;
                }

                int cows = 0;
                foreach (char ch in guess)
                {
                    if (count[ch - '0'] > 0)
                    {
                        cows++;
                        count[ch - '0']--;
                    }
                }

                int bulls = 0;
                for (int i = 0; i < secret.Length; i++)
                {
                    if (secret[i] == guess[i])
                    {
                        bulls++;
                    }
                }

                return bulls.ToString() + "A" + (cows - bulls).ToString() + "B";
            }
        }
    }
}
