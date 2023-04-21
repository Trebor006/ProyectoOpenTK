using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using System.Drawing;


namespace ProyectoOpenTK.GameLogic
{
    public class House
    {
        private float ancho;
        private float alto;
        private float profundidad;

        public Punto origen;

        public House(Punto origen, float ancho, float alto, float profundidad)
        {
            this.ancho = ancho;
            this.alto = alto;
            this.profundidad = profundidad;
            this.origen = origen;
        }

        public void Dibujar()
        {
            GL.Rotate(20, 1, 1, 0);
            PrimitiveType primitiveType = PrimitiveType.LineLoop;

            // origen.X = 0;
            // origen.Y = 0;
            // origen.Z = 0;
            //paredes
            caraFrontal(primitiveType);
            caraPosterior(primitiveType);
            caraLateralDerecha(primitiveType);
            caraLateralIzquierda(primitiveType);
            caraSuperior(primitiveType);
            caraInferior(primitiveType);

            // origen.X = 0;
            // origen.Y = this.alto * 2;
            // origen.Z = 0;
            //techo
            caraFrontalTecho(primitiveType);
            caraPosteriorTecho(primitiveType);
            caraLateralDerechaTecho(primitiveType);
            caraLateralIzquierdaTecho(primitiveType);
            caraInferiorTecho(primitiveType);
        }

        private void caraFrontalTecho(PrimitiveType primitiveType)
        {
            GL.Begin(primitiveType);
            //GL.Color4(Color.Aqua);
            GL.Color3(1.0, 1.0, 0.0); //amarillo
            GL.Vertex3(origen.X - ancho, this.alto * 2 - alto, origen.Z + profundidad);
            GL.Vertex3(origen.X + ancho, this.alto * 2 - alto, origen.Z + profundidad);
            GL.Vertex3(origen.X, this.alto * 2 + alto, origen.Z + profundidad);
            GL.End();
        }

        private void caraPosteriorTecho(PrimitiveType primitiveType)
        {
            GL.Begin(primitiveType);
            //GL.Color4(Color.Aqua);
            GL.Color3(1.0, 1.0, 0.0); //amarillo
            GL.Vertex3(origen.X - ancho, this.alto * 2 - alto, origen.Z - profundidad);
            GL.Vertex3(origen.X + ancho, this.alto * 2 - alto, origen.Z - profundidad);
            GL.Vertex3(origen.X, this.alto * 2 + alto, origen.Z - profundidad);
            GL.End();
        }

        private void caraLateralDerechaTecho(PrimitiveType primitiveType)
        {
            GL.Begin(primitiveType);
            GL.Color3(1.0, 1.0, 0.0); //amarillo
            GL.Vertex3(origen.X + ancho, this.alto * 2 - alto, origen.Z + profundidad); //P1
            GL.Vertex3(origen.X + ancho, this.alto * 2 - alto, origen.Z - profundidad); //P2
            GL.Vertex3(origen.X, this.alto * 2 + alto, origen.Z - profundidad); //P3
            GL.Vertex3(origen.X, this.alto * 2 + alto, origen.Z + profundidad); //P4
            GL.End();
        }

        private void caraLateralIzquierdaTecho(PrimitiveType primitiveType)
        {
            GL.Begin(primitiveType);
            GL.Vertex3(origen.X - ancho, this.alto * 2 - alto, origen.Z + profundidad); //P1
            GL.Vertex3(origen.X - ancho, this.alto * 2 - alto, origen.Z - profundidad); //P2
            GL.Vertex3(origen.X, this.alto * 2 + alto, origen.Z - profundidad); //P3
            GL.Vertex3(origen.X, this.alto * 2 + alto, origen.Z + profundidad); //P4
            GL.End();
        }

        private void caraInferiorTecho(PrimitiveType primitiveType)
        {
            //
            GL.Begin(primitiveType);
            GL.Color3(0, 1, 1.3); //azul;
            GL.Vertex3(origen.X - ancho, this.alto * 2 - alto, origen.Z - profundidad);
            GL.Vertex3(origen.X + ancho, this.alto * 2 - alto, origen.Z - profundidad);
            GL.Vertex3(origen.X + ancho, this.alto * 2 - alto, origen.Z + profundidad);
            GL.Vertex3(origen.X - ancho, this.alto * 2 - alto, origen.Z + profundidad);
            GL.End();
        }

        private void caraLateralDerecha(PrimitiveType primitiveType)
        {
            GL.Begin(primitiveType);
            //GL.Color4(Color.Aqua);
            GL.Color3(1.0, 1.0, 0.0); //amarillo
            GL.Vertex3(origen.X + ancho, origen.Y + alto, origen.Z - profundidad);
            GL.Vertex3(origen.X + ancho, origen.Y + alto, origen.Z + profundidad);
            GL.Vertex3(origen.X + ancho, origen.Y - alto, origen.Z + profundidad);
            GL.Vertex3(origen.X + ancho, origen.Y - alto, origen.Z - profundidad);
            GL.End();
        }

        private void caraLateralIzquierda(PrimitiveType primitiveType)
        {
            GL.Begin(primitiveType);
            GL.Color3(1, 0.0, 0.0); //rojo
            GL.Vertex3(origen.X - ancho, origen.Y + alto, origen.Z - profundidad);
            GL.Vertex3(origen.X - ancho, origen.Y + alto, origen.Z + profundidad);
            GL.Vertex3(origen.X - ancho, origen.Y - alto, origen.Z + profundidad);
            GL.Vertex3(origen.X - ancho, origen.Y - alto, origen.Z - profundidad);
            GL.End();
        }

        private void caraFrontal(PrimitiveType primitiveType)
        {
            //
            GL.Begin(primitiveType);
            GL.Color3(0.0, 1.0, 0.0); //verde
            GL.Vertex3(origen.X - ancho, origen.Y + alto, origen.Z + profundidad);
            GL.Vertex3(origen.X + ancho, origen.Y + alto, origen.Z + profundidad);
            GL.Vertex3(origen.X + ancho, origen.Y - alto, origen.Z + profundidad);
            GL.Vertex3(origen.X - ancho, origen.Y - alto, origen.Z + profundidad);
            GL.End();
        }

        private void caraPosterior(PrimitiveType primitiveType)
        {
            //
            GL.Begin(primitiveType);
            GL.Color3(1, 0.2, 1); //rosado
            GL.Vertex3(origen.X - ancho, origen.Y + alto, origen.Z - profundidad);
            GL.Vertex3(origen.X + ancho, origen.Y + alto, origen.Z - profundidad);
            GL.Vertex3(origen.X + ancho, origen.Y - alto, origen.Z - profundidad);
            GL.Vertex3(origen.X - ancho, origen.Y - alto, origen.Z - profundidad);
            GL.End();
        }

        private void caraInferior(PrimitiveType primitiveType)
        {
            //
            GL.Begin(primitiveType);
            GL.Color3(0.0, 0.0, 1.0); //azul;
            GL.Vertex3(origen.X - ancho, origen.Y - alto, origen.Z - profundidad);
            GL.Vertex3(origen.X + ancho, origen.Y - alto, origen.Z - profundidad);
            GL.Vertex3(origen.X + ancho, origen.Y - alto, origen.Z + profundidad);
            GL.Vertex3(origen.X - ancho, origen.Y - alto, origen.Z + profundidad);
            GL.End();
        }

        private void caraSuperior(PrimitiveType primitiveType)
        {
            //
            GL.Begin(primitiveType);
            GL.Color3(0, 1, 1.3); //azul;
            GL.Vertex3(origen.X - ancho, origen.Y + alto, origen.Z - profundidad);
            GL.Vertex3(origen.X + ancho, origen.Y + alto, origen.Z - profundidad);
            GL.Vertex3(origen.X + ancho, origen.Y + alto, origen.Z + profundidad);
            GL.Vertex3(origen.X - ancho, origen.Y + alto, origen.Z + profundidad);
            GL.End();
        }
    }
}