using System;
// you can also use other imports, for example:
// using System.Collections.Generic;

// you can write to stdout for debugging purposes, e.g.
// Console.WriteLine("this is a debug message");

namespace CodilityTests.AP
{
    public class Task2JimmyTreesAesthetic
    {
        public int solution(int[] A)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            var size = A.Length;
            if (A == null || size < 2)
                return 0;
            var possible = 0;
            if (IsPleasing(A, -1))
            {
                return 0;
            }
            for (int i = 0; i < size; i++)
            {
                if (IsPleasing(A, i))
                {
                    possible++;
                }
            }
            return possible == 0 ? -1 : possible;
        }

        /// <summary>
        /// Is it pleasing if A, with removed tree index
        /// </summary>
        /// <param name="A">trees</param>
        /// <param name="removeIndex">removed index or -1 if none</param>
        /// <returns></returns>
        public bool IsPleasing(int[] A, int removeIndex)
        {
            int first = 0;
            if (removeIndex == 0)
                first++;
            int second = first + 1;
            if (removeIndex == second)
                second++;

            var size = A.Length;
            if (second >= size)
                return false;

            if (A[first] == A[second])
                return false;
            bool direction = A[first] < A[second]; // true if up, false if down

            int i = second;
            while (i < size-1)
            {
                if (i == removeIndex)
                {
                    i++;
                    continue;
                }
                int compare = (i + 1 == removeIndex) ? i + 2 : i + 1;
                if (compare >= size)
                    break;
                if (direction && A[i] < A[compare])
                    return false;
                if ((!direction) && A[i] > A[compare])
                    return false;
                if (A[i] == A[compare])
                    return false;

                direction = !direction;
                i++;
            }
            return true;
        }
    }
}
