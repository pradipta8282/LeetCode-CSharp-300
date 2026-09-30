public class Solution
{
    // Brute Force
    public int MaxSubArrayBruteForce(int[] nums)
    {
        int maxSum = nums[0];

        for (int i = 0; i < nums.Length; i++)
        {
            int sum = 0;

            for (int j = i; j < nums.Length; j++)
            {
                sum += nums[j];
                maxSum = Math.Max(maxSum, sum);
            }
        }

        return maxSum;
    }

    // Kadane's Algorithm - Optimized
    public int MaxSubArrayKadane(int[] nums)
    {
        int maxSum = nums[0];
        int sum = nums[0];

        for (int i = 1; i < nums.Length; i++)
        {
            sum = Math.Max(nums[i], nums[i] + sum);
            maxSum = Math.Max(maxSum, sum);
        }

        return maxSum;
    }
}
