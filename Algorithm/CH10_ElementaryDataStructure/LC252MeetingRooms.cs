using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC252MeetingRooms
    {
        public bool CanAttendMeetings(int[][] intervals)
        {
            Array.Sort(intervals, (int[] x, int[] y) => { return x[0].CompareTo(y[0]); });
            for (int i = 1; i < intervals.Length; i++)
            {
                int[] cur = intervals[i];
                int[] pre = intervals[i - 1];
                if (cur[0] < pre[1])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
