using ProyectoOpenTK.GameLogic;

namespace ProyectoOpenTK
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Game juego = new Game(800, 600, "Demo OpenTK");
            juego.Run(60);
        }
    }
}