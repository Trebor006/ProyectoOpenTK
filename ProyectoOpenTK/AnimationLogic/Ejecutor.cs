using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoOpenTK.GameLogic;

namespace ProyectoOpenTK.AnimationLogic
{
    public class Ejecutor
    {
        public Libreto libreto { get; set; }
        public float velocity { get; set; }
        public float velocityResize { get; set; }
        public float velocityRotation { get; set; }

        public Ejecutor(Libreto libreto)
        {
            this.libreto = libreto;
            velocity = 0.000001f;
            velocityResize = 0.00001f;
            velocityRotation = 0.0001f;
        }

        public void Play1(Game juego)
        {
            foreach (var action in this.libreto.acciones)
            {
                DateTime tiempoFin = DateTime.Now.AddSeconds(action.duracion);

                accionar(juego, tiempoFin, action);
            }
        }


        public async Task Play(Game juego)
        {
            var tasks = this.libreto.acciones.Select(action => Task.Run(async () =>
            {
                await Task.Delay(TimeSpan.FromSeconds(action.inicio));

                DateTime tiempoFin = DateTime.Now.AddSeconds(action.duracion);

                accionar(juego, tiempoFin, action);
            }));

            await Task.WhenAll(tasks);
        }

        private void accionar(Game juego, DateTime tiempoFin, Accion action)
        {
            while (DateTime.Now < tiempoFin)
            {
                if (action.tipo == TipoAccion.MOVER)
                {
                    accionarMover(juego, action);
                }
                else if (action.tipo == TipoAccion.ROTAR)
                {
                    accionarRotar(juego, action);
                }
                else if (action.tipo == TipoAccion.ESCALAR)
                {
                    accionarEscalar(juego, action);
                }
            }
        }

        private void accionarMover(Game juego, Accion action)
        {
            if (action.subtipo == SubTipoAccion.ARRIBA)
            {
                juego.moveTo(0, velocity, 0);
            }
            else if (action.subtipo == SubTipoAccion.ABAJO)
            {
                juego.moveTo(0, -velocity, 0);
            }
            else if (action.subtipo == SubTipoAccion.DERECHA)
            {
                juego.moveTo(velocity, 0, 0);
            }
            else if (action.subtipo == SubTipoAccion.IZQUIERDA)
            {
                juego.moveTo(-velocity, 0, 0);
            }
            else if (action.subtipo == SubTipoAccion.AL_FONDO)
            {
                juego.moveTo(0, 0, -velocity);
            }
            else if (action.subtipo == SubTipoAccion.AL_FRENTE)
            {
                juego.moveTo(0, 0, velocity);
            }
        }

        private void accionarRotar(Game juego, Accion action)
        {
            if (action.subtipo == SubTipoAccion.ROTAR_EJE_X)
            {
                juego.rotate(action.grados * velocityRotation, 1, 0, 0);
            }
            else if (action.subtipo == SubTipoAccion.ROTAR_EJE_X_NEGATIVE)
            {
                juego.rotate(action.grados * velocityRotation, -1, 0, 0);
            }
            else if (action.subtipo == SubTipoAccion.ROTAR_EJE_Y)
            {
                juego.rotate(action.grados * velocityRotation, 0, 1, 0);
            }
            else if (action.subtipo == SubTipoAccion.ROTAR_EJE_Y_NEGATIVE)
            {
                juego.rotate(action.grados * velocityRotation, 0, -1, 0);
            }
            else if (action.subtipo == SubTipoAccion.ROTAR_EJE_Z)
            {
                juego.rotate(action.grados * velocityRotation, 0, 0, 1);
            }
            else if (action.subtipo == SubTipoAccion.ROTAR_EJE_Z_NEGATIVE)
            {
                juego.rotate(action.grados * velocityRotation, 0, 0, -1);
            }
        }

        private void accionarEscalar(Game juego, Accion action)
        {
            if (action.subtipo == SubTipoAccion.AGRANDAR)
            {
                juego.resize(1 + velocityResize, 1 + velocityResize, 1 + velocityResize);
            }
            else if (action.subtipo == SubTipoAccion.ACHICAR)
            {
                juego.resize(1 - velocityResize, 1 - velocityResize, 1 - velocityResize);
            }
        }
    }
}