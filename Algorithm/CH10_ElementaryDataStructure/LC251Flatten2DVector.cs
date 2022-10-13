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

        public class SecondDone
        {
            public class Vector2D
            {
                private int i = 0;
                private int j = 0;
                private int[][] vec;

                public Vector2D(int[][] vec)
                {
                    this.vec = vec;
                }

                public int Next()
                {
                    int ans = vec[i][j];
                    j++;
                    while (i < vec.Length && j >= vec[i].Length)
                    {
                        i++;
                        j = 0;
                    }
                    return ans;
                }

                public bool HasNext()
                {
                    while (i < vec.Length && j >= vec[i].Length)
                    {
                        i++;
                        j = 0;
                    }
                    return i < vec.Length;
                }
            }
        }

    }
}
