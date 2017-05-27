using System;

/*
*    Test: calculate expression "-8.1 + (10 + 2 * 3) / (5 * 2)"
*    Base tasks: +
*    Unary & Ternary Nodes: +
*    covariance and contravariance: what is this?
*/
namespace fourth
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var a1 = new LeafNode<double, double>(8.1, Convert.ToDouble);
            var a2 = new LeafNode<int, double>(10, Convert.ToDouble);
            var a3 = new LeafNode<int, double>(2, Convert.ToDouble);
            var a4 = new LeafNode<int, double>(3, Convert.ToDouble);
            var a5 = new LeafNode<int, double>(5, Convert.ToDouble);

            var b1 = new UnaryNode<double, double>(a1, (x) => -x);
            Console.WriteLine(b1.Calculate());
            var b2 = new TernaryNode<double, double, double, double>(a2, a3, a4, (x, y, z) => x + y * z);
            Console.WriteLine(b2.Calculate());
            var b3 = new TreeNode<double, double, double>(a5, a3, (x, y) => x * y);
            Console.WriteLine(b3.Calculate());
            var b4 = new TernaryNode<double, double, double, double>(b1, b2, b3, (x, y, z) => x + y / z);
            Console.WriteLine(b4.Calculate());
        }
    }
}