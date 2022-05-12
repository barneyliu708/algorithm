using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC146LRUCache
    {
        public class LRUCache
        {

            public class DLinkedNode
            {
                public int key;
                public int val;
                public DLinkedNode prev;
                public DLinkedNode next;
            }

            private int capacity;
            private int size;
            private DLinkedNode head;
            private DLinkedNode tail;
            private Dictionary<int, DLinkedNode> map;

            private void AddNode(DLinkedNode node)
            {
                node.prev = this.head;
                node.next = this.head.next;

                this.head.next.prev = node;
                this.head.next = node;
            }

            private void RemoveNode(DLinkedNode node)
            {
                DLinkedNode prevNode = node.prev;
                DLinkedNode nextNode = node.next;

                prevNode.next = nextNode;
                nextNode.prev = prevNode;
            }

            private void MoveToHead(DLinkedNode node)
            {
                RemoveNode(node);
                AddNode(node);
            }

            private DLinkedNode PopTail()
            {
                DLinkedNode node = tail.prev;
                RemoveNode(node);
                return node;
            }

            public LRUCache(int capacity)
            {
                this.capacity = capacity;
                this.size = 0;
                this.map = new Dictionary<int, DLinkedNode>();

                this.head = new DLinkedNode();
                this.tail = new DLinkedNode();
                this.head.next = this.tail;
                this.tail.prev = this.head;

            }

            public int Get(int key)
            {

                if (!map.ContainsKey(key))
                {
                    return -1;
                }

                DLinkedNode node = map[key];
                MoveToHead(node);

                return node.val;
            }

            public void Put(int key, int value)
            {

                if (!map.ContainsKey(key))
                {

                    DLinkedNode node = new DLinkedNode();
                    node.key = key;
                    node.val = value;
                    map[key] = node;

                    AddNode(node);
                    size++;

                    if (size > capacity)
                    {
                        DLinkedNode leastnode = PopTail();
                        map.Remove(leastnode.key);
                        size--;
                    }
                }
                else
                {
                    DLinkedNode node = map[key];
                    node.val = value;
                    MoveToHead(node);
                }
            }


        }

        public class SecondDone
        {
            public class LRUCache
            {

                private Dictionary<int, int> map;
                private Dictionary<int, LinkedListNode<int>> lruMap;
                private LinkedList<int> lru;
                private int capacity;

                public LRUCache(int capacity)
                {
                    this.capacity = capacity;
                    lruMap = new Dictionary<int, LinkedListNode<int>>();
                    map = new Dictionary<int, int>();
                    lru = new LinkedList<int>();
                }

                public int Get(int key)
                {
                    if (lruMap.ContainsKey(key))
                    {
                        int val = map[key];
                        lru.Remove(lruMap[key]);
                        LinkedListNode<int> newNode = lru.AddFirst(key);
                        lruMap[key] = newNode;
                        return val;
                    }
                    return -1;
                }

                public void Put(int key, int value)
                {
                    if (lruMap.ContainsKey(key))
                    {
                        lru.Remove(lruMap[key]); // o(1)
                    }
                    LinkedListNode<int> newNode = lru.AddFirst(key);
                    lruMap[key] = newNode;
                    map[key] = value;

                    if (lru.Count > capacity)
                    {
                        int last = lru.Last.Value;
                        lru.RemoveLast();
                        lruMap.Remove(last);
                    }

                }
            }
        }
    }
}
