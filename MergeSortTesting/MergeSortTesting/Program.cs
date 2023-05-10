class alog
{
    public static int[] MergeSort(int[] nums)
    {
        if (nums.Length == 1)
        {
            return nums;
        }

        int[] left;
        int[] right;

        SplitArray(nums, out left, out right);

        left = MergeSort(left);
        right = MergeSort(right);

        return MergeArrays(left, right);
    }

    private static int[] MergeArrays(int[] left, int[] right)
    {
        int offset1 = 0; // Left array offset
        int offset2 = 0; // Right array offset
        int resPtr = 0;  // Pointer for result array

        int[] res = new int[left.Length + right.Length];

        while (resPtr <= (res.Length - 1))
        {
            if (left[offset1] > right[offset2])
            {
                res[resPtr++] = left[offset1];
                offset1++;
                continue;
            }
            else
            {
                res[resPtr++] = right[offset2];
                offset2++;
                continue;
            }
            
        }

        return res;
    }

    private static void SplitArray(int[] nums, out int[] left, out int[] right)
    {
        int mid = (nums.Length - 1) / 2;

        left = SpliceArray(nums, 0, mid);
        right = SpliceArray(nums, mid+1, nums.Length - 1);
    }

    private static int[] SpliceArray(int[] nums, int start, int end)
    {
        int[] res = new int[(end - start) + 1];

        for (int i= start; i <= end; i++)
        {
            res[i-start] = nums[i];
        }

        return res;

    }


}


class Program
{
    static void Main(string[] args)
    {
        int[] nums = { 1, 2, 3, 4, 5, 6, 7 };

        nums = alog.MergeSort(nums);

        foreach (int n in nums)
        {
            Console.Write($"{n}, ");
        }
    }
}