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
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            // GL.Enable(EnableCap.DepthTest);
            // GL.LoadIdentity();
            // GL.Rotate(20, 1, 1, 0);

            //-----------------------

            foreach (var stages in stages)
            {
                stages.Value.Draw();
            }

            //-----------------------
            Context.SwapBuffers();
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
                increaseSize();
            }
            else if (e.KeyChar == '-')
            {
                decreaseSize();
            }
            else if (e.KeyChar == 'w')
            {
                moveToUp();
            }
            else if (e.KeyChar == 's')
            {
                moveToDown();
            }
            else if (e.KeyChar == 'a')
            {
                moveToLeft();
            }
            else if (e.KeyChar == 'd')
            {
                moveToRight();
            }
            else if (e.KeyChar == '8')
            {
                rotateRightX();
            }
            else if (e.KeyChar == '2')
            {
                rotateLeftX();
            }
            else if (e.KeyChar == '4')
            {
                rotateUpY();
            }
            else if (e.KeyChar == '6')
            {
                rotateDownY();
            }

            base.OnKeyPress(e);
        }

        private void increaseSize()
        {
            foreach (var stages in stages)
            {
                stages.Value.increaseSize();
            }
        }

        private void decreaseSize()
        {
            foreach (var stages in stages)
            {
                stages.Value.decreaseSize();
            }
        }

        private void moveToUp()
        {
            foreach (var stages in stages)
            {
                stages.Value.moveToUp();
            }
        }

        private void moveToDown()
        {
            foreach (var stages in stages)
            {
                stages.Value.moveToDown();
            }
        }

        private void moveToLeft()
        {
            foreach (var stages in stages)
            {
                stages.Value.moveToLeft();
            }
        }

        private void moveToRight()
        {
            foreach (var stages in stages)
            {
                stages.Value.moveToRight();
            }
        }

        private void rotateUpY()
        {
            foreach (var stages in stages)
            {
                stages.Value.rotateUpY();
            }
        }

        private void rotateDownY()
        {
            foreach (var stages in stages)
            {
                stages.Value.rotateDownY();
            }
        }

        private void rotateRightX()
        {
            foreach (var stages in stages)
            {
                stages.Value.rotateRightX();
            }
        }

        private void rotateLeftX()
        {
            foreach (var stages in stages)
            {
                stages.Value.rotateLeftX();
            }
        }
    }
}