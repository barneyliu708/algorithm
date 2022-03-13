using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC297SerializeAndDeserializeBinaryTree
    {
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }

        public class DftApproach
        {
            public class Codec
            {

                // Encodes a tree to a single string.
                public string serialize(TreeNode root)
                {

                    StringBuilder sb = new StringBuilder();
                    serialize(root, sb);

                    return sb.ToString();
                }

                private void serialize(TreeNode root, StringBuilder sb)
                {

                    if (root == null)
                    {
                        sb.Append("null,");
                        return;
                    }

                    sb.Append(root.val + ",");
                    serialize(root.left, sb);
                    serialize(root.right, sb);
                }

                // Decodes your encoded data to tree.
                public TreeNode deserialize(string data)
                {
                    List<string> datalist = data.Split(',').ToList();
                    return deserialize(datalist);
                }

                private TreeNode deserialize(List<string> datalist)
                {

                    if (datalist[0] == "null")
                    {
                        datalist.RemoveAt(0);
                        return null;
                    }

                    TreeNode root = new TreeNode(int.Parse(datalist[0]));
                    datalist.RemoveAt(0);
                    root.left = deserialize(datalist);
                    root.right = deserialize(datalist);

                    return root;
                }
            }
        }
    }
}
