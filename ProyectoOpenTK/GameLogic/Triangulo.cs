using OpenTK.Graphics.OpenGL;

namespace ProyectoOpenTK.GameLogic
{
    public class Triangulo
    {
        private float ancho;

        private float alto;
        // public Punto origen;

        public Triangulo(float ancho, float alto)
        {
            this.ancho = ancho;
            this.alto = alto;
        }

        public void Dibujar()
        {
            // GL.Rotate(20, 1, 1, 0);
            PrimitiveType primitiveType = PrimitiveType.LineLoop;

            dibujarLineaHorizontal(primitiveType);
            dibujarLineaLineaDerecha(primitiveType);
            dibujarLineaLineaIzq(primitiveType);
        }

        private void dibujarLineaHorizontal(PrimitiveType primitiveType)
        {
            GL.Begin(primitiveType);

            var anchoMedio = this.ancho / 2;
            GL.Vertex3(anchoMedio * -1, 0, 0);
            GL.Vertex3(anchoMedio, 0, 0);
            GL.End();
        }

        private void dibujarLineaLineaDerecha(PrimitiveType primitiveType)
        {
            GL.Begin(primitiveType);
            var anchoMedio = this.ancho / 2;
            GL.Vertex3(anchoMedio * -1, 0, 0);
            GL.Vertex3(0, this.alto, 0);
            GL.End();
        }

        private void dibujarLineaLineaIzq(PrimitiveType primitiveType)
        {
            GL.Begin(primitiveType);
            var anchoMedio = this.ancho / 2;
            GL.Vertex3(0, this.alto, 0);
            GL.Vertex3(anchoMedio, 0, 0);
            GL.End();
        }
    }
}