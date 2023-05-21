using System.Collections.Generic;
using OpenTK;
using ProyectoOpenTK.GameLogic.Interfaces;

namespace ProyectoOpenTK.GameLogic
{
    public class GraphicObject : IDrawable, ITrasladable, IScalable, IRotable
    {
        public Dictionary<string, Part> parts;

        public bool selected { get; set; }
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
                part.Value.position = position;
                part.Value.Draw();
            }
        }

        public void AddPart(string name, Part part)
        {
            // part.position = origin;
            this.parts.Add(name, part);
        }

        public void resize(float x, float y, float z)
        {
            foreach (var part in parts)
            {
                part.Value.Scale(x, y, z);
            }
        }

        public void moveTo(float x, float y, float z)
        {
            foreach (var part in parts)
            {
                part.Value.Translate(x, y, z);
            }
        }

        public void rotate(float angle, float x, float y, float z)
        {
            foreach (var part in parts)
            {
                part.Value.Rotate(angle, x, y, z);
            }
        }
    }
}