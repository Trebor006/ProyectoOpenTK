using System.Collections.Generic;

namespace ProyectoOpenTK.GameLogic
{
    public class GraphicObject : Drawable
    {
        private IDictionary<string, Part> superficies;

        public GraphicObject()
        {
            superficies = new Dictionary<string, Part>();
            superficies.Add("frontal", new Part(new float[]
                {
                    5f, 5f, 5f,
                    5f, -5f, 5f,
                    -5f, -5f, 5f,
                    -5f, 5f, 5f
                })
            );

            superficies.Add("posterior", new Part(new float[]
                {
                    5f, 5f, -5f,
                    5f, -5f, -5f,
                    -5f, -5f, -5f,
                    -5f, 5f, -5f,
                })
            );

            superficies.Add("lateralDerecho", new Part(new float[]
                {
                    5f, 5f, 5f,
                    5f, -5f, 5f,
                    5f, -5f, -5f,
                    5f, 5f, -5f,
                })
            );

            superficies.Add("lateralIzquierdo", new Part(new float[]
                {
                    -5f, -5f, 5f,
                    -5f, 5f, 5f,
                    -5f, 5f, -5f,
                    -5f, -5f, -5f,
                })
            );

            superficies.Add("superior", new Part(new float[]
                {
                    5f, 5f, 5f,
                    -5f, 5f, 5f,
                    -5f, 5f, -5f,
                    5f, 5f, -5f,
                })
            );

            superficies.Add("inferior", new Part(new float[]
                {
                    5f, -5f, 5f,
                    -5f, -5f, 5f,
                    -5f, -5f, -5f,
                    5f, -5f, -5f,
                })
            );
        }

        public void Draw()
        {
            foreach (var superficie in superficies)
            {
                superficie.Value.Draw();
            }
        }
    }
}