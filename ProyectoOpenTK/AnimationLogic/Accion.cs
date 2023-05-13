namespace ProyectoOpenTK.AnimationLogic
{
    public class Accion
    {
        public TipoAccion tipo { get; set; }
        public SubTipoAccion subtipo { get; set; }
        public float inicio { get; set; }
        public float duracion { get; set; }
        public float grados { get; set; }

        public Accion()
        {
        }

        public Accion(TipoAccion tipo, SubTipoAccion subtipo, float inicio, float duracion)
        {
            this.tipo = tipo;
            this.subtipo = subtipo;
            this.inicio = inicio;
            this.duracion = duracion;
            this.grados = 0;
        }

        public Accion(TipoAccion tipo, SubTipoAccion subtipo, float inicio, float duracion, float grados)
        {
            this.tipo = tipo;
            this.subtipo = subtipo;
            this.inicio = inicio;
            this.duracion = duracion;
            this.grados = grados;
        }
    }
}