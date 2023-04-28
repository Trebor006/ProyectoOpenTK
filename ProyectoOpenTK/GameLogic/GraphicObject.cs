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
            foreach (var part in parts)
            {
                part.Value.Scale(1.1f, 1.1f, 1.1f);
            }
        }

        public void decreaseSize()
        {
            foreach (var part in parts)
            {
                part.Value.Scale(0.9f, 0.9f, 0.9f);
            }
        }

        public void moveToUp()
        {
            foreach (var part in parts)
            {
                part.Value.Translate(0, 1, 0);
            }
        }

        public void moveToDown()
        {
            foreach (var part in parts)
            {
                part.Value.Translate(0, -1, 0);
            }
        }

        public void moveToLeft()
        {
            foreach (var part in parts)
            {
                part.Value.Translate(-1, 0, 0);
            }
        }

        public void moveToRight()
        {
            foreach (var part in parts)
            {
                part.Value.Translate(1, 0, 0);
            }
        }

        public void rotateUpY()
        {
            foreach (var part in parts)
            {
                part.Value.Rotate(10, 0, 1, 0);
            }
        }

        public void rotateDownY()
        {
            foreach (var part in parts)
            {
                part.Value.Rotate(10, 0, -1, 0);
            }
        }

        public void rotateRightX()
        {
            foreach (var part in parts)
            {
                part.Value.Rotate(10, 1, 0, 0);
            }
        }

        public void rotateLeftX()
        {
            foreach (var part in parts)
            {
                part.Value.Rotate(10, -1, 0, 0);
            }
        }
    }
}