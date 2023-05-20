using System.Collections.Generic;

namespace ProyectoOpenTK.AnimationLogic
{
    public class Accion
    {
        public string nombreObjeto { get; set; }
        public List<Transformacion> transformaciones { get; set; }

        public Accion()
        {
            transformaciones = new List<Transformacion>();
        }

        public Accion(string nombreObjeto, List<Transformacion> transformaciones)
        {
            this.nombreObjeto = nombreObjeto;
            this.transformaciones = transformaciones;
        }
    }
}