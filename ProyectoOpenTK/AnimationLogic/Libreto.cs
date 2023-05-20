using System.Collections.Generic;

namespace ProyectoOpenTK.AnimationLogic
{
    public class Libreto
    {
        public List<Accion> acciones { get; set; }

        public Libreto()
        {
            acciones = new List<Accion>();
        }

        public Libreto(List<Accion> acciones)
        {
            this.acciones = acciones;
        }
    }
}