namespace ProyectoOpenTK.AnimationLogic
{
    public class Transformacion
    {
        public TipoAccion tipo { get; set; }
        public long inicio { get; set; }
        public long duracion { get; set; }
        public float valor { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public int z { get; set; }

        public Transformacion()
        {
        }

        public Transformacion(TipoAccion tipo, long inicio, long duracion, float valor, int x, int y, int z)
        {
            this.tipo = tipo;
            this.inicio = inicio;
            this.duracion = duracion;
            this.valor = valor;
            this.x = x;
            this.y = y;
            this.z = z;
        }
    }

}