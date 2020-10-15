using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace HaloBasicProgramming
{
    public class TaskGoedel
    {

        public static String godelEncode(List<string> L, string s)
        {
            long[] primitive = new long[] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97 };

            long sum = 1;
            for (int i = 0; i < s.Length; i++)
            {
                var index = L.IndexOf(s.Substring(i, 1)) + 1;
                for (int j = 0; j < index; j++)
                {
                    sum = sum * primitive[i];
                }
            }
            return sum.ToString();
        }

        public static void MainGoedel(string[] args)
        {
            TextWriter tw = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            List<string> L = Console.ReadLine().Split(',').ToList();
            string s = Console.ReadLine();

            string result = godelEncode(L, s);

            tw.WriteLine(result);

            tw.Flush();
            tw.Close();

            //var r = godelEncode(new List<string>() { "0", "=" }, "0=0");
            //Console.WriteLine(r);
            //Console.ReadLine();
        }
    }
}