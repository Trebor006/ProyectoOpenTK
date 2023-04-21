namespace ProyectoOpenTK.GameLogic
{
    public class Punto
    {
        private float x;
        private float y;
        private float z;

        public Punto()
        {
            this.x = 0;
            this.y = 0;
            this.z = 0;
        }

        public Punto(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public float X
        {
            get => x;
            set => x = value;
        }

        public float Y
        {
            get => y;
            set => y = value;
        }

        public float Z
        {
            get => z;
            set => z = value;
        }
    }
}