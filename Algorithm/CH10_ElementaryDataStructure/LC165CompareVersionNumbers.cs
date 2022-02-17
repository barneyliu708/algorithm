using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC165CompareVersionNumbers
    {
        public int CompareVersion(string version1, string version2)
        {
            int p1 = 0;
            int p2 = 0;

            while (p1 < version1.Length || p2 < version2.Length)
            {
                var kv1 = GetNextChunk(version1, p1);
                var kv2 = GetNextChunk(version2, p2);

                if (kv1.Key != kv2.Key)
                {
                    return kv1.Key > kv2.Key ? 1 : -1;
                }

                p1 = kv1.Value;
                p2 = kv2.Value;
            }

            return 0;
        }

        // return key value pair where key = revision value, value = start index of next chunk
        public KeyValuePair<int, int> GetNextChunk(string version, int p)
        {
            if (p >= version.Length)
            {
                return new KeyValuePair<int, int>(0, p);
            }

            int pEnd = p;
            while (pEnd < version.Length && version[pEnd] != '.')
            {
                pEnd++;
            }

            int revision = int.Parse(version.Substring(p, pEnd - p));

            return new KeyValuePair<int, int>(revision, pEnd + 1);
        }
    }
}
