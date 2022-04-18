using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC322CoinChange
    {
        public int CoinChange(int[] coins, int amount)
        {

            int[] dp = new int[amount + 1];
            for (int i = 0; i < dp.Length; i++)
            {
                dp[i] = amount + 1;
            }
            dp[0] = 0;

            for (int amt = 1; amt <= amount; amt++)
            {
                for (int j = 0; j < coins.Length; j++)
                {
                    if (coins[j] <= amt)
                    {
                        dp[amt] = Math.Min(dp[amt], dp[amt - coins[j]] + 1);
                    }
                }
            }

            return dp[amount] > amount ? -1 : dp[amount];
        }

        public class SecondDone
        {
            public int CoinChange(int[] coins, int amount)
            {
                if (amount == 0)
                {
                    return 0;
                }
                int[] dp = new int[amount + 1];
                for (int amt = 1; amt <= amount; amt++)
                {
                    // initial with Max value since we are looking for the minimum value
                    dp[amt] = int.MaxValue;
                    foreach (int coin in coins)
                    {
                        if (amt - coin >= 0 && dp[amt - coin] != -1)
                        {
                            dp[amt] = Math.Min(dp[amt], dp[amt - coin] + 1);
                        }
                    }
                    if (dp[amt] == int.MaxValue)
                    {
                        dp[amt] = -1;
                    }
                }

                return dp[amount];
            }
        }
    }
}
