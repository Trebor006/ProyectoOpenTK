using System;
using System.Collections.Generic;
using ProyectoOpenTK.GameLogic;
using Newtonsoft.Json;
using OpenTK;
using ProyectoOpenTK.Utils;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProyectoOpenTK.AnimationLogic;


namespace ProyectoOpenTK
{
    internal class Program
    {
        // [STAThread] // Atributo STAThread
        public static void Main(string[] args)
            // static void Main()
        {
            // Application.EnableVisualStyles();
            // Application.SetCompatibleTextRenderingDefault(false);
            // Application.Run(new MainForm());

            Libreto libreto = generarLibreto();
            FileHelper.mapLibretoToJson(libreto);
            
            Game juego = new Game(800, 600, "Demo OpenTK");
            // juego.stage = LoadFromJson();
            juego.stage = LoadStage();
            juego.moveTo(5, 0, 0);
            
            juego.stage.objects["bird"].resize(-0.05f, -0.05f, -0.05f);
            juego.stage.objects["bird"].rotate(-50,-1, 0, 0);
            juego.stage.objects["bird"].rotate(90,0, 0, -1);
            juego.stage.objects["bird"].moveTo(-5, 10, 0);
            
            juego.stage.objects["car"].rotate(90,0, 1,0 );
            juego.stage.objects["car"].moveTo(5, 0, 0);

            FileHelper.mapToJson(juego.stage);
            //
            ejecutarLibretoAutomaticamente(juego.generateObjectsDetailFromStages(), libreto);
            // Console.WriteLine("Juego Iniciado");
            juego.Run(60);
        }

        public static Stage LoadStage()
        {
            var originStage = Vector3.Zero;
            var originParedes = Vector3.Zero;
            var originTecho = new Vector3(0, 5, 0);
            var originCar = new Vector3(5, 0, 0);
            var originBird = new Vector3(0, 10, 0);

            var vertices = new float[]
            {
                -10 + 5f, 5f, 5f, //0
                -10 + 5f, -5f, 5f, //1
                -10 + -5f, -5f, 5f, //2
                -10 + -5f, 5f, 5f, //3
                -10 + 5f, 5f, -5f, //4
                -10 + 5f, -5f, -5f, //5
                -10 + -5f, -5f, -5f, //6
                -10 + -5f, 5f, -5f, //7
                -10 + 0f, 10f, 5f, //8
                -10 + 0f, 10f, -5f, //9
                -10 + 0f, 10f, -5f, //10
            };

            int[] indicesParedes = new[]
                { 0, 1, 2, 3, 0, 4, 5, 6, 7, 4, 5, 1, 0, 1, 2, 6, 5, 6, 2, 3, 7, 6, 5, 1, 0, 3, 7, 4 };
            int[] indicesTecho = new[] { 3, 0, 8, 3, 7, 9, 8, 3, 0, 4, 7, 4, 0, 3, 8, 10, 4, 0 };

            var paredes = new Part(vertices, indicesParedes, Point.MapFrom(originParedes));
            var techo = new Part(vertices, indicesTecho, Point.MapFrom(originTecho));

            var houseAndCar = new Stage(Point.MapFrom(Vector3.Zero), Point.MapFrom(Vector3.Zero));

            Dictionary<string, Part> houseParts = new Dictionary<string, Part>();

            houseParts.Add("paredes", paredes);
            houseParts.Add("techo", techo);

            var houseObject = new GraphicObject(Point.MapFrom(originStage), Point.MapFrom(Vector3.Zero), houseParts);

            var verticesCar = new float[]
            {
                0f, -2.5f, 3f, //0
                0.6f, -2.5f, 3f, //1
                1.2f, -2f, 3f, //2
                1.8f, -1f, 3f, //3
                2.4f, -2f, 3f, //4
                3f, -2.5f, 3f, //5
                3.5f, -2.5f, 3f, //6
                3.5f, 1f, 3f, // 7
                1.8f, 1f, 3f, // 8
                1.2f, 3f, 3f, // 9
                -1.2f, 3f, 3f, // 10
                -1.8f, 1f, 3f, // 11
                -3f, 1f, 3f, // 12
                -3f, -2.5f, 3f, // 13
                -2.4f, -2.5f, 3f, // 14
                -1.8f, -2f, 3f, // 15
                -1.2f, -1f, 3f, // 16
                -0.6f, -2.5f, 3f, // 17
                0f, -2.5f, -3f, //18    0
                0.6f, -2.5f, -3f, //19  1
                1.2f, -2f, -3f, //20    2
                1.8f, -1f, -3f, //21    3
                2.4f, -2f, -3f, //22    4
                3f, -2.5f, -3f, //23    5
                3.5f, -2.5f, -3f, //24  6
                3.5f, 1f, -3f, // 25    7
                1.8f, 1f, -3f, // 26    8
                1.2f, 3f, -3f, // 27    9
                -1.2f, 3f, -3f, // 28   10
                -1.8f, 1f, -3f, // 29   11
                -3f, 1f, -3f, // 30 12
                -3f, -2.5f, -3f, // 31  13
                -2.4f, -2.5f, -3f, // 32    14
                -1.8f, -2f, -3f, // 33  15
                -1.2f, -1f, -3f, // 34  16
                -0.6f, -2.5f, -3f, // 35    17
            };

            int[] indicesCarCapot = new[] { 12, 11, 29, 30 };
            int[] indicesCarParabrisas = new[] { 11, 10, 28, 29 };
            int[] indicesCarTecho = new[] { 10, 9, 27, 28 };
            int[] indicesCarParabrisasTrasero = new[] { 9, 8, 26, 27 };
            int[] indiceMaletero = new[] { 8, 7, 25, 26 };

            int[] indiceChasis = new[]
            {
                0, 1, 2, 3, 4, 5, 6,

                13, 31, 24, 6, 7, 6, 24, 25, 7,

                6, 13, 31, 24, 6, 7,


                8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 0,
                18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 18
            };


            Dictionary<string, Part> carParts = new Dictionary<string, Part>();
            // var caraCapot = new Part(verticesCar, indicesCarCapot, Point.MapFrom(originCar));
            // var caraParabrisas = new Part(verticesCar, indicesCarParabrisas, Point.MapFrom(originCar));
            // var caraTecho = new Part(verticesCar, indicesCarTecho, Point.MapFrom(originCar));
            // var caraParabrisasTrasero =
            //     new Part(verticesCar, indicesCarParabrisasTrasero, Point.MapFrom(originCar));
            // var caraMaletero = new Part(verticesCar, indiceMaletero, Point.MapFrom(originCar));
            // var chasis = new Part(verticesCar, indiceChasis, Point.MapFrom(originCar));

            // carParts.Add("chasis", chasis);
            // carParts.Add("capot", caraCapot);
            // carParts.Add("parabrisas", caraParabrisas);
            // carParts.Add("techo", caraTecho);
            // carParts.Add("parabrisasTrasero", caraParabrisasTrasero);
            // carParts.Add("maletero", caraMaletero);
            carParts.Add("car", FileHelper.LoadFileObj("car.obj"));
            

            var carObject = new GraphicObject(Point.MapFrom(originStage), Point.MapFrom(originCar), carParts);

            Dictionary<string, Part> birdParts = new Dictionary<string, Part>();
            birdParts.Add("bird", FileHelper.LoadFileObj("bird.obj"));
            var birdObject = new GraphicObject(Point.MapFrom(originStage), Point.MapFrom(originBird), birdParts);

            houseAndCar.AddObject("house", houseObject);
            houseAndCar.AddObject("car", carObject);
            houseAndCar.AddObject("bird", birdObject);

            return houseAndCar;
        }


        private static Libreto generarLibreto()
        {
            List<Accion> acciones = new List<Accion>();

            List<Transformacion> transformacionesObjeto1 = new List<Transformacion>
            {
                new Transformacion
                    { tipo = TipoAccion.ROTAR, valor = 90, inicio = 0, duracion = 1000, x = 0, y = 1, z = 0 },

                // Luego, nos achicamos para simular que nos alejamos
                new Transformacion
                {
                    tipo = TipoAccion.ESCALAR, valor = 0.5f, inicio = 1100, duracion = 5000, x = -1, y = -1, z = -1
                }, //3Seg
                new Transformacion
                {
                    tipo = TipoAccion.MOVER, valor = 25, inicio = 1000, duracion = 5000, x = 0, y = 1, z = 0
                }, //1 - 5

                // Giramos para comenzar a moverse alrededor de la montaña
                new Transformacion
                    { tipo = TipoAccion.ROTAR, valor = 90, inicio = 6000, duracion = 500, x = 0, y = 1, z = 0 }, //
                new Transformacion
                    { tipo = TipoAccion.MOVER, valor = 5, inicio = 6500, duracion = 1000, x = -1, y = 0, z = 0 },

                // Nos movemos a la izquierda por el camino sinuoso
                new Transformacion
                    { tipo = TipoAccion.MOVER, valor = 15, inicio = 8000, duracion = 10000, x = -1, y = 0, z = 0 },
                // new Transformacion
                //     { tipo = TipoAccion.ROTAR, valor = 30, inicio = 9000, duracion = 2000, x = 1, y = 0, z = 0 },
                // new Transformacion
                //     { tipo = TipoAccion.ROTAR, valor = 30, inicio = 10000, duracion = 2000, x = -1, y = 0, z = 0 },
                // new Transformacion
                //     { tipo = TipoAccion.ROTAR, valor = 30, inicio = 12000, duracion = 2000, x = 1, y = 0, z = 0 },
                // new Transformacion
                //     { tipo = TipoAccion.ROTAR, valor = 30, inicio = 13000, duracion = 2000, x = -1, y = 0, z = 0 },
                // new Transformacion
                //     { tipo = TipoAccion.ROTAR, valor = 2, inicio = 7000, duracion = 500, x = 1, y = 0, z = 1 },
                // new Transformacion
                //     { tipo = TipoAccion.ROTAR, valor = 2, inicio = 10000, duracion = 500, x = -1, y = 0, z = -1 },
                // new Transformacion
                //     { tipo = TipoAccion.ROTAR, valor = 2, inicio = 12000, duracion = 500, x = 1, y = 0, z = -1 },
                // new Transformacion
                //     { tipo = TipoAccion.ROTAR, valor = 2, inicio = 14000, duracion = 500, x = -1, y = 0, z = 1 },


                // // Giramos de nuevo para avanzar hacia la montaña
                new Transformacion
                    { tipo = TipoAccion.ROTAR, valor = 90, inicio = 18000, duracion = 500, x = 0, y = -1, z = 0 }, //
                //
                // // Nos agrandamos para simular que nos acercamos
                // new Transformacion
                // { tipo = TipoAccion.ESCALAR, valor = 0.5f, inicio = 18500, duracion = 5000, x = 1, y = 1, z = 1 },
                new Transformacion
                    { tipo = TipoAccion.MOVER, valor = 20, inicio = 18500, duracion = 5000, x = 0, y = -1, z = 0 },

                //
                // // Finalmente, nos movemos hacia la derecha para volver al punto de partida

                new Transformacion
                    { tipo = TipoAccion.ROTAR, valor = 30, inicio = 23500, duracion = 3000, x = 0, y = -1, z = 0 }, //
                new Transformacion
                    { tipo = TipoAccion.MOVER, valor = 35, inicio = 24000, duracion = 5000, x = 1, y = 0, z = 0 },

                new Transformacion
                    { tipo = TipoAccion.ROTAR, valor = 60, inicio = 27000, duracion = 500, x = 0, y = -1, z = 0 }, //

                new Transformacion
                    { tipo = TipoAccion.ESCALAR, valor = 0.5f, inicio = 24000, duracion = 5000, x = 1, y = 1, z = 1 },
            };

            Accion accion1 = new Accion("car", transformacionesObjeto1);

            Accion accion2 = new Accion
            {
                nombreObjeto = "bird",
                transformaciones = new List<Transformacion>
                {
                    new Transformacion
                        { tipo = TipoAccion.ROTAR, valor = 320, inicio = 10, duracion = 35000, x = 0, y = 0, z = 1 },
                    // new Transformacion { tipo = TipoAccion.ROTAR, valor = 90, inicio = 30000, duracion = 5000, x = -1, y = 0, z = 0 }
                }
            };

            acciones.Add(accion1);
            acciones.Add(accion2);
            // acciones.Add(accion3);
            // acciones.Add(accion4);
            // acciones.Add(accion5);
            // acciones.Add(accion1Car);

            Libreto libreto = new Libreto();
            libreto.acciones = acciones;

            return libreto;
        }

        public static async void ejecutarLibretoAutomaticamente(Dictionary<string, GraphicObject> objects,
            Libreto libreto)
        {
            Console.WriteLine("El juego deberia haberse iniciado ya");
            await Task.Delay(3000); // Esperar 10 segundos (10000 milisegundos)
            Ejecutor ejecutor = new Ejecutor(libreto, objects);
            await ejecutor.Play();
            Console.WriteLine("finalizado");
        }
    }
}