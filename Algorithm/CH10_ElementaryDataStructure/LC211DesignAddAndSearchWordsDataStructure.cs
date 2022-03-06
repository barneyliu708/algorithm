using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC211DesignAddAndSearchWordsDataStructure
    {
        public class WordDictionary
        {

            private TrieNode trie;

            public WordDictionary()
            {
                trie = new TrieNode();
            }

            public void AddWord(string word)
            {
                TrieNode cur = trie;
                foreach (char ch in word)
                {
                    if (!cur.children.ContainsKey(ch))
                    {
                        cur.children[ch] = new TrieNode();
                    }
                    cur = cur.children[ch];
                }
                cur.word = true;
            }

            public bool Search(string word)
            {
                return Search(word, trie);
            }

            private bool Search(string word, TrieNode cur)
            {
                for (int i = 0; i < word.Length; i++)
                {
                    char ch = word[i];
                    if (!cur.children.ContainsKey(ch))
                    {
                        if (ch == '.')
                        {
                            foreach (TrieNode node in cur.children.Values)
                            {
                                if (Search(word.Substring(i + 1), node))
                                {
                                    return true;
                                }
                            }
                        }
                        return false;
                    }
                    cur = cur.children[ch];
                }
                return cur.word;
            }
        }

        public class TrieNode
        {
            public Dictionary<char, TrieNode> children = new Dictionary<char, TrieNode>();
            public bool word = false;
        }
    }
}
