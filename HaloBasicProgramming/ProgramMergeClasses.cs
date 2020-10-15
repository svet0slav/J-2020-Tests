using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace HaloBasicProgramming
{
    public class TaskMergeClasses
    {

        public static int[] merge(int[] a, int[] b)
        {
            // Write Your Code Here

            List<int> list = new List<int>();
            int ia = 0;
            int ib = 0;
            while (ia < a.Length && ib < b.Length)
            {
                if (a[ia] < b[ib])
                {
                    list.Add(a[ia]);
                    ia++;
                }
                else
                {
                    list.Add(b[ib]);
                    ib++;
                }
            }
            while (ia < a.Length)
            {
                list.Add(a[ia]);
                ia++;
            }
            while (ib < b.Length)
            {
                list.Add(b[ib]);
                ib++;
            }

            return list.ToArray();

        }

        static void MainMergeClasses(string[] args)
        {
            TextWriter tw = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int[] a = Array.ConvertAll(Console.ReadLine().Split(','), int.Parse);
            int[] b = Array.ConvertAll(Console.ReadLine().Split(','), int.Parse);

            int[] result = merge(a, b);

            tw.WriteLine(string.Join(",", result));

            tw.Flush();
            tw.Close();
        }
    }
}