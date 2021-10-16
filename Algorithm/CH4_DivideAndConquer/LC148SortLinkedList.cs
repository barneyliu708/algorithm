using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH4_DivideAndConque
{
    [TestFixture]
    public class LC148SortLinkedList
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

        public ListNode SortList(ListNode head)
        {
            int count = CountListNode(head);
            return SortList(head, count);
        }

        private ListNode SortList(ListNode head, int n)
        {
            // should use count n to check rather than the head.next
            if (n == 0)
            {
                return null;
            }

            if (n == 1)
            {
                head.next = null;
                return head;
            }

            // find the mid point and construct the root node
            // (n - 1)/2 to get the steps to the mid node
            int steps = (n - 1) / 2;
            ListNode mid_node = head;
            while (steps > 0)
            {
                steps--;
                mid_node = mid_node.next;
            }

            // sort left and right list
            ListNode sorted_right = SortList(mid_node.next, n - (n + 1) / 2); // need to constuct right first, otherwise line 38 may break mid_node.next
            ListNode sorted_left = SortList(head, (n + 1) / 2); // (n + 1)/2 to include the mid node
            

            return CombineTwoSortedList(sorted_left, sorted_right);
        }

        private int CountListNode(ListNode head)
        {
            int count = 0;
            ListNode pointer = head;
            while (pointer != null)
            {
                count++;
                pointer = pointer.next;
            }
            return count;
        }

        private ListNode CombineTwoSortedList(ListNode list1, ListNode list2)
        {
            ListNode dummy = new ListNode();
            ListNode injector = dummy;
            while (list1 != null && list2 != null)
            {
                if (list1.val < list2.val)
                {
                    injector.next = list1;
                    list1 = list1.next;
                }
                else
                {
                    injector.next = list2;
                    list2 = list2.next;
                }
                injector = injector.next;
                injector.next = null;
            }

            if (list1 != null)
            {
                injector.next = list1;
            }
            if (list2 != null)
            {
                injector.next = list2;
            }

            return dummy.next;
        }

        [Test]
        public void PositiveCaase1()
        {
            ListNode head = new ListNode(4, new ListNode(2, new ListNode(1, new ListNode(3))));
            ListNode root = SortList(head);
        }
    }
}
