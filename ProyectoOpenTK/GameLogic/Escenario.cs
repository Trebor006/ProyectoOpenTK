using System.Collections.Generic;
using OpenTK.Graphics.OpenGL;

namespace ProyectoOpenTK.GameLogic
{
    public class Escenario
    {
        private IDictionary<string, Actor> actores;

        public Escenario()
        {
            actores = new Dictionary<string, Actor>();
            actores.Add("Actor", new Actor());
        }

        public void Dibujar()
        {
            GL.Rotate(20, 1, 1, 0);

            foreach (var actores in actores)
            {
                actores.Value.Dibujar();
            }
        }
    }
}