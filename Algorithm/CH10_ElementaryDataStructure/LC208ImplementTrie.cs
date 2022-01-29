using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC208ImplementTrie
    {
        public class Trie
        {

            private TrieNode root;

            public Trie()
            {
                root = new TrieNode();
            }

            public void Insert(string word)
            {

                TrieNode node = root;
                for (int i = 0; i < word.Length; i++)
                {
                    if (!node.ContainsKey(word[i]))
                    {
                        node.Put(word[i], new TrieNode());
                    }
                    node = node.Get(word[i]);
                }
                node.SetEnd();
            }

            public bool Search(string word)
            {
                TrieNode node = SearchPrefix(word);
                return node != null && node.IsEnd();
            }

            public bool StartsWith(string prefix)
            {
                TrieNode node = SearchPrefix(prefix);
                return node != null;
            }

            private TrieNode SearchPrefix(string word)
            {
                TrieNode node = root;
                for (int i = 0; i < word.Length; i++)
                {
                    if (node.ContainsKey(word[i]))
                    {
                        node = node.Get(word[i]);
                    }
                    else
                    {
                        return null;
                    }
                }
                return node;
            }

            public class TrieNode
            {

                private TrieNode[] links;

                private int R = 26;

                private bool isEnd;

                public TrieNode()
                {
                    links = new TrieNode[R];
                }

                public bool ContainsKey(char ch)
                {
                    return links[ch - 'a'] != null;
                }

                public TrieNode Get(char ch)
                {
                    return links[ch - 'a'];
                }

                public void Put(char ch, TrieNode node)
                {
                    links[ch - 'a'] = node;
                }

                public void SetEnd()
                {
                    isEnd = true;
                }

                public bool IsEnd()
                {
                    return isEnd;
                }
            }
        }
    }
}
