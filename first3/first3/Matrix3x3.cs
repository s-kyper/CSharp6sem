using System;

namespace first3
{
    public struct Matrix3x3
    {
        private CoVector3[] cv;
        private Vector3[] v;

        private Vector3 v1;
        private Vector3 v2;
        private Vector3 v3;

        public double X1 => v1.X;
        public double Y1 => v1.Y;
        public double Z1 => v1.Z;
        public double X2 => v2.X;
        public double Y2 => v2.Y;
        public double Z2 => v2.Z;
        public double X3 => v3.X;
        public double Y3 => v3.Y;
        public double Z3 => v3.Z;
        
        public double Det => X1 * Y2 * Z3 + Y1 * Z2 * X3 + Z1 * Y3 * X2
                            -X3 * Y2 * Z1 - Y3 * Z2 * X1 - Z3 * Y1 * X2;
        public double Norm => Math.Sqrt( X1 * X1 + Y1 * Y1 + X2 * X2 + Y2 * Y2);
        public double Trace => v1.X + v2.Y + v3.Z;
        public Matrix3x3 Transposed => new Matrix3x3(new Vector3(v1.X, v2.X, v3.X), new Vector3(v1.Y, v2.Y, v3.Y), new Vector3(v1.Z, v2.Z, v3.Z));
        public Matrix3x3 Inversed => new Matrix3x3(v2 ^ v3, -1 * v1 ^ v3, v1 ^ v2).Transposed / Det;    //It really works
        public Matrix3x3 Symmetrized => (this + Transposed) / 2;
        public Matrix3x3 Asymmetrized => (this - Transposed) / 2;

        public Matrix3x3(Vector3[] vectors) : this(vectors[0], vectors[1], vectors[2]) {}

        public Matrix3x3(Vector3 u1, Vector3 u2, Vector3 u3) {
            v1 = u1;
            v2 = u2;
            v3 = u3;
            cv = new CoVector3[3] {new CoVector3(v1.X, v2.X, v3.X), new CoVector3(v1.Y, v2.Y, v3.Y), new CoVector3(v1.Z, v2.Z, v3.Z)};
            v = new Vector3[3] {v1, v2, v3};
        }

        public Matrix3x3(CoVector3 cu1, CoVector3 cu2, CoVector3 cu3) : 
            this(new Vector3(cu1.X, cu2.X, cu3.X), new Vector3(cu1.Y, cu2.Y, cu3.Y), new Vector3(cu1.Z, cu2.Z, cu3.Z)) {}

        public Matrix3x3(double x1, double y1, double z1, double x2, double y2, double z2, double x3, double y3, double z3) : 
            this(new Vector3(x1, y1, z1), new Vector3(x2, y2, z2), new Vector3(x3, y3, z3)) {}

        public override bool Equals(object obj) {
            if (!(obj is Matrix3x3)) {
                return false;
            }

            return Equals((Matrix3x3)obj);
        }

        public bool Equals(Matrix3x3 m) {
            return (v1 == m.v1 && v2 == m.v2 && v3 == m.v3);
        }

        public static bool operator ==(Matrix3x3 m1, Matrix3x3 m2) {
            return m1.Equals(m2);
        }

        public static bool operator !=(Matrix3x3 m1, Matrix3x3 m2) {
            return !(m1 == m2);
        }

        public static Matrix3x3 operator +(Matrix3x3 m1, Matrix3x3 m2) {
            return new Matrix3x3(m1.v1 + m2.v1, m1.v2 + m2.v2, m1.v3 + m2.v3);
        }

        public static Matrix3x3 operator -(Matrix3x3 m1, Matrix3x3 m2) {
            return new Matrix3x3(m1.v1 - m2.v1, m1.v2 - m2.v2, m1.v3 - m2.v3);
        }

        public static Matrix3x3 operator *(double scalar, Matrix3x3 m) {
            return new Matrix3x3(Array.ConvertAll(m.v, v => scalar * v));
        }

        public static Matrix3x3 operator *(Matrix3x3 m, double scalar) {
            return scalar * m;
        }

        public static Vector3 operator *(Vector3 vector, Matrix3x3 m) {
            return new Vector3(Array.ConvertAll(m.v, v => vector * v));
        }
        
        public static Vector3 operator *(Matrix3x3 m, Vector3 vector) {
            return vector * m;
        }

        public static CoVector3 operator *(CoVector3 covector, Matrix3x3 m) {
            return new CoVector3(Array.ConvertAll(m.v, v => covector * v));
        }
        
        public static CoVector3 operator *(Matrix3x3 m, CoVector3 covector) {
            return covector * m;
        }

        public static Matrix3x3 operator *(Matrix3x3 m1, Matrix3x3 m2) {
            return new Matrix3x3(
                new Vector3(Array.ConvertAll(m2.cv, cv => cv * m1.v1)),
                new Vector3(Array.ConvertAll(m2.cv, cv => cv * m1.v2)),
                new Vector3(Array.ConvertAll(m2.cv, cv => cv * m1.v3))
            );
        }
        
        public static Matrix3x3 operator /(Matrix3x3 m, double scalar) {
            return new Matrix3x3(Array.ConvertAll(m.v, v => v / scalar));
        }

        public override string ToString() {
            return string.Format("X1: {0}, Y1: {1}, Z1: {2}\nX2: {3}, Y2: {4}, Z2: {5}\nX3: {6}, Y3: {7}, Z3: {8}", 
                X1, Y1, Z1, X2, Y2, Z2, X3, Y3, Z3);
        }
    }
}