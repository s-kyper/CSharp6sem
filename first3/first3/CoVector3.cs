using System;

namespace first3
{
    public struct CoVector3
    {
        private static double ABS = 0.0000000001;

        public double X { get; private set; }
        public double Y { get; private set; }
        public double Z { get; private set; }

        public CoVector3(double x, double y, double z) {
            X = x;
            Y = y;
            Z = z;
        }
        
        public CoVector3(double[] doubles) : this(doubles[0], doubles[1], doubles[2]) {}

        public double V0 => Math.Sqrt(X * X + Y * Y + Z * Z);

        public CoVector3 Normalized => this / V0;

        public override bool Equals(object obj)
        {
            if (!(obj is CoVector3)) {
                return false;
            }

            return Equals((CoVector3)obj);
        }

        public bool Equals(CoVector3 v)
        {
            return ((Math.Abs(X - v.X) < ABS) && (Math.Abs(Y - v.Y) < ABS) && (Math.Abs(Z - v.Z) < ABS));
        }

        public static bool operator ==(CoVector3 cv1, CoVector3 cv2) {
            return cv1.Equals(cv2);
        }

        public static bool operator !=(CoVector3 cv1, CoVector3 cv2) {
            return !(cv1 == cv2);
        }

        public static CoVector3 operator +(CoVector3 cv1, CoVector3 cv2) {
            return new CoVector3(cv1.X + cv2.X, cv1.Y + cv2.Y, cv1.Z + cv2.Z);
        }

        public static CoVector3 operator -(CoVector3 cv1, CoVector3 cv2) {
            return new CoVector3(cv1.X - cv2.X, cv1.Y - cv2.Y, cv1.Z - cv2.Z);
        }

        public static CoVector3 operator *(double scalar, CoVector3 cv) {
            return new CoVector3(scalar * cv.X, scalar * cv.Y, scalar * cv.Z);
        }

        public static CoVector3 operator *(CoVector3 cv, double scalar) {
            return scalar * cv;
        }

        public static double operator *(CoVector3 cv1, CoVector3 cv2) {
            return cv1.X * cv2.X + cv1.Y * cv2.Y + cv1.Z * cv2.Z;
        }
        
        public static double operator *(CoVector3 cv, Vector3 v) {
            return cv * (CoVector3)v;
        }
        
        public static CoVector3 operator /(CoVector3 cv, double scalar) {
            return new CoVector3(cv.X / scalar, cv.Y / scalar, cv.Z / scalar);
        }

        public static CoVector3 operator ^(CoVector3 cv1, CoVector3 cv2) {
            return new CoVector3(cv1.Y * cv2.Z - cv1.Z * cv2.Y, cv1.Z * cv2.X - cv1.X * cv2.Z, cv1.X * cv2.Y - cv1.Y * cv2.X);
        }

        public static explicit operator Vector3(CoVector3 v) {
            return new Vector3(v.X, v.Y, v.Z);
        }

        public override string ToString() {
            return string.Format("x: {0}, y: {1}, z: {2}", X, Y, Z);
        }
    }
}