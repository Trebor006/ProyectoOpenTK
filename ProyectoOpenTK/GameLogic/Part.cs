using System;
using Newtonsoft.Json;
using OpenTK;
using OpenTK.Graphics.OpenGL;


namespace ProyectoOpenTK.GameLogic
{
    public class Part : Drawable
    {
        [JsonIgnore] private int VAO;
        [JsonIgnore] private int VBO;
        [JsonIgnore] private int EBO;

        [JsonIgnore] private int vertexCount;
        [JsonIgnore] private int indices;

        public float[] vertices { get; set; }

        public Point origin { get; set; }
        public Point position { get; set; }

        public Part(float[] vertices, int[] indices, Point origin)
        {
            this.vertices = vertices;
            this.origin = origin;
            this.position = origin;

            // Crear y configurar el Vertex Array Object (VAO)
            VAO = GL.GenVertexArray();
            GL.BindVertexArray(VAO);

            // Crear y configurar el Vertex Buffer Object (VBO)
            VBO = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, VBO);
            GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(float), vertices,
                BufferUsageHint.StaticDraw);

            // Crear y configurar el Element Buffer Object (EBO)
            EBO = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, EBO);
            GL.BufferData(BufferTarget.ElementArrayBuffer, indices.Length * sizeof(int), indices,
                BufferUsageHint.StaticDraw);

            // Especificar el diseño de los atributos de vértice
            int vertexSize = 3 * sizeof(float); // Cada vértice tiene 3 componentes (x, y, z)
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, vertexSize, 0);
            GL.EnableVertexAttribArray(0);

            // Desvincular el VAO
            GL.BindVertexArray(0);

            vertexCount = indices.Length;
        }

        public void Draw()
        {
            GL.BindVertexArray(VAO);
            GL.DrawElements(PrimitiveType.LineLoop, vertexCount, DrawElementsType.UnsignedInt, 0);
            GL.BindVertexArray(0);
        }

        private float[] getVerticesToDraw()
        {
            float[] verticesCalculated = new float[vertices.Length];
            for (var i = 0; i < vertices.Length; i += 3)
            {
                verticesCalculated[i] = vertices[i] + origin.x + position.x;
                verticesCalculated[i + 1] = vertices[i + 1] + origin.y + position.y;
                verticesCalculated[i + 2] = vertices[i + 2] + origin.z + position.z;
            }

            return verticesCalculated;
        }

        public void Translate(float x, float y, float z)
        {
            GL.Translate(x, y, z);
        }

        public void Scale(float x, float y, float z)
        {
            GL.Scale(x, y, z);
        }

        public void Rotate(float angle, float x, float y, float z)
        {
            GL.Rotate(angle, x, y, z);
        }
    }
}