using System;
using System.Collections.Generic;

namespace Bubble_Sort
{
    class Program
    {
        static bool Sorted(List<double> nums)
        {
            for (int i = 0; i < nums.Count - 1; i++)
            {
                if (nums[i] < nums[i + 1])
                {
                    continue;
                } else
                {
                    return false;
                }
            }

            return true;
        }

        static void Sort(ref List<double> nums)
        {
            do
            {
                for (int i = 0; i < nums.Count - 1; i++)
                {
                    if (nums[i] > nums[i + 1])
                    {
                        double temp = nums[i + 1];
                        nums[i + 1] = nums[i];
                        nums[i] = temp;
                    }
                    else
                    {
                        continue;
                    }
                }
            } while (!(Sorted(nums)));
        }

        static void Main(string[] args)
        {
            List<double> numbers = new List<double>();
            string inp = "";
            while (inp != "sort")
            {
                Console.Write("Input: ");
                inp = Console.ReadLine();
                if (inp != "sort")
                {
                    numbers.Add(Convert.ToDouble(inp));
                }
            }

            Sort(ref numbers);
            foreach (double num in numbers)
            {
                Console.WriteLine(num);
            }
        }
    }
}
