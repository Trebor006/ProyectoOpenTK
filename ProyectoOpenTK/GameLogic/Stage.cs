using System.Collections.Generic;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace ProyectoOpenTK.GameLogic
{
    public class Stage : Drawable
    {
        public Dictionary<string, GraphicObject> objects;

        public Point origin { get; set; }
        public Point position { get; set; }


        public Stage()
        {
            objects = new Dictionary<string, GraphicObject>();
            this.origin = Point.MapFrom(Vector3.Zero);
            this.position = Point.MapFrom(Vector3.Zero);
        }

        public Stage(Point origin, Point position)
        {
            objects = new Dictionary<string, GraphicObject>();
            this.origin = origin;
            this.position = position;
        }

        public void AddObject(string name, GraphicObject graphicObject)
        {
            // @object.SetInitialPosition(Point.MapFrom(Origin));
            objects.Add(name, graphicObject);
        }

        public void Draw()
        {
            GL.Rotate(20, 1, 1, 0);

            foreach (var actores in objects)
            {
                actores.Value.Draw();
            }
        }
    }
}