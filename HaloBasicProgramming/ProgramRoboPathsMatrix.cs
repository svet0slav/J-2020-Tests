//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Numerics;

//class Solution
//{

//    public static long uniquePaths(int m, int n)
//    {
//        // Write Your Code Here
//        int bigger = (n > m) ? n : m;
//        int lower = (n > m) ? m : n;
//        long variations = factoriel(bigger) / factoriel(bigger - lower);
//        return variations;
//    }

//    private static long factoriel(int n)
//    {
//        return (n <= 1) ? 1 : n * factoriel(n - 1);
//    }

//    static void Main(string[] args)
//    {
//        TextWriter tw = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

//        int m = int.Parse(Console.ReadLine());
//        int n = int.Parse(Console.ReadLine());

//        long result = uniquePaths(m, n);

//        tw.WriteLine(result);

//        tw.Flush();
//        tw.Close();
//    }
//}