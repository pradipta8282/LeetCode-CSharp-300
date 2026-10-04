public class Solution
{
    // Brute Force
    public int SingleNumberBruteForce(int[] nums)
    {
        for (int i = 0; i < nums.Length; i++)
        {
            bool isUnique = true;

            for (int j = 0; j < nums.Length; j++)
            {
                if (i != j && nums[i] == nums[j])
                {
                    isUnique = false;
                    break;
                }
            }

            if (isUnique)
            {
                return nums[i];
            }
        }

        return -1;
    }

    // Sorting - Optimized
    public int SingleNumberSorting(int[] nums)
    {
        Array.Sort(nums);

        for (int i = 0; i < nums.Length - 1; i += 2)
        {
            if (nums[i] != nums[i + 1])
            {
                return nums[i];
            }
        }

        return nums[nums.Length - 1];
    }
}
