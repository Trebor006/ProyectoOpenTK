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

        public float[] vertices { get; set; }
        public int[] indices;

        public Point origin { get; set; }
        public Point position { get; set; }
        [JsonIgnore] public Matrix4 modelMatrix { get; private set; }

        public Part(float[] vertices, int[] indices, Point origin)
        {
            this.vertices = vertices;
            this.origin = origin;
            this.position = origin;
            this.indices = indices;
            modelMatrix = Matrix4.Identity;

            // Crear y configurar el Vertex Array Object (VAO)
            VAO = GL.GenVertexArray();
            GL.BindVertexArray(VAO);

            // Crear y configurar el Vertex Buffer Object (VBO)
            VBO = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, VBO);
            GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(float), getVerticesToDraw(),
                BufferUsageHint.StaticDraw);

            // Crear y configurar el Element Buffer Object (EBO)
            EBO = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, EBO);
            GL.BufferData(BufferTarget.ElementArrayBuffer, this.indices.Length * sizeof(int), this.indices,
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
            modelMatrix *= Matrix4.CreateTranslation(new Vector3(x, y, z));
        }

        public void Scale(float x, float y, float z)
        {
            Matrix4 scaleMatrix = Matrix4.CreateScale(x, y, z);
            modelMatrix *= scaleMatrix;
        }

        public void Rotate(float angle, float x, float y, float z)
        {
            if (x > 0 || x < 0)
            {
                modelMatrix *= Matrix4.CreateRotationX(MathHelper.DegreesToRadians(angle * x));
            }

            if (y > 0 || y < 0)
            {
                modelMatrix *= Matrix4.CreateRotationY(MathHelper.DegreesToRadians(angle * y));
            }

            if (z > 0 || z < 0)
            {
                modelMatrix *= Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(angle * z));
            }
        }
    }
}