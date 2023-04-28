using System.Collections.Generic;
using OpenTK;

namespace ProyectoOpenTK.GameLogic
{
    public class GraphicObject : Drawable, Trasladable
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
                part.Value.position = position;
                part.Value.Draw();
            }
        }

        public void AddPart(string name, Part part)
        {
            // part.position = origin;
            this.parts.Add(name, part);
        }

        public void increaseSize()
        {
            foreach (var objects in parts)
            {
                // objects.Value.Scale();
            }
        }

        public void decreaseSize()
        {
            foreach (var objects in parts)
            {
                // objects.Value.Scale();
            }
        }

        public void moveToUp()
        {
            foreach (var objects in parts)
            {
                
            }
        }

        public void moveToDown()
        {
            foreach (var objects in parts)
            {
                
            }
        }

        public void moveToLeft()
        {
            foreach (var objects in parts)
            {
                
            }
        }

        public void moveToRight()
        {
            foreach (var objects in parts)
            {
                
            }
        }
    }
}