using System;
using System.Drawing;
using Newtonsoft.Json;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using ProyectoOpenTK.GameLogic.Interfaces;

namespace ProyectoOpenTK.GameLogic
{
    public class Part : IDrawable
    {
        [JsonIgnore] private int VAO;
        [JsonIgnore] private int VBO;
        [JsonIgnore] private int EBO;
        [JsonIgnore] private int vertexCount;
        [JsonIgnore] public Matrix4 modelMatrix { get; private set; }

        public float[] vertices { get; set; }
        public int[] indices;

        public Point origin { get; set; }
        public Point position { get; set; }

        public Part(float[] vertices, int[] indices, Point origin)
        {
            this.vertices = vertices;
            this.origin = origin;
            this.position = origin;
            this.indices = indices;
            modelMatrix = Matrix4.Identity;

            // Crear y configurar el VAO
            VAO = GL.GenVertexArray();
            GL.BindVertexArray(VAO);

            // Crear el VBO de vértices
            int vboID = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, vboID);
            GL.BufferData(BufferTarget.ArrayBuffer, this.vertices.Length * sizeof(float), this.vertices,
                BufferUsageHint.StaticDraw);
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 0, 0);
            GL.EnableVertexAttribArray(0);

            // Crear el EBO (Element Buffer Object)
            int eboID = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, eboID);
            GL.BufferData(BufferTarget.ElementArrayBuffer, this.indices.Length * sizeof(int), this.indices,
                BufferUsageHint.StaticDraw);

            // Desenlazar el VAO
            GL.BindVertexArray(0);

            vertexCount = indices.Length;
        }

        public void Draw()
        {
            GL.PushMatrix();
            var matrix4 = modelMatrix;
            GL.MultMatrix(ref matrix4);
            GL.Color3(Color.White);

            GL.BindVertexArray(VAO);
            GL.DrawElements(PrimitiveType.LineLoop, vertexCount, DrawElementsType.UnsignedInt, 0);
            GL.BindVertexArray(0);

            GL.PopMatrix();
        }

        private float[] getVerticesToDraw()
        {
            Console.WriteLine("Estan llamando al metodo getVerticesToDraw");
            float[] verticesCalculated = new float[vertices.Length];
            for (var i = 0; i < vertices.Length; i += 3)
            {
                verticesCalculated[i] = vertices[i];
                verticesCalculated[i + 1] = vertices[i + 1];
                verticesCalculated[i + 2] = vertices[i + 2] + origin.Z + position.Z;
            }

            return verticesCalculated;
        }

        public void Translate(float x, float y, float z)
        {
            modelMatrix *= Matrix4.CreateTranslation(new Vector3(x, y, z));
        }

        public void Scale(float x, float y, float z)
        {
            modelMatrix *= Matrix4.CreateScale(x, y, z);
        }

        public void Rotate(float angle, float x, float y, float z)
        {
            var angleFinal = MathHelper.DegreesToRadians(angle);
            Matrix4 rotationMatrix = Matrix4.CreateFromAxisAngle(new Vector3(x, y, z), angleFinal);
            var matrix4 = modelMatrix;
            Matrix4.Mult(ref rotationMatrix, ref matrix4, out matrix4);
            modelMatrix = matrix4;
        }
        
        // public void Rotate(float angle, float x, float y, float z)
        // {
        //     // Convertir ángulo a radianes
        //     var angleInRadians = MathHelper.DegreesToRadians(angle);
        //
        //     // Crear la matriz de rotación
        //     Matrix4 rotationMatrix = Matrix4.CreateFromAxisAngle(new Vector3(x, y, z), angleInRadians);
        //
        //     // Ajustar la posición
        //     var offset = new Vector3(position.X, position.Y, position.Z);
        //     modelMatrix = Matrix4.CreateTranslation(offset) * rotationMatrix * Matrix4.CreateTranslation(-offset);
        // }


    }
}