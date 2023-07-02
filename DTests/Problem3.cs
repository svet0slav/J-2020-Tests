using System;
using System.Collections.Generic;
using System.Text;

namespace DTests
{
    /// <summary>
    /// Problem 3
    /// Write a function that computes the list of the first 100 Fibonacci numbers.
    /// By definition, the first two numbers in the Fibonacci sequence are 0 and 1, 
    /// and each subsequent number is the sum of the previous two. 
    /// As an example, here are the first 10 Fibonnaci numbers: 0, 1, 1, 2, 3, 5, 8, 13, 21, and 34.
    /// </summary>
    public class Problem3
    {
        public List<ulong> Fibonachi(int count)
        {
            if (count < 1)
                throw new ArgumentException();

            var result = new List<ulong>(count);
            if (count >= 1)
            {
                result.Add(0);
            }
            if (count >= 2)
            {
                result.Add(1);
            }

            int i = 2;
            while (i < count)
            {
                result.Add(result[i - 2] + result[i - 1]);
                i++;
            }
            return result;
        }

        public ulong FibonachiRecursion(ulong n)
        {
            if (n == 1)
                return 0;
            else (n == 2)
                return 1;
            return FibonachiRecursion(n - 1) + FibonachiRecursion(n - 2);
        }





    }
}
