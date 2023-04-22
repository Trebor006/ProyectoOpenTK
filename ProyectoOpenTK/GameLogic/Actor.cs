using System.Collections.Generic;

namespace ProyectoOpenTK.GameLogic
{
    public class Actor
    {
        private IDictionary<string, Superficie> superficies;

        public Actor()
        {
            superficies = new Dictionary<string, Superficie>();
            superficies.Add("frontal", new Superficie(new float[]
                {
                    5f, 5f, 5f,
                    5f, -5f, 5f,
                    -5f, -5f, 5f,
                    -5f, 5f, 5f
                })
            );

            superficies.Add("posterior", new Superficie(new float[]
                {
                    5f, 5f, -5f,
                    5f, -5f, -5f,
                    -5f, -5f, -5f,
                    -5f, 5f, -5f,
                })
            );

            superficies.Add("lateralDerecho", new Superficie(new float[]
                {
                    5f, 5f, 5f,
                    5f, -5f, 5f,
                    5f, -5f, -5f,
                    5f, 5f, -5f,
                })
            );

            superficies.Add("lateralIzquierdo", new Superficie(new float[]
                {
                    -5f, -5f, 5f,
                    -5f, 5f, 5f,
                    -5f, 5f, -5f,
                    -5f, -5f, -5f,
                })
            );

            superficies.Add("superior", new Superficie(new float[]
                {
                    5f, 5f, 5f,
                    -5f, 5f, 5f,
                    -5f, 5f, -5f,
                    5f, 5f, -5f,
                })
            );

            superficies.Add("inferior", new Superficie(new float[]
                {
                    5f, -5f, 5f,
                    -5f, -5f, 5f,
                    -5f, -5f, -5f,
                    5f, -5f, -5f,
                })
            );
        }

        public void Dibujar()
        {
            foreach (var superficie in superficies)
            {
                superficie.Value.Dibujar();
            }
        }
    }
}