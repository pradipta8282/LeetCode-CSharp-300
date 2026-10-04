One important note: the actual LeetCode requirement asks for O(n) time and O(1) extra space, so the sorting approach is better described as an improved approach, not the truly optimal solution. But I’ve kept your requested two approaches exactly in that format.

# Single Number

## Problem

Given a non-empty array of integers `nums`, every element appears twice except for one.  
Find that single one.

You must implement a solution with a linear runtime complexity and use only constant extra space.

### Example

**Input:**

```text
nums = [4,1,2,1,2]

Output:

4

Explanation:

The number 4 appears only once, while every other number appears twice.

Approach 1 — Brute Force
Key Idea

We check each element against all other elements to see if it appears only once.

For each element:

Assume the current element is unique using isUnique = true.
Compare it with every other element.
If a duplicate is found, mark it as not unique.
Break the inner loop because we already know the element is not unique.
If the element remains unique, return it.
What is isUnique?

isUnique is a boolean variable that tells us whether the current element appears only once.

Initially:

isUnique = true

If we find the same number at another index:

isUnique = false

For example:

nums = [4,1,2,1,2]

When checking 4:

4 != 1
4 != 2
4 != 1
4 != 2

No duplicate is found.

Therefore:

4 is unique

So we return:

4
C# Implementation
public class Solution
{
    // Brute Force Approach
    // Time Complexity: O(n^2)
    // Space Complexity: O(1)
    public int SingleNumber(int[] nums)
    {
        for (int i = 0; i < nums.Length; i++)
        {
            // Assume the current element is unique.
            bool isUnique = true;

            // Compare the current element with every other element.
            for (int j = 0; j < nums.Length; j++)
            {
                // Make sure we are not comparing the element with itself.
                if (i != j && nums[i] == nums[j])
                {
                    // Duplicate found.
                    isUnique = false;
                    break;
                }
            }

            // If no duplicate was found, this is the single number.
            if (isUnique)
            {
                return nums[i];
            }
        }

        return -1;
    }
}
Complexity
Time Complexity: O(n²)
Space Complexity: O(1)
Approach 2 — Optimized (Sorting)
Key Idea

After sorting the array, duplicate numbers will appear next to each other.

For example:

Before sorting:

[4,1,2,1,2]

After sorting:

[1,1,2,2,4]

Now we can check the numbers in pairs.

[1,1] → pair
[2,2] → pair
[4]   → single

The number that does not have a matching pair is the single number.

Algorithm
Sort the array using Array.Sort().
Start iterating from index 0.
Move two positions at a time using i += 2.
Compare nums[i] with nums[i + 1].
If they are different, nums[i] is the single number.
If all pairs match, the last element is the single number.
Step-by-Step Example

Given:

nums = [4,1,2,1,2]

After sorting:

[1,1,2,2,4]

Start from index 0:

nums[0] = 1
nums[1] = 1

They are equal, so this is a valid pair.

Move to index 2:

nums[2] = 2
nums[3] = 2

Again, they are equal.

Move to index 4:

nums[4] = 4

There is no matching element after it.

Therefore:

4

is the single number.

C# Implementation
public class Solution
{
    // Optimized Approach using Sorting
    // Time Complexity: O(n log n)
    // Space Complexity: O(1)
    public int SingleNumber(int[] nums)
    {
        // Sort the array so duplicate numbers
        // appear next to each other.
        Array.Sort(nums);

        // Check the elements in pairs.
        for (int i = 0; i < nums.Length - 1; i += 2)
        {
            // If the pair does not match,
            // nums[i] is the single number.
            if (nums[i] != nums[i + 1])
            {
                return nums[i];
            }
        }

        // If every pair matched,
        // the last element is the single number.
        return nums[nums.Length - 1];
    }
}
Complexity
Time Complexity: O(n log n)
Space Complexity: O(1)
C# Takeaways

While solving this problem in C#, I focused on:

Understanding nested loops for brute-force comparison
Using a boolean flag with isUnique
Using Array.Sort() to group duplicate values
Iterating through the sorted array in pairs
Using i += 2 to move from one pair to the next
Avoiding index out-of-range errors
Handling the case where the single number is the last element
Understanding the trade-off between O(n²) and O(n log n)
Summary
Approach	Time	Space
Brute Force	O(n²)	O(1)
Sorting Approach	O(n log n)	O(1)

Both approaches are implemented in Solution.cs.

Note: The actual problem requires O(n) time and O(1) extra space. The sorting approach improves the brute-force solution, but it does not meet the required linear-time constraint. The truly optimal solution uses the XOR operation and achieves O(n) time and O(1) extra space.


**One recommendation:** since you're documenting your progression from **Brute Force → Optimized → C#**, I would eventually make **XOR the Approach 3 — Optimal**, because that is the solution that actually satisfies the problem's required `O(n)` runtime and `O(1)` space.
no giv eme in a single version that chat i will copy and pastw
# Single Number

## Problem

Given a non-empty array of integers `nums`, every element appears twice except for one.  
Find that single one.

You must implement a solution with a linear runtime complexity and use only constant extra space.

### Example

**Input:**

```text
nums = [4,1,2,1,2]

Output:

4

Explanation:

The number 4 appears only once, while every other number appears twice.

Approach 1 — Brute Force
Key Idea

We check each element against all other elements to find the number that appears only once.

For each element:

Assume the current element is unique using isUnique = true.
Compare it with every other element.
If a duplicate is found, mark it as not unique.
Break the inner loop because we already know the element is not unique.
If the element remains unique, return it.
Step-by-Step Example

Consider:

nums = [4,1,2,1,2]

Start with:

nums[0] = 4

Compare 4 with every other element:

4 != 1
4 != 2
4 != 1
4 != 2

No duplicate is found.

Therefore:

4 is unique

So we return:

4
What is isUnique?

isUnique is a boolean variable used to track whether the current element has a duplicate.

Initially:

isUnique = true

If we find the same value at another index:

isUnique = false

Then we stop checking that element.

C# Implementation
public class Solution
{
    // Brute Force Approach
    // Time Complexity: O(n^2)
    // Space Complexity: O(1)
    public int SingleNumber(int[] nums)
    {
        for (int i = 0; i < nums.Length; i++)
        {
            // Assume the current element is unique.
            bool isUnique = true;

            // Compare the current element with every other element.
            for (int j = 0; j < nums.Length; j++)
            {
                // Make sure we are not comparing the element with itself.
                if (i != j && nums[i] == nums[j])
                {
                    // Duplicate found.
                    isUnique = false;
                    break;
                }
            }

            // If no duplicate was found, this is the single number.
            if (isUnique)
            {
                return nums[i];
            }
        }

        return -1;
    }
}
Complexity
Time Complexity: O(n²)
Space Complexity: O(1)
Approach 2 — Optimized (Sorting)
Key Idea

After sorting the array, duplicate numbers appear next to each other.

For example:

Before sorting:

[4,1,2,1,2]

After sorting:

[1,1,2,2,4]

Now we can compare the elements in pairs.

[1,1] → pair
[2,2] → pair
[4]   → single

The number that does not have a matching pair is the single number.

Algorithm
Sort the array using Array.Sort().
Start from index 0.
Move two positions at a time using i += 2.
Compare nums[i] with nums[i + 1].
If they are different, nums[i] is the single number.
If all pairs match, the last element is the single number.
Step-by-Step Walkthrough

Given:

nums = [4,1,2,1,2]

First, sort the array:

[1,1,2,2,4]
Step 1

Compare:

nums[0] = 1
nums[1] = 1

They are equal, so 1 is a valid pair.

Move two positions:

i = 2
Step 2

Compare:

nums[2] = 2
nums[3] = 2

They are equal, so 2 is a valid pair.

Move two positions:

i = 4
Step 3

Now:

nums[4] = 4

There is no matching element after it.

Therefore:

4

is the single number.

C# Implementation
public class Solution
{
    // Optimized Approach using Sorting
    // Time Complexity: O(n log n)
    // Space Complexity: O(1)
    public int SingleNumber(int[] nums)
    {
        // Sort the array so duplicate numbers
        // appear next to each other.
        Array.Sort(nums);

        // Check the elements in pairs.
        for (int i = 0; i < nums.Length - 1; i += 2)
        {
            // If the pair does not match,
            // nums[i] is the single number.
            if (nums[i] != nums[i + 1])
            {
                return nums[i];
            }
        }

        // If every pair matched,
        // the last element is the single number.
        return nums[nums.Length - 1];
    }
}
Complexity
Time Complexity: O(n log n)
Space Complexity: O(1)
Why Is the Sorting Approach Better?

The brute-force approach compares every element with every other element.

For n elements, this creates approximately:

n × n

comparisons.

Therefore:

O(n²)

The sorting approach first organizes the array:

[4,1,2,1,2]

        ↓ Sort

[1,1,2,2,4]

Once sorted, we only need to check neighboring pairs.

This reduces the time complexity from:

O(n²)

to:

O(n log n)

However, the problem specifically asks for O(n) time and O(1) extra space. The truly optimal solution uses the XOR operation.

C# Takeaways

While solving this problem in C#, I focused on:

Understanding nested loops for brute-force comparison
Using a boolean variable with isUnique
Using Array.Sort() to organize duplicate values
Iterating through the sorted array in pairs
Using i += 2 to move from one pair to the next
Avoiding index-out-of-range errors
Handling the case where the single number is the last element
Understanding the difference between O(n²) and O(n log n)
Understanding that sorting improves the brute-force solution but is not the final optimal solution
Summary
Approach	Time	Space
Brute Force	O(n²)	O(1)
Sorting Approach	O(n log n)	O(1)
