using System;
using System.Collections.Generic;
using System.Linq;
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

        public class SecondDone
        {
            public int CompareVersion(string version1, string version2)
            {
                List<string> v1 = version1.Split('.').ToList();
                List<string> v2 = version2.Split('.').ToList();
                return CompareVersion(v1, v2);
            }

            private int CompareVersion(List<string> v1, List<string> v2)
            {
                if (v1.Count < v2.Count)
                {
                    return -CompareVersion(v2, v1);
                }

                // v1.Count >= v2.Count
                while (v1.Count > v2.Count)
                {
                    v2.Add("0");
                }

                // v1.Count == v2.Count
                for (int i = 0; i < v1.Count; i++)
                {
                    int chunk1 = int.Parse(v1[i]);
                    int chunk2 = int.Parse(v2[i]);
                    if (chunk1 != chunk2)
                    {
                        return chunk1.CompareTo(chunk2);
                    }
                }

                return 0;
            }
        }
    }
}
