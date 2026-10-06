markdown
# Reverse Linked List

## Problem

Given the head of a singly linked list, reverse the list and return the reversed list.

### Example

**Input:**

head = [1,2,3,4,5]
Output:

text
[5,4,3,2,1]
Approach 1 — Brute Force
Key Idea
Store all node values in a collection, then rebuild the linked list in reverse order.

Steps:

Traverse the list and store all values in a List<int>.

Create new nodes starting from the last value.

Link them sequentially to form the reversed list.

C# Implementation
csharp
public class Solution
{
    // Brute Force Approach
    // Time Complexity: O(n)
    // Space Complexity: O(n)
    public ListNode ReverseList(ListNode head)
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
}
Complexity
Time Complexity: O(n)

Space Complexity: O(n)

Approach 2 — Optimized (In‑Place Reversal)
Key Idea
Reverse the pointers directly without using extra space.

Steps:

Maintain two pointers: prev and curr.

Store the next node temporarily.

Reverse the link (curr.next = prev).

Move both pointers forward.

When curr becomes null, prev will be the new head.

C# Implementation
csharp
public class Solution
{
    // Optimized Approach (In-place reversal)
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
Complexity
Time Complexity: O(n)

Space Complexity: O(1)

C# Takeaways
While solving this problem in C#, I focused on:

Understanding how pointers (prev, curr, next) interact.

Avoiding extra space by reversing links directly.

Visualizing pointer movement step‑by‑step.

Comparing brute‑force rebuilding vs. in‑place reversal.

Summary
Approach	Time	Space	Technique
Brute Force	O(n)	O(n)	Store values, rebuild list
Optimized	O(n)	O(1)	Reverse pointers in place
