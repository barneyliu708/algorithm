using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC251Flatten2DVector
    {
        public class Vector2D
        {

            private int[][] vectors;
            private int i;
            private int j;

            public Vector2D(int[][] vec)
            {
                vectors = vec;
                i = 0;
                j = 0;
            }

            public int Next()
            {
                while (i < vectors.Length && j == vectors[i].Length)
                {
                    i++;
                    j = 0;
                }
                return vectors[i][j++];
            }

            public bool HasNext()
            {
                while (i < vectors.Length && j == vectors[i].Length)
                {
                    i++;
                    j = 0;
                }
                return i < vectors.Length;
            }
        }

    }
}
