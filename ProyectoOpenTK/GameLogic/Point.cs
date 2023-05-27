using OpenTK;

namespace ProyectoOpenTK.GameLogic
{
    public class Point
    {
        public float X;
        public float Y;
        public float Z;

        public Point(float x, float y, float z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public Vector3 ParseToVector3()
        {
            return new Vector3(X, Y, Z);
        }

        public static Point MapFrom(Vector3 vector3)
        {
            return new Point(vector3.X, vector3.Y, vector3.Z);
        }

        public static Point operator +(Point a, Point b)
        {
            return new Point(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        }

        public static Point operator *(Point a, Matrix4 b)
        {
            return new Point(
                a.X * b.M11 + a.Y * b.M21 + a.Z * b.M31,
                a.X * b.M12 + a.Y * b.M22 + a.Z * b.M32,
                a.X * b.M13 + a.Y * b.M23 + a.Z * b.M33
            );
        }
        
        public static Point operator *(Point a, Matrix3 b)
        {
            return new Point(
                a.X * b.M11 + a.Y * b.M21 + a.Z * b.M31,
                a.X * b.M12 + a.Y * b.M22 + a.Z * b.M32,
                a.X * b.M13 + a.Y * b.M23 + a.Z * b.M33
            );
        }

        public static implicit operator Vector3(Point convert)
        {
            return new Vector3(convert.X, convert.Y, convert.Z);
        }
    }
}