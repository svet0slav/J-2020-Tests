using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace HaloBasicTests
{
    public class TaskPossibleFSMMax
    {

        public class State
        {
            public bool isFinal;
            public Dictionary<string, State> transitions;

            public State(bool isFinal)
            {
                this.isFinal = isFinal;
                this.transitions = new Dictionary<string, State>();
            }
        }

        public static int countValidStrings(State fsm, int maxLength)
        {
            // Write Your Code Here

            if (maxLength == 0)
                return fsm.isFinal ? 1 : 0;
            int count = fsm.isFinal ? 1 : 0;
            foreach (var transition in fsm.transitions)
            {
                count += countValidStrings(transition.Value, maxLength - 1);
            }
            return count;
        }

        static void MainPossibleFSMMax(string[] args)
        {
            //TextWriter tw = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int maxLength = int.Parse(Console.ReadLine());
            string initialState = Console.ReadLine();
            HashSet<string> finalStates = new HashSet<string>(Console.ReadLine().Split(','));

            Dictionary<string, State> fsm = new Dictionary<string, State>();

            String row;
            while ((row = Console.ReadLine()) != null && row != "")
            {
                string[] s = row.Split(',');
                if (!fsm.ContainsKey(s[0]))
                {
                    fsm.Add(s[0], new State(finalStates.Contains(s[0])));
                }

                if (!fsm.ContainsKey(s[2]))
                {
                    fsm.Add(s[2], new State(finalStates.Contains(s[2])));
                }

                fsm[s[0]].transitions.Add(s[1], fsm[s[2]]);
            }

            int result = countValidStrings(fsm[initialState], maxLength);

            //tw.WriteLine("Result:");
            //tw.WriteLine(result);
            Console.WriteLine("Result:" + result.ToString());
            //tw.Flush();
            //tw.Close();
            Console.ReadLine();
        }
    }
}