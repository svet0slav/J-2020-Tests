using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodilityTests.SmallestPositiveInteger
{
    public class SmallestPositiveIntegerClass
    {
        // you can also use imports, for example:
        // import java.util.*;
        // you can write to stdout for debugging purposes, e.g.
        // System.out.println("this is a debug message");
        // write your code in Java SE 8

        public int Solution1(int[] A)
        {
                
            //int min = A[0];
            int seq = 1;
            int N = A.Length;
            //int minIndex = 0;
            Boolean used = true;
            int i;
            while (used)
            {
                used = false;
                for (i = 0; i < N; i++)
                {
                    if (seq == A[i])
                    {
                        seq++;
                        //minIndex = i + 1;
                        used = true;
                    }
                }
            }
            return seq;
        }
    }
}