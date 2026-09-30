# Best Time to Buy and Sell Stock

## Problem

You are given an array `prices` where `prices[i]` represents the price of a stock on the `ith` day.

You want to maximize your profit by choosing:

* One day to **buy** the stock.
* A different day **in the future** to **sell** the stock.

Return the maximum profit you can achieve.

If no profit can be made, return `0`.

### Example 1

**Input:**

```text
prices = [7,1,5,3,6,4]
```

**Output:**

```text
5
```

**Explanation:**

The best choice is:

```text
Buy  → price = 1
Sell → price = 6
```

Profit:

```text
6 - 1 = 5
```

We cannot buy at `7` and sell at `1` because the stock must be bought **before** it is sold.

### Example 2

**Input:**

```text
prices = [7,6,4,3,1]
```

**Output:**

```text
0
```

**Explanation:**

The prices continuously decrease, so there is no profitable transaction.

Therefore, the maximum profit is:

```text
0
```

### Constraints

* `1 <= prices.length <= 10^5`
* `0 <= prices[i] <= 10^4`

---

# Approach 1 — Brute Force

## Key Idea

The basic idea is to try **every possible pair of buy and sell days**.

For every day `i`:

1. Treat `i` as the buying day.
2. Start `j` from `i + 1` because we must sell **after** buying.
3. Calculate the profit:

```text
profit = prices[j] - prices[i]
```

4. Compare this profit with the maximum profit found so far.
5. Continue checking all possible selling days.
6. Move `i` to the next possible buying day.

In other words, we check every possible transaction:

```text
Buy on day i
Sell on day j
where i < j
```

### Why does `j` start from `i + 1`?

Suppose:

```text
prices = [7,1,5,3,6,4]
```

If we buy on day `1`:

```text
price = 1
```

we can only sell on a later day:

```text
5
3
6
4
```

We cannot sell on the same day.

Therefore:

```text
j = i + 1
```

### Profit Formula

For every pair of days:

```text
profit = sellingPrice - buyingPrice
```

For example:

```text
buy = 1
sell = 6

profit = 6 - 1
       = 5
```

We keep the largest profit.

## C# Implementation

```csharp
public class Solution
{
    public int MaxProfit(int[] prices)
    {
        int maxProfit = 0;

        // Choose the buying day.
        // We do not need the last day because
        // there is no future day available for selling.
        for (int i = 0; i < prices.Length - 1; i++)
        {
            // Choose the selling day.
            // j starts from i + 1 because
            // selling must happen after buying.
            for (int j = i + 1; j < prices.Length; j++)
            {
                // Calculate the profit for this transaction.
                int profit = prices[j] - prices[i];

                // Update the maximum profit if this
                // transaction gives us a better result.
                maxProfit = Math.Max(maxProfit, profit);
            }
        }

        return maxProfit;
    }
}
```

## Example Walkthrough

For:

```text
prices = [7,1,5,3,6,4]
```

Some of the transactions we check are:

```text
Buy 7 → Sell 1 = -6
Buy 7 → Sell 5 = -2
Buy 7 → Sell 3 = -4
Buy 7 → Sell 6 = -1
Buy 7 → Sell 4 = -3

Buy 1 → Sell 5 = 4
Buy 1 → Sell 3 = 2
Buy 1 → Sell 6 = 5
Buy 1 → Sell 4 = 3
```

The largest profit is:

```text
5
```

Therefore:

```text
Output = 5
```

## Complexity

There are two nested loops.

* **Time Complexity:** `O(n²)`
* **Space Complexity:** `O(1)`

The brute-force approach works conceptually, but with `prices.length` up to `10^5`, checking every pair is too expensive.

---

# Approach 2 — Optimized

## Key Idea

Instead of checking every possible pair of days, we can solve the problem in **one pass** through the array.

The main observation is:

> For every selling day, we only need to know the minimum price that appeared before that day.

The profit is:

```text
profit = currentPrice - minimumBuyPrice
```

So while traversing the array, we maintain two variables:

```text
minPrice
maxProfit
```

### What is `minPrice`?

`minPrice` stores the lowest stock price we have seen so far.

For example:

```text
prices = [7,1,5,3,6,4]
```

While traversing:

```text
7 → minPrice = 7
1 → minPrice = 1
5 → minPrice = 1
3 → minPrice = 1
6 → minPrice = 1
4 → minPrice = 1
```

### What is `maxProfit`?

`maxProfit` stores the best profit we have found so far.

For every price, we calculate:

```text
profit = currentPrice - minPrice
```

Then:

```text
maxProfit = Math.Max(maxProfit, profit)
```

### Important Point

We update the minimum price as we move from left to right.

This automatically guarantees that the buying day comes **before** the selling day.

For example:

```text
[7,1,5,3,6,4]
```

When we reach `6`:

```text
minimum price before 6 = 1
```

Therefore:

```text
profit = 6 - 1
       = 5
```

We never use a future price as the buying price.

This prefix-minimum approach is also the standard `O(n)` formulation: maintain the minimum price seen so far and compare each current price against it.

## C# Implementation

```csharp
public class Solution
{
    public int MaxProfit(int[] prices)
    {
        // The first price is our initial minimum buying price.
        int minPrice = prices[0];

        // If no profitable transaction exists,
        // the answer should remain 0.
        int maxProfit = 0;

        // Start from the second day because the first day
        // is already used to initialize minPrice.
        for (int i = 1; i < prices.Length; i++)
        {
            // Calculate the profit if we sell today.
            int profit = prices[i] - minPrice;

            // Keep the maximum profit found so far.
            maxProfit = Math.Max(maxProfit, profit);

            // Update the minimum buying price.
            minPrice = Math.Min(minPrice, prices[i]);
        }

        return maxProfit;
    }
}
```

## Example Walkthrough

Consider:

```text
prices = [7,1,5,3,6,4]
```

Initially:

```text
minPrice = 7
maxProfit = 0
```

### Price = 1

```text
profit = 1 - 7
       = -6
```

No profit:

```text
maxProfit = 0
```

Update minimum:

```text
minPrice = 1
```

### Price = 5

```text
profit = 5 - 1
       = 4
```

Update:

```text
maxProfit = 4
```

### Price = 3

```text
profit = 3 - 1
       = 2
```

`4` is still better:

```text
maxProfit = 4
```

### Price = 6

```text
profit = 6 - 1
       = 5
```

Update:

```text
maxProfit = 5
```

### Price = 4

```text
profit = 4 - 1
       = 3
```

The maximum remains:

```text
maxProfit = 5
```

Therefore:

```text
Output = 5
```

---

# Why the Optimized Approach Works

The important observation is that we don't need to remember every previous price.

For the current selling price, only one previous value matters:

```text
the minimum price seen so far
```

Suppose:

```text
prices = [7,1,5,3,6,4]
```

When the current price is:

```text
6
```

we only care about the cheapest buying opportunity before it:

```text
minPrice = 1
```

So:

```text
profit = 6 - 1
       = 5
```

There is no reason to compare `6` with every previous price individually.

This reduces the solution from:

```text
O(n²)
```

to:

```text
O(n)
```

---

# C# Takeaways

While solving this problem in C#, I focused on:

* Understanding nested loops for the brute-force approach.
* Making sure the buying day always comes before the selling day.
* Using `Math.Max()` to maintain the maximum profit.
* Using `Math.Min()` to maintain the minimum buying price.
* Understanding how a two-loop solution can be optimized into a single loop.
* Maintaining only the information that is necessary for the current calculation.
* Using `O(1)` extra space.

## Summary

| **Approach** | **Time** | **Space** |
| ------------ | -------: | --------: |
| Brute Force  |  `O(n²)` |    `O(1)` |
| Optimized    |   `O(n)` |    `O(1)` |

The brute-force approach checks every possible buy/sell pair, while the optimized approach keeps the minimum price seen so far and calculates the best possible profit at each selling price.
