using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HaloBasicTests
{
    public class TaskAwayOut
    {
        public static bool isValid(string s)
        {
            // Write Your Code Here
            if (string.IsNullOrEmpty(s))
                return false;

            Dictionary<char, char> matches = new Dictionary<char, char>(9)
            { { '(', ')'}, {'[',']'}, {'{','}'}};

            Stack<char> stack = new Stack<char>();
            int l = s.Length;
            for (int i = 0; i < l; i++)
            {
                var c = s[i];
                if (matches.Keys.Contains(c))
                {
                    stack.Push(c);
                }
                else if (matches.Values.Contains(c))
                {
                    var p = stack.Peek();
                    if (matches[p] == c)
                    {
                        if (stack.Count > 0)
                        {
                            stack.Pop();
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false; //do not match
                    }
                }
            }

            return stack.Count == 0; //nothing left.

        }

        static void MainAwayOut(string[] args)
        {
            TextWriter tw = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            string s = Console.ReadLine();

            bool result = isValid(s);

            tw.WriteLine(result.ToString().ToLower());

            tw.Flush();
            tw.Close();
        }
    }
}