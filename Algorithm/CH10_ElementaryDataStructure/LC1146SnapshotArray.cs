using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC1146SnapshotArray
    {
        public class SnapshotArray
        {

            private int snapId;
            private Dictionary<int, int>[] snapMap;

            public SnapshotArray(int length)
            {
                snapId = 0;
                snapMap = new Dictionary<int, int>[length];
                for (int i = 0; i < length; i++)
                {
                    snapMap[i] = new Dictionary<int, int>() { { snapId, 0 } };
                }
            }

            public void Set(int index, int val)
            {
                snapMap[index][snapId] = val;
            }

            public int Snap()
            {
                return snapId++;
            }

            public int Get(int index, int snap_id)
            {
                while (!snapMap[index].ContainsKey(snap_id))
                {
                    snap_id--;
                }
                return snapMap[index][snap_id]; // will always has a result because the snapMap is initiated with 0 - 0 in the constructor
            }
        }
    }
}
