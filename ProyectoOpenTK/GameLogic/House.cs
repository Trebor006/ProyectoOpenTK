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
        private float initialX;
        private float initialY;
        private float initialZ;

        private float ancho;
        private float alto;
        private float profundidad;

        // public Punto origen;

        public House(float ancho, float alto, float profundidad)
        {
            this.ancho = ancho;
            this.alto = alto;
            this.profundidad = profundidad;

            this.initialX = 0;
            this.initialY = 0;
            this.initialZ = 0;
        }

        public void Dibujar()
        {
            GL.Rotate(20, 1, 1, 0);
            PrimitiveType primitiveType = PrimitiveType.LineLoop;

            this.initialX = 0;
            this.initialY = 0;
            this.initialZ = 0;
            //paredes
            caraFrontal(primitiveType);
            caraPosterior(primitiveType);
            caraLateralDerecha(primitiveType);
            caraLateralIzquierda(primitiveType);
            caraSuperior(primitiveType);
            caraInferior(primitiveType);

            this.initialX = 0;
            this.initialY = this.alto * 2;
            this.initialZ = 0;
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
            GL.Vertex3(this.initialX - ancho, this.initialY - alto , this.initialZ + profundidad);
            GL.Vertex3(this.initialX + ancho, this.initialY - alto , this.initialZ + profundidad);
            GL.Vertex3(this.initialX, this.initialY + alto , this.initialZ + profundidad);
            GL.End();
        }

        private void caraPosteriorTecho(PrimitiveType primitiveType)
        {
            GL.Begin(primitiveType);
            //GL.Color4(Color.Aqua);
            GL.Color3(1.0, 1.0, 0.0); //amarillo
            GL.Vertex3(this.initialX - ancho, this.initialY - alto , this.initialZ - profundidad);
            GL.Vertex3(this.initialX + ancho, this.initialY - alto , this.initialZ - profundidad);
            GL.Vertex3(this.initialX, this.initialY + alto , this.initialZ - profundidad);
            GL.End();
        }

        private void caraLateralDerechaTecho(PrimitiveType primitiveType)
        {
            GL.Begin(primitiveType);
            GL.Color3(1.0, 1.0, 0.0); //amarillo
            GL.Vertex3(this.initialX + ancho , this.initialY - alto , this.initialZ + profundidad); //P1
            GL.Vertex3(this.initialX + ancho , this.initialY - alto , this.initialZ - profundidad); //P2
            GL.Vertex3(this.initialX, this.initialY + alto , this.initialZ - profundidad); //P3
            GL.Vertex3(this.initialX, this.initialY + alto , this.initialZ + profundidad); //P4
            GL.End();
        }

        private void caraLateralIzquierdaTecho(PrimitiveType primitiveType)
        {
            GL.Begin(primitiveType);
            GL.Vertex3(this.initialX - ancho , this.initialY - alto , this.initialZ + profundidad); //P1
            GL.Vertex3(this.initialX - ancho , this.initialY - alto , this.initialZ - profundidad); //P2
            GL.Vertex3(this.initialX, this.initialY + alto , this.initialZ - profundidad); //P3
            GL.Vertex3(this.initialX, this.initialY + alto , this.initialZ + profundidad); //P4
            GL.End();
        }

        private void caraInferiorTecho(PrimitiveType primitiveType)
        {
            //
            GL.Begin(primitiveType);
            GL.Color3(0, 1, 1.3); //azul;
            GL.Vertex3(this.initialX - ancho, this.initialY - alto, this.initialZ - profundidad);
            GL.Vertex3(this.initialX + ancho, this.initialY - alto, this.initialZ - profundidad);
            GL.Vertex3(this.initialX + ancho, this.initialY - alto, this.initialZ + profundidad);
            GL.Vertex3(this.initialX - ancho, this.initialY - alto, this.initialZ + profundidad);
            GL.End();
        }

        private void caraLateralDerecha(PrimitiveType primitiveType)
        {
            GL.Begin(primitiveType);
            //GL.Color4(Color.Aqua);
            GL.Color3(1.0, 1.0, 0.0); //amarillo
            GL.Vertex3(this.initialX + ancho, this.initialY + alto, this.initialZ - profundidad);
            GL.Vertex3(this.initialX + ancho, this.initialY + alto, this.initialZ + profundidad);
            GL.Vertex3(this.initialX + ancho, this.initialY - alto, this.initialZ + profundidad);
            GL.Vertex3(this.initialX + ancho, this.initialY - alto, this.initialZ - profundidad);
            GL.End();
        }

        private void caraLateralIzquierda(PrimitiveType primitiveType)
        {
            GL.Begin(primitiveType);
            GL.Color3(1, 0.0, 0.0); //rojo
            GL.Vertex3(this.initialX - ancho, this.initialY + alto, this.initialZ - profundidad);
            GL.Vertex3(this.initialX - ancho, this.initialY + alto, this.initialZ + profundidad);
            GL.Vertex3(this.initialX - ancho, this.initialY - alto, this.initialZ + profundidad);
            GL.Vertex3(this.initialX - ancho, this.initialY - alto, this.initialZ - profundidad);
            GL.End();
        }

        private void caraFrontal(PrimitiveType primitiveType)
        {
            //
            GL.Begin(primitiveType);
            GL.Color3(0.0, 1.0, 0.0); //verde
            GL.Vertex3(this.initialX - ancho, this.initialY + alto, this.initialZ + profundidad);
            GL.Vertex3(this.initialX + ancho, this.initialY + alto, this.initialZ + profundidad);
            GL.Vertex3(this.initialX + ancho, this.initialY - alto, this.initialZ + profundidad);
            GL.Vertex3(this.initialX - ancho, this.initialY - alto, this.initialZ + profundidad);
            GL.End();
        }

        private void caraPosterior(PrimitiveType primitiveType)
        {
            //
            GL.Begin(primitiveType);
            GL.Color3(1, 0.2, 1); //rosado
            GL.Vertex3(this.initialX - ancho, this.initialY + alto, this.initialZ - profundidad);
            GL.Vertex3(this.initialX + ancho, this.initialY + alto, this.initialZ - profundidad);
            GL.Vertex3(this.initialX + ancho, this.initialY - alto, this.initialZ - profundidad);
            GL.Vertex3(this.initialX - ancho, this.initialY - alto, this.initialZ - profundidad);
            GL.End();
        }

        private void caraInferior(PrimitiveType primitiveType)
        {
            //
            GL.Begin(primitiveType);
            GL.Color3(0.0, 0.0, 1.0); //azul;
            GL.Vertex3(this.initialX - ancho, this.initialY - alto, this.initialZ - profundidad);
            GL.Vertex3(this.initialX + ancho, this.initialY - alto, this.initialZ - profundidad);
            GL.Vertex3(this.initialX + ancho, this.initialY - alto, this.initialZ + profundidad);
            GL.Vertex3(this.initialX - ancho, this.initialY - alto, this.initialZ + profundidad);
            GL.End();
        }

        private void caraSuperior(PrimitiveType primitiveType)
        {
            //
            GL.Begin(primitiveType);
            GL.Color3(0, 1, 1.3); //azul;
            GL.Vertex3(this.initialX - ancho, this.initialY + alto, this.initialZ - profundidad);
            GL.Vertex3(this.initialX + ancho, this.initialY + alto, this.initialZ - profundidad);
            GL.Vertex3(this.initialX + ancho, this.initialY + alto, this.initialZ + profundidad);
            GL.Vertex3(this.initialX - ancho, this.initialY + alto, this.initialZ + profundidad);
            GL.End();
        }
    }
}