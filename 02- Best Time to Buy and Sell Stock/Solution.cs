```csharp
public class Solution
{
    // Approach 1: Brute Force
    // Time Complexity: O(n²)
    // Space Complexity: O(1)
    public int MaxProfitBruteForce(int[] prices)
    {
        int maxProfit = 0;

        for (int i = 0; i < prices.Length - 1; i++)
        {
            // Try every possible selling day
            // after the buying day.
            for (int j = i + 1; j < prices.Length; j++)
            {
                int profit = prices[j] - prices[i];

                maxProfit = Math.Max(maxProfit, profit);
            }
        }

        return maxProfit;
    }


    // Approach 2: Optimized
    // Time Complexity: O(n)
    // Space Complexity: O(1)
    public int MaxProfit(int[] prices)
    {
        int minPrice = prices[0];
        int maxProfit = 0;

        for (int i = 1; i < prices.Length; i++)
        {
            // Calculate profit if we sell today.
            int profit = prices[i] - minPrice;

            // Update the maximum profit.
            maxProfit = Math.Max(maxProfit, profit);

            // Update the minimum buying price.
            minPrice = Math.Min(minPrice, prices[i]);
        }

        return maxProfit;
    }
}
```
