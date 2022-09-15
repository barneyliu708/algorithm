using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH4_DivideAndConque
{
    [TestFixture]
    public class LC023MergeKSortedList
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

        public ListNode MergeKLists(ListNode[] lists)
        {
            if (lists == null || lists.Length == 0)
            {
                return null;
            }
            return MergeKLists(lists, 0, lists.Length - 1);
        }

        public ListNode MergeKLists(ListNode[] lists, int l, int r)
        {
            if (l == r)
            {
                return lists[l];
            }

            int mid = (l + r) / 2;
            ListNode merge_left = MergeKLists(lists, l, mid);
            ListNode merge_right = MergeKLists(lists, mid + 1, r);

            return MergeTwoLists(merge_left, merge_right);
        }

        public ListNode MergeTwoLists(ListNode list1, ListNode list2)
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
                injector.next = null; // clean up the reference
            }
            if (list1 == null)
            {
                injector.next = list2;
            }
            if (list2 == null)
            {
                injector.next = list1;
            }

            return dummy.next;
        }

        public class SecondDone_DivideAndConque_PriorityQueue
        {
            public ListNode MergeKLists(ListNode[] lists)
            {
                return MergeKLists(lists, 0, lists.Length - 1);
            }

            private ListNode MergeKLists(ListNode[] lists, int l, int r)
            {
                if (l > r)
                {
                    return null;
                }
                if (l == r)
                {
                    return lists[l];
                }

                int mid = l + (r - l) / 2;
                ListNode left = MergeKLists(lists, l, mid);
                ListNode right = MergeKLists(lists, mid + 1, r);

                return MergeTwoLists(left, right);
            }

            private ListNode MergeTwoLists(ListNode left, ListNode right)
            {
                PriorityQueue<ListNode, int> pq = new PriorityQueue<ListNode, int>();
                while (left != null)
                {
                    pq.Enqueue(left, left.val);
                    left = left.next;
                }
                while (right != null)
                {
                    pq.Enqueue(right, right.val);
                    right = right.next;
                }

                ListNode dummy = new ListNode();
                ListNode p = dummy;
                while (pq.Count > 0)
                {
                    p.next = pq.Dequeue();
                    p = p.next;
                    p.next = null; // break the original link
                }

                return dummy.next;
            }
        }

        public class ThirdDone
        {
            public ListNode MergeKLists(ListNode[] lists)
            {
                return Divide(lists, 0, lists.Length - 1);
            }

            private ListNode Divide(ListNode[] lists, int l, int r)
            {
                if (l > r)
                {
                    return null;
                }
                if (l == r)
                {
                    return lists[l];
                }

                int mid = l + (r - l) / 2;
                ListNode leftlist = Divide(lists, l, mid);
                ListNode rightlist = Divide(lists, mid + 1, r);

                return Merge(leftlist, rightlist);
            }

            private ListNode Merge(ListNode left, ListNode right)
            {
                ListNode dummy = new ListNode();
                ListNode p = dummy;
                ListNode l = left;
                ListNode r = right;
                while (l != null && r != null)
                {
                    if (l.val < r.val)
                    {
                        p.next = l;
                        l = l.next;
                    }
                    else
                    {
                        p.next = r;
                        r = r.next;
                    }
                    p = p.next;
                }

                while (l != null)
                {
                    p.next = l;
                    l = l.next;
                    p = p.next;
                }

                while (r != null)
                {
                    p.next = r;
                    r = r.next;
                    p = p.next;
                }

                return dummy.next;
            }
        }
    }
}
