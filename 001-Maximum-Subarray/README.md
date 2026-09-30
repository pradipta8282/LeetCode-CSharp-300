# Maximum Subarray

## Problem

Given an integer array `nums`, find the subarray with the largest sum and return its sum.

### Example

**Input:**

```text
nums = [-2,1,-3,4,-1,2,1,-5,4]
```

**Output:**

```text
6
```

**Explanation:**

The subarray `[4,-1,2,1]` has the largest sum:

```text
4 + (-1) + 2 + 1 = 6
```

---

# Approach 1 — Brute Force

### Key Idea

We consider every possible starting position `i` and then expand the subarray using `j`.

For each starting position:

1. `i` represents the starting index of the subarray.
2. `j` starts from `i` and moves toward the end of the array.
3. `sum` keeps the current running sum.
4. After adding `nums[j]`, we compare `sum` with `maxSum`.
5. Once all `j` iterations are completed for the current `i`, we move `i` to the next position and reset `sum` to `0`.
6. `maxSum` is initialized with `nums[0]` so that the solution also works when all numbers are negative.

### Important Point

Suppose the array contains only negative numbers:

```text
[-5,-4,-3,-2,-1]
```

The answer should be `-1`, not `0`.

That's why `maxSum` starts with the first element instead of `0`.

### What is `sum`?

`sum` is a temporary/running variable. It stores the sum of the current subarray while `j` moves forward.

For example:

```text
[4,-1,2,1]
```

The running sums are:

```text
4
4 + (-1) = 3
3 + 2 = 5
5 + 1 = 6
```

### C# Implementation

```csharp
public class Solution
{
    public int MaxSubArray(int[] nums)
    {
        // maxSum starts with the first element.
        // This also handles arrays containing only negative numbers.
        int maxSum = nums[0];

        for (int i = 0; i < nums.Length; i++)
        {
            // Reset the running sum for every new starting position.
            int sum = 0;

            for (int j = i; j < nums.Length; j++)
            {
                // Add the current element to the running sum.
                sum += nums[j];

                // Update maxSum if the current subarray has a larger sum.
                maxSum = Math.Max(maxSum, sum);
            }
        }

        return maxSum;
    }
}
```

### Complexity

* **Time Complexity:** `O(n²)`
* **Space Complexity:** `O(1)`

---

# Approach 2 — Kadane's Algorithm

## Optimized Approach

Instead of checking every possible subarray, Kadane's Algorithm makes a decision at every element.

At each position, we ask:

> **Should I start a new subarray from the current element, or should I continue the previous subarray?**

We calculate:

```text
sum = max(nums[i], nums[i] + sum)
```

In C#:

```csharp
sum = Math.Max(nums[i], nums[i] + sum);
```

This means:

* `nums[i]` → Start a new subarray from the current element.
* `nums[i] + sum` → Continue the previous subarray.

Then we keep track of the best sum found so far:

```text
maxSum = max(maxSum, sum)
```

In C#:

```csharp
maxSum = Math.Max(maxSum, sum);
```

### C# Implementation

```csharp
public class Solution
{
    public int MaxSubArray(int[] nums)
    {
        // Start with the first element.
        // This handles arrays containing only negative numbers.
        int maxSum = nums[0];
        int sum = nums[0];

        for (int i = 1; i < nums.Length; i++)
        {
            // Either:
            // 1. Start a new subarray from nums[i]
            // 2. Continue the previous subarray
            sum = Math.Max(nums[i], nums[i] + sum);

            // Keep track of the best sum found so far.
            maxSum = Math.Max(maxSum, sum);
        }

        return maxSum;
    }
}
```

### Complexity

* **Time Complexity:** `O(n)`
* **Space Complexity:** `O(1)`

---

# C# Takeaways

While solving this problem in C#, I focused on:

* Using `Math.Max()`
* Maintaining a running sum
* Correct variable initialization
* Handling all-negative arrays
* Understanding nested loops for the brute-force approach
* Understanding how an optimized approach can reduce `O(n²)` to `O(n)`

## Summary

| Approach           |    Time |  Space |
| ------------------ | ------: | -----: |
| Brute Force        | `O(n²)` | `O(1)` |
| Kadane's Algorithm |  `O(n)` | `O(1)` |

Both approaches are implemented in `Solution.cs`.
