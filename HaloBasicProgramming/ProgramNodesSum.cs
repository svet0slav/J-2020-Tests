using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace HaloBasicTests
{
    public class TaskNodesSum
    {

        public class Node
        {
            public int data;
            public Node left;
            public Node right;

            public Node(int data)
            {
                this.data = data;
            }
        }

        public static int sumLeaves(Node root)
        {
            // Write Your Code Here
            var top3 = new List<Node>(3);
            var top3Nodes = Top3Nodes(root, top3);
            int sum = 0;
            for (int i = 0; i < 3; i++)
            {
                sum += top3Nodes[i].data;
            }
            return sum;
        }

        private static List<Node> Top3Nodes(Node root, List<Node> top3)
        {
            if (root == null) return top3;
            if (top3.Count < 3)
            {
                top3.Add(root);
                BackSort(top3);
            }
            else if (top3[2].data < root.data)
            {
                top3[2] = root;
                BackSort(top3);
            }
            var l3 = Top3Nodes(root.left, top3);
            var r3 = Top3Nodes(root.right, l3);
            return r3;
        }

        private static void BackSort(List<Node> top3)
        {
            if (top3.Count < 2)
                return;
            if (top3.Count == 2 && top3[0].data < top3[1].data)
            {
                var x = top3[0];
                top3[0] = top3[1];
                top3[1] = x;
                return;
            }
            if (top3[1].data < top3[2].data)
            {
                var x = top3[1];
                top3[2] = top3[2];
                top3[2] = x;
            }
            if (top3[0].data < top3[1].data)
            {
                var x = top3[0];
                top3[0] = top3[1];
                top3[1] = x;
                return;
            }
        }

        static void MainNodesSum(string[] args)
        {
            TextWriter tw = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int n = int.Parse(Console.ReadLine());
            string[] tree = Console.ReadLine().Split();

            Dictionary<int, Node> dict = new Dictionary<int, Node>();
            Node root = null;

            for (int i = 0; i < n; i++)
            {
                int v1 = int.Parse(tree[i * 3].ToString());
                int v2 = int.Parse(tree[i * 3 + 1].ToString());
                string lr = tree[i * 3 + 2];

                Node parent = null;
                if (!dict.ContainsKey(v1))
                {
                    parent = new Node(v1);
                    dict.Add(v1, parent);
                    if (root == null)
                    {
                        root = parent;
                    }
                }

                parent = dict[v1];
                Node child = new Node(v2);
                if (lr == "L")
                {
                    parent.left = child;
                }
                else
                {
                    parent.right = child;
                }
                dict[v2] = child;
            }

            int result = sumLeaves(root);
            Console.WriteLine(result);
            Console.ReadLine();
            tw.WriteLine(result);

            tw.Flush();
            tw.Close();
        }
    }
}