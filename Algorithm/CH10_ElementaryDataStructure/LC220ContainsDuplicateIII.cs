using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    [TestFixture]
    internal class LC220ContainsDuplicateIII
    {
        public bool ContainsNearbyAlmostDuplicate(int[] nums, int k, int t)
        {
            if (t < 0)
            {
                return false;
            }

            Dictionary<long, long> buckets = new Dictionary<long, long>();
            long width = (long)t + 1; // example: when width = 5, the maximum value difference is 4

            for (int i = 0; i < nums.Length; i++)
            {
                long bucketId = GetBucketId(nums[i], width);
                if (buckets.ContainsKey(bucketId))
                {
                    return true;
                }
                if (buckets.ContainsKey(bucketId - 1) && Math.Abs(nums[i] - buckets[bucketId - 1]) <= t)
                {
                    return true;
                }
                if (buckets.ContainsKey(bucketId + 1) && Math.Abs(nums[i] - buckets[bucketId + 1]) <= t)
                {
                    return true;
                }

                buckets[bucketId] = nums[i];

                if (i >= k)
                {
                    buckets.Remove(GetBucketId(nums[i - k], width));
                }
            }

            return false;
        }

        // Get the ID of the bucket from element value x and bucket width w
        // In Java/C#, `-3 / 5 = 0` and but we need `-3 / 5 = -1`.
        // example: width = 5
        // butck -2 = [-10, -9, -8, -7, -6]
        // butck -1 = [-5, -4, -3, -2, -1]
        // butck  0 = [0, 1, 2, 3, 4]
        // butck  1 = [5, 6, 7, 8, 9]
        private long GetBucketId(long val, long width)
        {
            return val < 0 ? (val + 1) / width - 1 : val / width;
        }
    }
}
