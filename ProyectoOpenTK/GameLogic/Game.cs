using System;
using System.Collections.Generic;
using System.Drawing;
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

        public float increaseValue { get; set; }
        public float movementValue { get; set; }
        public int degreesValue { get; set; }


        public Game(int width, int height, string title) : base(width, height, GraphicsMode.Default, title)
        {
            this.stages = new Dictionary<string, Stage>();
            this.increaseValue = 0.1f;
            this.movementValue = 0.1f;
            this.degreesValue = 1;
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
        }

        //-----------------------------------------------------------------------------------------------------------------
        protected override void OnLoad(EventArgs e)
        {
            // Color backgroundColor = Color.FromArgb(255, 65, 87, 63);
            // GL.ClearColor(backgroundColor);

            // int orthoSize = 5;
            // GL.Ortho(-orthoSize, orthoSize, -orthoSize, orthoSize, -orthoSize, orthoSize);
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


            //-----------------------

            foreach (var stages in stages)
            {
                stages.Value.Draw();
            }

            //-----------------------
            dibujarRejilla();

            Context.SwapBuffers();
        }

        private void dibujarRejilla()
        {
            GL.Begin(PrimitiveType.Lines);
            GL.Color3(Color.Red);

            float width = Width;
            float height = Height;
            float spacing = 5.0f;

            // Dibujar líneas verticales
            for (float x = -width / 2; x <= width / 2; x += spacing)
            {
                GL.Vertex2(x, -height / 2);
                GL.Vertex2(x, height / 2);
            }

            // Dibujar líneas horizontales
            for (float y = -height / 2; y <= height / 2; y += spacing)
            {
                GL.Vertex2(-width / 2, y);
                GL.Vertex2(width / 2, y);
            }

            GL.End();
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
                resize(1.01f, 1.01f, 1.01f);
            }
            else if (e.KeyChar == '-')
            {
                resize(0.99f, 0.99f, 0.99f);
            }
            else if (e.KeyChar == 'w')
            {
                moveTo(0, movementValue, 0);
            }
            else if (e.KeyChar == 's')
            {
                moveTo(0, movementValue * -1f, 0);
            }
            else if (e.KeyChar == 'a')
            {
                moveTo(movementValue * -1f, 0, 0);
            }
            else if (e.KeyChar == 'd')
            {
                moveTo(movementValue, 0, 0);
            }
            else if (e.KeyChar == 'q')
            {
                moveTo(0, 0, movementValue);
            }
            else if (e.KeyChar == 'e')
            {
                moveTo(0, 0, movementValue * -1f);
            }
            else if (e.KeyChar == 'r')
            {
                reset();
            }

            else if (e.KeyChar == '8')
            {
                rotate(degreesValue, 1, 0, 0);
            }
            else if (e.KeyChar == '2')
            {
                rotate(degreesValue, -1, 0, 0);
            }
            else if (e.KeyChar == '4')
            {
                rotate(degreesValue, 0, 1, 0);
            }
            else if (e.KeyChar == '6')
            {
                rotate(degreesValue, 0, -1, 0);
            }
            else if (e.KeyChar == '1')
            {
                Console.WriteLine("Rotate Z");
                rotate(degreesValue, 0, 0, 1);
            }
            else if (e.KeyChar == '9')
            {
                Console.WriteLine("Rotate -Z");
                rotate(degreesValue, 0, 0, -1);
            }

            base.OnKeyPress(e);
        }

        private void reset()
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.Enable(EnableCap.DepthTest);
            GL.LoadIdentity();
        }

        public void moveTo(float x, float y, float z)
        {
            foreach (var stages in stages)
            {
                stages.Value.moveTo(x, y, z);
            }
        }

        public void rotate(float angle, float x, float y, float z)
        {
            Console.WriteLine("rotate");
            foreach (var stages in stages)
            {
                stages.Value.rotate(angle, x, y, z);
            }
        }

        public void resize(float x, float y, float z)
        {
            Console.WriteLine("resize");

            foreach (var stages in stages)
            {
                stages.Value.resize(x, y, z);
            }
        }

        public Dictionary<string, GraphicObject> generateObjectsDetailFromStages()
        {
            Dictionary<string, GraphicObject> allObjects = new Dictionary<string, GraphicObject>();

            foreach (var stage in stages.Values)
            {
                foreach (KeyValuePair<string, GraphicObject> obj in stage.objects)
                {
                    allObjects[obj.Key] = obj.Value;
                }
            }

            return allObjects;
        }
    }
}