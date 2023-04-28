using System.Collections.Generic;
using OpenTK;

namespace ProyectoOpenTK.GameLogic
{
    public class GraphicObject : Drawable
    {
        public Dictionary<string, Part> parts;

        public Point origin { get; set; }
        public Point position { get; set; }

        public GraphicObject()
        {
            parts = new Dictionary<string, Part>();
            this.origin = Point.MapFrom(Vector3.Zero);
            this.position = Point.MapFrom(Vector3.Zero);
        }

        public GraphicObject(Point origin, Point position, Dictionary<string, Part> parts)
        {
            this.parts = parts;
            this.origin = origin;
            this.position = position;
        }

        public void Draw()
        {
            foreach (var part in parts)
            {
                part.Value.Draw();
            }
        }

        public void AddPart(string name, Part part)
        {
            // part.position = origin;
            this.parts.Add(name, part);
        }
    }
}