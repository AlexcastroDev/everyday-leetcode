# Challenge

https://leetcode.com/problems/maximum-product-difference-between-two-pairs/

# First Try

```charp
public class Solution {
    public int MaxProductDifference(int[] nums) {
        Array.Sort(nums);
        
        var size = nums.Length;
        var LastMin = nums[0];
        var LastMax = nums[1];
        var FirstMin = nums[size - 1];
        var FirstMax = nums[size - 2];

        return (FirstMin * FirstMax) - (LastMin * LastMax);
    }
}
```

# Results
Runtime:

112ms
Beats 10.67%of users with C#

Memory usage:

45.54MB
Beats 80.00%of users with C#

# Second Try

```charp
public class Solution {
    public int MaxProductDifference(int[] nums) {
        var LastMax = 0;
        var LastMin = 0;
        var FirstMax = Int32.MaxValue;
        var FirstMin = Int32.MaxValue;

        foreach (var n in nums) {
            if(n < FirstMin) {
                FirstMax = FirstMin;
                FirstMin = n;
            } else if (n < FirstMax) {
                FirstMax = n;
            }

            if (n > LastMax) {
                LastMin = LastMax;
                LastMax = n;
            } else if (n > LastMin) {
                LastMin = n;
            }
        }

        return (LastMin * LastMax) - (FirstMax * FirstMin);
    }
}
```

# Results

Runtime:

Details
91ms
Beats 95.65% of users with C#


Memory usage:

45.40MB
Beats 84.06%of users with C#

# Conclusion

In C#, sort is a IntroSort, which is a hybrid sorting algorithm, derived from QuickSort, HeapSort, and InsertionSort.

But for this problem, I don't need to sort all the numbers. I just need to find the first 2 min and first 2 max numbers.