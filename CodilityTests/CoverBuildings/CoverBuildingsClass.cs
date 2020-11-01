using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodilityTests
{
    // you can also use imports, for example:
    // import java.util.*;
    // you can write to stdout for debugging purposes, e.g.
    // System.out.println("this is a debug message");


    public class CoverBuildingsClass
    {
        public int Solution1(int[] H)
        {
            // write your code in Java SE 8

            int len = H.Length;
            int leftHi = 0;
            int leftWi = 1;
            int rightHi = 0;
            int rightWi = len;
            int min = 0;
            for (int i = 0; i < len; i++)
            {
                leftWi = i + 1;
                if (H[i] > leftHi)
                {
                    leftHi = H[i];
                }
                rightWi = len - leftWi;
                rightHi = 0;
                for (int j = len - 1; j > i; j--)
                {
                    if (H[j] > rightHi)
                    {
                        rightHi = H[j];
                    }
                }

                int plosht = leftWi * leftHi + rightWi * rightHi;

                if (plosht < min || min == 0)
                {
                    min = plosht;
                }
            }
            return min;
        }

        public int Solution2(int[] H)
        {
            // write your code in Java SE 8

            int len = H.Length;
            int[] sum = new int[len];
            sum[0] = H[0];
            int leftMax = H[0];
            for(int i=1; i < len; i++)
            {
                if (H[i] > leftMax)
                {
                    leftMax = H[i];
                }
                sum[i] = (i + 1) * leftMax;
            }

            int rightMax = H[len-1];
            sum[len - 2] += H[len - 1];
            int min = sum[len - 2];
            for(int ri = len-2; ri>0; ri--)
            {
                if (rightMax < H[ri])
                {
                    rightMax = H[ri];
                }
                sum[ri-1] += rightMax * (len - ri);
                if (sum[ri] < min)
                {
                    min = sum[ri];
                }
            }
            if (min > sum[0])
            {
                min = sum[0];
            }

            return min;
        }
    }
}