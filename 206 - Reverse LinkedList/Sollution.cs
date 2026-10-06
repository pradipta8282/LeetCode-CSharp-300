/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */

public class Solution
{
    // Approach 1 — Brute Force
    // Time Complexity: O(n)
    // Space Complexity: O(n)
    public ListNode ReverseList_BruteForce(ListNode head)
    {
        if (head == null) return null;

        // Step 1: Store all values
        List<int> values = new List<int>();
        ListNode current = head;
        while (current != null)
        {
            values.Add(current.val);
            current = current.next;
        }

        // Step 2: Create new nodes in reverse order
        ListNode newHead = new ListNode(values[values.Count - 1]);
        ListNode temp = newHead;

        for (int i = values.Count - 2; i >= 0; i--)
        {
            temp.next = new ListNode(values[i]);
            temp = temp.next;
        }

        return newHead;
    }

    // Approach 2 — Optimized (In-place reversal)
    // Time Complexity: O(n)
    // Space Complexity: O(1)
    public ListNode ReverseList(ListNode head)
    {
        ListNode prev = null;
        ListNode curr = head;

        while (curr != null)
        {
            ListNode next = curr.next; // Step 1: store next node
            curr.next = prev;          // Step 2: reverse pointer
            prev = curr;               // Step 3: move prev forward
            curr = next;               // Step 4: move curr forward
        }

        return prev; // prev becomes the new head
    }
}
