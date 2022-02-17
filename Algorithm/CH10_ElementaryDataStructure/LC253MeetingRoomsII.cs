using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC253MeetingRoomsII
    {
        public int MinMeetingRooms(int[][] intervals)
        {

            int[] starts = new int[intervals.Length];
            int[] ends = new int[intervals.Length];

            for (int i = 0; i < intervals.Length; i++)
            {
                starts[i] = intervals[i][0];
                ends[i] = intervals[i][1];
            }

            Array.Sort(starts);
            Array.Sort(ends);

            int si = 0;
            int ei = 0;
            int rooms = 0;
            int ans = 0;
            while (si < starts.Length)
            {
                if (starts[si] < ends[ei])
                {
                    rooms++;
                    si++;
                }
                else if (starts[si] > ends[ei])
                {
                    rooms--;
                    ei++;
                }
                else
                {
                    si++;
                    ei++;
                }
                ans = Math.Max(ans, rooms);
            }
            return ans;
        }
    }
}
