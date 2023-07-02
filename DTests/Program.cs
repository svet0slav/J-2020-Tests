using System;

namespace DTests
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");

            //var p1 = new Problem1();
            //Console.WriteLine(p1.SumFor());
            //Console.WriteLine(p1.SumWhile());
            //Console.WriteLine(p1.SumRecursion());

            //var p2 = new Problem2();
            //var sol2 = p2.MergeAlternatingly();
            //foreach (var item in sol2)
            //{
            //    Console.Write(item.ToString() + ", ");
            //}
            //Console.WriteLine("");

            //var p3 = new Problem3();
            //var sol3 = p3.Fibonachi(100);
            //foreach (var item in sol3)
            //{
            //    Console.Write(item.ToString() + ", ");
            //}
            //Console.WriteLine("");
            //Console.WriteLine("-----------------");

            var p4 = new Problem4();
            var sol4 = p4.LargestNumber();
            foreach (var item in sol4)
            {
                Console.Write(item.ToString() + ", ");
            }
            Console.WriteLine("");
            Console.WriteLine("-----------------");

        }
    }
}
