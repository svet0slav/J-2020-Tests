using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace HaloBasicProgramming
{
    public class TaskLongestSubstring
    {

        public static string lengthOfLongestSubstring(string s)
        {
            // Write your code here
            if (string.IsNullOrEmpty(s))
                return "";
            if (s.Length == 1)
                return s.Substring(0, 1);
            var l = s.Length;
            int lastStart = 0;
            int lastLength = 0;
            string longest = s.Substring(0, 1);
            for (int i = 1; i < l; i++)
            {
                lastLength++;
                char c = s[i];
                for (int compi = lastStart; compi < i; compi++)
                {
                    if (s[compi].Equals(c))
                    {
                        if (longest.Length < lastLength)
                        {   //move to next to try
                            longest = s.Substring(lastStart, lastLength);
                            lastStart = i;
                            lastLength = 0;
                            break;
                        }
                        else
                        {
                            lastStart = i;
                            lastLength = 0;
                            break;
                        }
                    }
                }
            }
            return longest;
        }

        static void MainLongestSubstring(string[] args)
        {
            //var r = lengthOfLongestSubstring("abcabcbb");
            //Console.WriteLine(r);
            //Console.ReadLine();
            TextWriter tw = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            string s = Console.ReadLine();

            string result = lengthOfLongestSubstring(s);

            tw.WriteLine(result);

            tw.Flush();
            tw.Close();
        }

    }
}