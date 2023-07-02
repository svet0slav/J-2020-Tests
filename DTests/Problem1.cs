using System.Collections.Generic;

namespace DTests
{
    /// <summary>
    /// Problem 1 -     Write three functions that compute the sum of the numbers in a given list
    /// using a for-loop, a while-loop, and recursion.
    /// </summary>
    public class Problem1
    {
        List<double> list = new List<double>() { 1, 2, 5, 6, 55, 7, 3 };

        public double SumFor()
        {
            double sum = 0;
            var count = list.Count;
            for (int i=0; i < count; i++)
            {
                sum += list[i];
            }
            return sum;
        }

        public double SumWhile()
        {
            double sum = 0;
            var count = list.Count;
            int i = 0;
            while (i < count && i<999999)
            {
                sum += list[i];
                i++;
            }
            return sum;
        }

        public double SumRecursion()
        {
            return SumRecursionInternal(0, list.Count-1);
            // var 2: return SumRecursionInternal(list);
        }

        protected double SumRecursionInternal(int index1, int index2)
        {
            if (index1 < index2)
            {
                return list[index1] + list[index2] + SumRecursionInternal(index1 + 1, index2 -1);
            }
            else if (index1 == index2)
            {
                return list[index1];
            }
            return 0;

            //var2 : return list[0] + SumRecursionInternal(new List<double>(list.Substr(1,count-1)));
        }
    }
}
