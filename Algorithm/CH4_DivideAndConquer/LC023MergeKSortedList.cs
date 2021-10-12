﻿using NUnit.Framework;
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
    }
}