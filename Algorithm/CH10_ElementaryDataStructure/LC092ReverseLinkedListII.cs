using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC092ReverseLinkedListII
    {
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x = 0)
            {
                val = x;
                next = null;
            }
        }
        public ListNode ReverseBetween(ListNode head, int left, int right)
        {
            if (head == null || head.next == null)
            {
                return head;
            }

            ListNode dummy = new ListNode();
            dummy.next = head;
            ListNode preNode = null, leftNode = null, rightNode = null;
            ListNode cur = dummy;
            int position = 0;
            while (cur != null)
            {
                if (position == left - 1)
                {
                    preNode = cur;
                }
                if (position == left)
                {
                    leftNode = cur;
                }
                if (position == right)
                {
                    rightNode = cur;
                }

                cur = cur.next;
                position++;
            }

            ListNode rightnext = rightNode.next;
            rightNode.next = null; // break the chain

            ListNode reversed = Reverse(leftNode);
            leftNode.next = rightnext;
            preNode.next = reversed;

            return dummy.next;
        }

        private ListNode Reverse(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return head;
            }

            ListNode next = head.next;
            head.next = null; // break the chain

            ListNode reversed = Reverse(next);
            next.next = head;

            return reversed;
        }
    }
}
