using Newtonsoft.Json;
using OpenTK;

namespace ProyectoOpenTK.GameLogic
{
    public class Point
    {
        public float x;
        public float y;
        public float z;

        public Point(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public Vector3 ParseToVector3()
        {
            return new Vector3(x, y, z);
        }

        public static Point MapFrom(Vector3 vector3)
        {
            return new Point(vector3.X, vector3.Y, vector3.Z);
        }
    }
}