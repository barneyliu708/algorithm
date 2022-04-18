using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC518CoinChange2
    {
        public int Change(int amount, int[] coins)
        {
            int[] dp = new int[amount + 1];
            dp[0] = 1;
            foreach (int coin in coins)
            {
                for (int amt = coin; amt <= amount; amt++)
                {
                    if (amt - coin >= 0)
                    {
                        dp[amt] += dp[amt - coin];
                    }
                }
            }
            return dp[amount];
        }
    }
}
