using System.Collections.Generic;

namespace DTests
{
    /// <summary>
    /// Problem 4
    /// Write a function that given a list of non negative integers, 
    /// arranges them such that they form the largest possible number.
    /// For example, given[50, 2, 1, 9], the largest formed number is 95021.
    /// </summary>
    public class Problem4
    {
        public List<uint> list = new List<uint>() { 50, 2, 101, 900, 65, 67, 1, 90, 9 };

        public List<uint> LargestNumber()
        {
            var result = new List<uint>(list.Count);
            result.Add(list[0]);
            for (int i = 1;  i < list.Count; i++)
            {
                bool included = false;
                var number = list[i];
                // insert a number in the result list sorted descending
                for (int ri = 0; ri < result.Count; ri++)
                {
                    var compResult = Pogolyamo(result[ri], number);
                    if (compResult == -1)
                    {
                        result.Insert(ri, number);
                        included = true;
                        break;
                    }
                }
                if (!included)
                {
                    result.Add(number);
                }
            }

            return result;
        }

        /// <summary>
        /// Compare two numbers and returns result.
        /// </summary>
        /// <param name="chislo1"></param>
        /// <param name="chislo2"></param>
        /// <returns>
        /// -1 chislo1 < chislo2
        /// +1 chislo1 > chislo2
        /// 0  chislo1 = chislo2
        /// </returns>
        protected int Pogolyamo(uint chislo1 , uint chislo2)
        {
            const string golemina = "9876543210";
            var s1 = chislo1.ToString();
            var s2 = chislo2.ToString();
            int i = 0;
            while (i < s1.Length && i < s2.Length)
            {
                var index1 = golemina.IndexOf(s1[i]);
                var index2 = golemina.IndexOf(s2[i]);
                if (index1 < index2)
                    return 1;
                else if (index1 > index2)
                    return -1;

                i++;
            }

            if (s1.Length == s2.Length)
                return 0;
            else if (i >= s1.Length)
                return 1;
            else if (i >= s2.Length)
                return -1;
            return 0;
        }
    }
}
