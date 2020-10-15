using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace HaloBasicProgramming
{

    public class TaskEncoding
    {

        public static bool isIsomorphic(string s1, string s2)
        {
            if (s1 == null || s2 == null || s1.Length != s2.Length)
                return false;

            // Write Your Code Here
            List<Tuple<char, char>> corresponds = new List<Tuple<char, char>>(999);
            var l = s1.Length;
            for (int i = 0; i < l; i++)
            {
                char c1 = s1[i];
                char c2 = s2[i];
                var t = corresponds.FirstOrDefault(k => k.Item1 == c1);
                if (t != null)
                {
                    if (t.Item2 == c2)
                        continue;
                    return false;
                }
                corresponds.Add(new Tuple<char, char>(c1, c2));
            }
            return true;
        }

        static void MainEncoding(string[] args)
        {
            TextWriter tw = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            string s1 = Console.ReadLine();
            string s2 = Console.ReadLine();

            bool result = isIsomorphic(s1, s2);

            tw.WriteLine(result.ToString().ToLower());

            tw.Flush();
            tw.Close();
        }
    }
}