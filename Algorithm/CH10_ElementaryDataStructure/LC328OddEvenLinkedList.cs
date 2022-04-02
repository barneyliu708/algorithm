using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC328OddEvenLinkedList
    {
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }
        public ListNode OddEvenList(ListNode head)
        {
            ListNode oddDummy = new ListNode();
            ListNode evenDummy = new ListNode();

            int count = 1;
            ListNode o = oddDummy;
            ListNode e = evenDummy;
            while (head != null)
            {
                if (count % 2 == 1)
                { // odd
                    o.next = head;
                    o = o.next;
                }
                else
                { // even
                    e.next = head;
                    e = e.next;
                }
                head = head.next;
                count++;
            }

            o.next = evenDummy.next;
            e.next = null;

            return oddDummy.next;
        }

        public class SecondDone
        {
            public ListNode OddEvenList(ListNode head)
            {
                ListNode oddDummy = new ListNode();
                ListNode evenDummy = new ListNode();

                ListNode o = oddDummy;
                ListNode e = evenDummy;
                int position = 1;
                while (head != null)
                {
                    if (position % 2 == 1)
                    {
                        o.next = head;
                        head = head.next;
                        o = o.next;
                        o.next = null;
                    }
                    else
                    {
                        e.next = head;
                        head = head.next;
                        e = e.next;
                        e.next = null;
                    }
                    position++;
                }
                o.next = evenDummy.next;
                return oddDummy.next;
            }
        }
    }
}
