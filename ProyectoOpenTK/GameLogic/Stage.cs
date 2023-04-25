using System.Collections.Generic;
using OpenTK.Graphics.OpenGL;

namespace ProyectoOpenTK.GameLogic
{
    public class Stage : Drawable
    {
        private IDictionary<string, GraphicObject> actores;

        public Stage()
        {
            actores = new Dictionary<string, GraphicObject>();
            actores.Add("GraphicObject", new GraphicObject());
        }

        public void Draw()
        {
            GL.Rotate(20, 1, 1, 0);

            foreach (var actores in actores)
            {
                actores.Value.Draw();
            }
        }
    }
}