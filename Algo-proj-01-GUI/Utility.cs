using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using Algo_proj_01_GUI.Properties;

namespace Algo_proj_01_GUI
{
    static class Utility
    {
        private static SubArray FindMaxCrossingSubArray(int[] A, int low, int mid, int high)
        {
            int left_sum = -100000;
            int sum = 0;
            int max_left = mid;
            SubArray crossingSubArray = new SubArray();
                // this is the object for if the contigious subArray croses the midpoint.
            //int[] values = new int[3]; // this will contain the respective low, high, sum values for each side.
            for (int i = mid; i > low; i--)
            {
                sum += A[i];
                if (sum > left_sum)
                {
                    left_sum = sum;
                    max_left = i;
                }
            }

            int right_sum = -1000000;
            int max_right = (mid + 1);
            sum = 0;
            for (int j = mid + 1; j <= high; j++)
            {
                sum += A[j];
                if (sum > right_sum)
                {
                    right_sum = sum;
                    max_right = j;
                }
            }

            // return values...
            crossingSubArray.Low = max_left;
            crossingSubArray.High = max_right;
            crossingSubArray.Sum = left_sum + right_sum;
            return crossingSubArray;
        }

        public static SubArray FindMaximumSubArray(int[] A, int low, int high)
        {
            int mid;
            SubArray initialSub = new SubArray();
            //int[] maxSubLow, maxSubHigh, maxCross;
            if (low == high)
            {
                initialSub.Low = low;
                initialSub.High = high;
                initialSub.Sum = A[low];
                return initialSub;
            }
            mid = (low + high)/2;
            var maxSubLow = FindMaximumSubArray(A, low, mid);
            var maxSubHigh = FindMaximumSubArray(A, mid + 1, high);
            var maxSubCross = FindMaxCrossingSubArray(A, low, mid, high);

            if (maxSubLow.Sum >= maxSubHigh.Sum && maxSubLow.Sum >= maxSubCross.Sum)
                return maxSubLow;
            if (maxSubHigh.Sum >= maxSubLow.Sum && maxSubHigh.Sum >= maxSubCross.Sum)
                return maxSubHigh;

            return maxSubCross;
        }

        public static Dictionary<string, string> getAllData()
        {
            Dictionary<string, string> resourceData = new Dictionary<string, string>();
            ResourceSet resourceSet = Resources.ResourceManager.GetResourceSet(CultureInfo.CurrentUICulture, true, true);
            foreach (DictionaryEntry entry in resourceSet)
            {
                var resourceKey = entry.Key;
                var resourceValue = entry.Value;
                resourceData.Add(resourceKey.ToString(), resourceValue.ToString());
            }

            return resourceData;
        }
    }
}

