using System;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace ProyectoOpenTK.GameLogic
{
    public class Game : GameWindow
    {
        private House house;
        private Car car;

        private House house2;
        private Car car2;

        private House house3;
        private Car car3;

        public Game(int width, int height, string title) : base(width, height, GraphicsMode.Default, title)
        {
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
        }

        //-----------------------------------------------------------------------------------------------------------------
        protected override void OnLoad(EventArgs e)
        {
            house = new House(new Punto(), 7, 7, 10);
            car = new Car(new Punto(5, 5 ,5), 5, 3,5);

            
            house2 = new House(new Punto(10, 10 , 5), 7, 7, 10);
            car2 = new Car(new Punto(15, 10 ,7), 5, 3,5);

            // house3 = new House(new Punto(), 7, 7, 10);
            // car3 = new Car(new Punto(5, 5 ,5), 5, 3,5);

            base.OnLoad(e);
        }

        //-----------------------------------------------------------------------------------------------------------------
        protected override void OnUnload(EventArgs e)
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            //GL.DeleteBuffer(VertexBufferObject);
            base.OnUnload(e);
        }

        //-----------------------------------------------------------------------------------------------------------------
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            //GL.DepthMask(true);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.Enable(EnableCap.DepthTest);
            GL.LoadIdentity();
            //-----------------------

            // this.house.Dibujar();
            // this.car.Dibujar();
            
            // this.house2.Dibujar();
            this.car2.Dibujar();
            
            
            //-----------------------
            Context.SwapBuffers();
            base.OnRenderFrame(e);
        }

        //-----------------------------------------------------------------------------------------------------------------
        protected override void OnResize(EventArgs e)
        {
            float d = 30;
            GL.Viewport(0, 0, Width, Height);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(-d, d, -d, d, -d, d);
            //GL.Frustum(-80, 80, -80, 80, 4, 100);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            base.OnResize(e);
        }
    }
}