using System;
using System.Collections.Generic;
using OpenTK;

namespace ProyectoOpenTK.GameLogic
{
    public class Stage : Drawable, Trasladable, Scalable, Rotable
    {
        public Dictionary<string, GraphicObject> objects;

        public bool selected { get; set; }
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
            foreach (var objects in objects)
            {
                objects.Value.position = position;
                objects.Value.Draw();
            }
        }

        public void resize(float x, float y, float z)
        {
            foreach (var objects in objects)
            {
                objects.Value.resize(x, y, z);
            }
        }

        public void moveTo(float x, float y, float z)
        {
            foreach (var objects in objects)
            {
                objects.Value.moveTo(x, y, z);
            }
        }

        public void rotate(float angle, float x, float y, float z)
        {
            foreach (var objects in objects)
            {
                objects.Value.rotate(angle, x, y, z);
            }
        }
    }
}