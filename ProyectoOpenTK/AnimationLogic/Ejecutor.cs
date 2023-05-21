using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OpenTK;
using ProyectoOpenTK.GameLogic;

namespace ProyectoOpenTK.AnimationLogic
{
    public class Ejecutor
    {
        public Libreto libreto { get; set; }
        public Dictionary<string, GraphicObject> objects;

        public Ejecutor(Libreto libreto, Dictionary<string, GraphicObject> objects)
        {
            this.libreto = libreto;
            this.objects = objects;
        }

        public async Task Play()
        {
            var tasks = this.libreto.acciones.SelectMany(
                accion => accion.transformaciones.Select(transformacion =>
                    Task.Run(async () =>
                    {
                        await Task.Delay(TimeSpan.FromMilliseconds(transformacion.inicio));

                        accionar(objects[accion.nombreObjeto], transformacion);
                    })));

            await Task.WhenAll(tasks);
        }

        private void accionar(GraphicObject objeto, Transformacion transformacion)
        {
            double fpsObjetivo = 60.0;
            double fps = DisplayDevice.Default.RefreshRate;
            double factorCompensacion = fpsObjetivo / fps;
            double distancia = transformacion.valor; /* valor de la distancia en píxeles */
            double tiempo = transformacion.duracion / 1000.0; // Convertir a segundos
            double velocity = (distancia / tiempo) * factorCompensacion;

            DateTime tiempoActual = DateTime.Now;
            // var tiempoActual = Environment.TickCount;
            DateTime tiempoFin = DateTime.Now.AddMilliseconds(transformacion.duracion);

            Console.WriteLine("velocity " + velocity);

            while (DateTime.Now <= tiempoFin)
            {
                DateTime tiempoAnterior = tiempoActual;
                tiempoActual = DateTime.Now;

                double deltaTime = (tiempoActual - tiempoAnterior).TotalSeconds;
                Console.WriteLine("Delta " + deltaTime);

                if (transformacion.tipo == TipoAccion.MOVER)
                {
                    objeto.moveTo(
                        (float)(velocity * transformacion.x * deltaTime),
                        (float)(velocity * transformacion.y * deltaTime),
                        (float)(velocity * transformacion.z * deltaTime)
                    );
                }
                else if (transformacion.tipo == TipoAccion.ROTAR)
                {
                    objeto.rotate(
                        (float)((float)velocity * deltaTime),
                        (float)(transformacion.x),
                        (float)(transformacion.y),
                        (float)(transformacion.z)
                    );
                }
                else if (transformacion.tipo == TipoAccion.ESCALAR)
                {
                    float scaleFactorX = 1 + (float)(transformacion.x * deltaTime / tiempo);
                    float scaleFactorY = 1 + (float)(transformacion.y * deltaTime / tiempo);
                    float scaleFactorZ = 1 + (float)(transformacion.z * deltaTime / tiempo);

                    if (scaleFactorX < 0) scaleFactorX = 0.01f;
                    if (scaleFactorY < 0) scaleFactorY = 0.01f;
                    if (scaleFactorZ < 0) scaleFactorZ = 0.01f;

                    objeto.resize(
                        scaleFactorX,
                        scaleFactorY,
                        scaleFactorZ
                    );
                }
            }
        }
    }
}