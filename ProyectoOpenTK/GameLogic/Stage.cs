using System;
using System.Collections.Generic;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace ProyectoOpenTK.GameLogic
{
    public class Stage : Drawable, Trasladable
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
            foreach (var objects in objects)
            {
                objects.Value.position = position;
                objects.Value.Draw();
            }
        }

        public void increaseSize()
        {
            Console.WriteLine("actualizando increaseSize");
            foreach (var objects in objects)
            {
                objects.Value.increaseSize();
            }
        }

        public void decreaseSize()
        {
            Console.WriteLine("actualizando decreaseSize");
            foreach (var objects in objects)
            {
                objects.Value.decreaseSize();
            }
        }

        public void moveToUp()
        {
            Console.WriteLine("actualizando posicion moveToUp");
            foreach (var objects in objects)
            {
                objects.Value.moveToUp();
            }
        }

        public void moveToDown()
        {
            Console.WriteLine("actualizando posicion moveToDown ");
            foreach (var objects in objects)
            {
                objects.Value.moveToDown();
            }
        }

        public void moveToLeft()
        {
            Console.WriteLine("actualizando posicion moveToLeft");
            foreach (var objects in objects)
            {
                objects.Value.moveToLeft();
            }
        }

        public void moveToRight()
        {
            Console.WriteLine("actualizando posicion moveToRight");
            foreach (var objects in objects)
            {
                objects.Value.moveToRight();
            }
        }
        
        public void rotateUpY()
        {
            foreach (var objects in objects)
            {
                objects.Value.rotateUpY();
            }
        }

        public void rotateDownY()
        {
            foreach (var objects in objects)
            {
                objects.Value.rotateDownY();
            }
        }

        public void rotateRightX()
        {
            foreach (var objects in objects)
            {
                objects.Value.rotateRightX();
            }
        }

        public void rotateLeftX()
        {
            foreach (var objects in objects)
            {
                objects.Value.rotateLeftX();
            }
        }
    }
}