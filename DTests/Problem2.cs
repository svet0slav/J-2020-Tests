using System;
using System.Collections.Generic;
using System.Text;

namespace DTests
{
    /// <summary>
    /// Write a function that combines two lists by alternatingly taking elements.
    /// For example: given the two lists [a, b, c] and [1, 2, 3], the function should return [a, 1, b, 2, c, 3].
    /// </summary>
    public class Problem2
    {
        List<string> list1 = new List<string>() { "a", "b", "c" };
        List<string> list2 = new List<string>() { "1", "2", "3" };

        public List<string> MergeAlternatingly()
        {
            var result = new List<string>(list1.Count + list2.Count);

            int i1 = 0, i2 = 0;
            while (i1 < list1.Count && i2 < list2.Count)
            {
                result.Add(list1[i1]);
                result.Add(list2[i2]);
                i1++;
                i2++;
            }

            if (i1 < list1.Count)
            {
                while (i1 < list1.Count)
                {
                    result.Add(list1[i1]);
                    i1++;
                }
            }

            if (i2 < list2.Count)
            {
                while (i2 < list2.Count)
                {
                    result.Add(list2[i2]);
                    i2++;
                }
            }

            return result;
        }
    }
}
