using Newtonsoft.Json;
using OpenTK;
using OpenTK.Graphics.OpenGL;


namespace ProyectoOpenTK.GameLogic
{
    public class Part : Drawable
    {
        [JsonIgnore]
        private int VAO;
        [JsonIgnore]
        private int VBO;

        [JsonIgnore]
        private int vertexCount;

        public float[] vertices { get; set; }

        public Point origin { get; set; }
        public Point position { get; set; }

        public Part(float[] vertices, Point origin)
        {
            this.vertices = vertices;
            this.origin = origin;
        }

        public void Draw()
        {
            // Crear un nuevo objeto de vértices
            VBO = GL.GenBuffer();

            // Crear un nuevo objeto de array de vértices
            VAO = GL.GenVertexArray();

            // Configurar el VAO y VBO
            GL.BindVertexArray(VAO);
            GL.BindBuffer(BufferTarget.ArrayBuffer, VBO);
            GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(float), vertices,
                BufferUsageHint.StaticDraw);

            // Especificar el diseño de los datos de vértices
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
            GL.EnableVertexAttribArray(0);

            // Liberar los recursos
            GL.BindVertexArray(0);
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);

            vertexCount = vertices.Length / 3;

            // Activar el VAO y dibujar la superficie
            GL.BindVertexArray(VAO);
            GL.DrawArrays(PrimitiveType.LineLoop, 0, vertexCount);
            GL.BindVertexArray(0);
        }
    }
}