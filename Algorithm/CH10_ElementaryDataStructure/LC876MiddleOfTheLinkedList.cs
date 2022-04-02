using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC876MiddleOfTheLinkedList
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
        public ListNode MiddleNode(ListNode head)
        {
            ListNode dummy = new ListNode();
            dummy.next = head;
            ListNode f = dummy;
            ListNode s = dummy;

            while (f.next != null && f.next.next != null)
            {
                f = f.next.next;
                s = s.next;
            }

            return s.next;
        }

        public class SecondDone
        {
            public ListNode MiddleNode(ListNode head)
            {
                ListNode f = head;
                ListNode s = head;
                while (f != null && f.next != null)
                {
                    f = f.next.next;
                    s = s.next;
                }
                return s;
            }
        }
    }
}
