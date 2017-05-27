using System;
using System.Collections.Generic;

/*
*    Base tasks: +
*    Inversed, Transposed, Symmetrized, Asymmetrized Matrice: +
*    Vector mul(vector^vector): +
*    Vector3, CoVector3, Matrix3x3 instead Vector2, CoVector2, Matrix2x2: +
*    Vector mul(vector*vector): +
*/
namespace first3
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("====== Vector Tests ======");
            Vector3 v1 = new Vector3(1, 2, 3);
            Console.WriteLine("Test Normalize: " + v1.Normalized);  //must be (0.27, 0.53, 0.8)
            Vector3 v2 = new Vector3(1, 2, 3);
            Console.WriteLine("Test Equals: " + v1.Equals(v2));
            Vector3 v3 = new Vector3(1.00001, 0.3, 1.1);
            v2 = v2 - v3;
            Console.WriteLine("Test -: " + v2);
            Vector3 v4 = new Vector3(-0.00001, 1.7, 1.9);
            Console.WriteLine("Test ==: " + (v2 == v4));
            Vector3 v5 = new Vector3(-0.00002, 1.7, 1.9);
            Console.WriteLine("Test !=: " + (v4 != v5));
            Vector3 v6 = v5 + v3;
            Console.WriteLine("Test +: " + v6);
            Vector3 v7 = v6 + v3;
            Console.WriteLine("Test -: " + v7);
            Console.WriteLine("Test *(scalar): " + (10 * v7));
            Console.WriteLine("Test *(vector): " + (v1 * v1));
            Console.WriteLine("Test /: " + (v7/5));
            Console.WriteLine("Test ^: " + (v1 ^ v7));    //must be (1.3, 1.9, -1.7)
            Console.WriteLine("Test to Covector3: " + (CoVector3)v1);
            
            Console.WriteLine("====== Vector Matrices ======");
            Matrix3x3 m1 = new Matrix3x3(v1, v2, v3);
            Console.WriteLine("Test to Init: ");
            Console.WriteLine(m1);
            CoVector3 cv1 = new CoVector3(v1.X, -0.00001, 1.00001);
            CoVector3 cv2 = new CoVector3(v1.Y, 1.7, 0.3);
            CoVector3 cv3 = new CoVector3(v1.Z, 1.9, 1.1);
            Matrix3x3 m2 = new Matrix3x3(cv1, cv2, cv3);
            Console.WriteLine("Test Equals: " + (m1.Equals(m2)));
            m2 = new Matrix3x3(0, 0, 0, 0.00001, 1.3, 0.1, -0.00001, 0.7, 0.9);
            m1 = m1 + m2;
            Console.WriteLine("Test +: ");
            Console.WriteLine(m1);
            m1 = new Matrix3x3(0, 1, 2, 3, 4, 5, 6, 7, 8);
            Matrix3x3 m3 = new Matrix3x3(-1, -1, -1, 3, 3, 1, 1, 1, 8);
            m2 = m1 - m3;
            Console.WriteLine("Test -: ");
            Console.WriteLine(m2);
            Console.WriteLine("Test *(scalar): ");
            Console.WriteLine(m1 * 10);
            Console.WriteLine("Test *(vector): ");
            Console.WriteLine(v1 * m1);    //must be (8, 26, 44)
            Console.WriteLine("Test *(matrix): ");
            Console.WriteLine(m1 * m3);    //must be (5, 5, 17)(14, 14, 41)(23, 23, 65)
            Console.WriteLine("Test /: ");
            Console.WriteLine(m3 / 2);
            Console.WriteLine("Test *(CoVector): ");
            Console.WriteLine((CoVector3)v1 * m1);    //must be (8, 26, 44)
            Console.WriteLine("Test Trace: " + m1.Trace);
            Console.WriteLine("Test Det: " + m2.Det);  //must be 1
            Console.WriteLine("Test Init: ");
            Console.WriteLine(m2);
            Console.WriteLine("Test Transposed: ");
            Console.WriteLine(m2.Transposed);
            Console.WriteLine("Test Inversed: ");
            Console.WriteLine(m2.Inversed);    //must be (-24, 18, 5)(20, -15, -4)(-5, 4, 1)
            m1 = new Matrix3x3(1, 1, 2, 3, 4, 5, 6, 7, 8);
            Console.WriteLine("Test Inversed: ");
            Console.WriteLine(m1.Inversed);    //must be (1, -2, 1)(-2, 1.3, -0.3)(1, 0.3, -0.3)
            Console.WriteLine("Test Symmetrized: ");
            Console.WriteLine(m2.Symmetrized);    //must be (1, 1, 4)(1, 1, 5)(4, 5, 0)
            Console.WriteLine("Test Asymmetrized: ");
            Console.WriteLine(m2.Asymmetrized);    //must be (0, 1, -1)(-1, 0, -1)(1, 1, 0)
        }
    }
}