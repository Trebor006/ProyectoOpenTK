using System;
using System.Collections.Generic;
using System.Windows.Forms;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using KeyPressEventArgs = OpenTK.KeyPressEventArgs;

namespace ProyectoOpenTK.GameLogic
{
    public class Game : GameWindow
    {
        public Dictionary<string, Stage> stages { get; set; }

        public Game(int width, int height, string title) : base(width, height, GraphicsMode.Default, title)
        {
            this.stages = new Dictionary<string, Stage>();
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
        }

        //-----------------------------------------------------------------------------------------------------------------
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        //-----------------------------------------------------------------------------------------------------------------
        protected override void OnUnload(EventArgs e)
        {
            GL.Rotate(20, 1, 1, 0);
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            //GL.DeleteBuffer(VertexBufferObject);

            base.OnUnload(e);
        }

        //-----------------------------------------------------------------------------------------------------------------
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.Enable(EnableCap.DepthTest);
            GL.LoadIdentity();
            //-----------------------

            foreach (var stages in stages)
            {
                stages.Value.Draw();
            }

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

        public void AddStage(string name, Stage stage)
        {
            this.stages.Add(name, stage);
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (e.KeyChar == '+')
            {
                Console.Write("Presionaste +");
            }
            else if (e.KeyChar == '-')
            {
                Console.Write("Presionaste -");
            }
            else if (e.KeyChar == (char)Keys.Up)
            {
            }
            else if (e.KeyChar == (char)Keys.Down)
            {
            }
            else if (e.KeyChar == (char)Keys.Left)
            {
            }
            else if (e.KeyChar == (char)Keys.Right)
            {
            }

            base.OnKeyPress(e);
        }
    }
}