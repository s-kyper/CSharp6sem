using System;

namespace first3
{
    public struct Vector3
    {
        private static double ABS = 0.0000000001;

        public double X { get; private set; }
        public double Y { get; private set; }
        public double Z { get; private set; }

        public Vector3(double x, double y, double z) {
            X = x;
            Y = y;
            Z = z;
        }
        
        public Vector3(double[] doubles) : this(doubles[0], doubles[1], doubles[2]) {}

        public double V0 => Math.Sqrt(X * X + Y * Y + Z * Z);

        public Vector3 Normalized => this / V0;

        public override bool Equals(object obj)
        {
            if (!(obj is Vector3)) {
                return false;
            }

            return Equals((Vector3)obj);
        }

        public bool Equals(Vector3 v)
        {
            return ((Math.Abs(X - v.X) < ABS) && (Math.Abs(Y - v.Y) < ABS) && (Math.Abs(Z - v.Z) < ABS));
        }

        public static bool operator ==(Vector3 v1, Vector3 v2) {
            return v1.Equals(v2);
        }

        public static bool operator !=(Vector3 v1, Vector3 v2) {
            return !(v1 == v2);
        }

        public static Vector3 operator +(Vector3 v1, Vector3 v2) {
            return new Vector3(v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z);
        }

        public static Vector3 operator -(Vector3 v1, Vector3 v2) {
            return new Vector3(v1.X - v2.X, v1.Y - v2.Y, v1.Z - v2.Z);
        }

        public static Vector3 operator *(double scalar, Vector3 v) {
            return new Vector3(scalar * v.X, scalar * v.Y, scalar * v.Z);
        }

        public static Vector3 operator *(Vector3 v, double scalar) {
            return scalar * v;
        }

        public static double operator *(Vector3 v1, Vector3 v2) {
            return v1.X * v2.X + v1.Y * v2.Y + v1.Z * v2.Z;
        }
        
        public static double operator *(Vector3 v, CoVector3 cv) {
            return v * (Vector3)cv;
        }
        
        public static Vector3 operator /(Vector3 v, double scalar) {
            return new Vector3(v.X / scalar, v.Y / scalar, v.Z / scalar);
        }

        public static Vector3 operator ^(Vector3 v1, Vector3 v2) {
            return new Vector3(v1.Y * v2.Z - v1.Z * v2.Y, v1.Z * v2.X - v1.X * v2.Z, v1.X * v2.Y - v1.Y * v2.X);
        }

        public static explicit operator CoVector3(Vector3 v) {
            return new CoVector3(v.X, v.Y, v.Z);
        }

        public override string ToString() {
            return string.Format("x: {0}, y: {1}, z: {2}", X, Y, Z);
        }
    }
}