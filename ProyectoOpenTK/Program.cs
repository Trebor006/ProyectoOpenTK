using System;
using System.Collections.Generic;
using ProyectoOpenTK.GameLogic;
using Newtonsoft.Json;
using OpenTK;
using ProyectoOpenTK.Utils;
using System;
using System.Windows.Forms;


namespace ProyectoOpenTK
{
    internal class Program
    {
        [STAThread] // Atributo STAThread
        // public static void Main(string[] args)
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());

            //Game juego = new Game(800, 600, "Demo OpenTK");
            //juego.stages = LoadFromJson();
            // juego.stages = LoadStage();
            //FileHelper.mapToJson(juego.stages);
            //juego.Run(60);
        }


        public static Dictionary<string, Stage> LoadStage()
        {
            var originStage = Vector3.Zero;
            var originParedes = Vector3.Zero;
            var originTecho = new Vector3(0, 5, 0);
            var originCar = new Vector3(5, 0, 0);

            var vertices = new float[]
            {
                5f, 5f, 5f, //0
                5f, -5f, 5f, //1
                -5f, -5f, 5f, //2
                -5f, 5f, 5f, //3

                5f, 5f, -5f, //4
                5f, -5f, -5f, //5
                -5f, -5f, -5f, //6
                -5f, 5f, -5f, //7

                0f, 5f, 5f, //8
                0f, 5f, -5f, //9
                0f, 5f, -5f, //10
            };

            int[] indicesParedes = new[]
                { 0, 1, 2, 3, 0, 4, 5, 6, 7, 4, 5, 1, 0, 1, 2, 6, 5, 6, 2, 3, 7, 6, 5, 1, 0, 3, 7, 4 };
            int[] indicesTecho = new[] { 2, 1, 8, 2, 6, 9, 8, 2, 1, 5, 6, 5, 1, 2, 8, 10, 5, 1 };

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
            // int[] indicesCarLateralIzq = new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 };
            //int[] indicesCarLateralDer = new[]
            //     { 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35 };

            int[] indicesCarCapot = new[] { 12, 11, 29, 30 };
            int[] indicesCarParabrisas = new[] { 11, 10, 28, 29 };
            int[] indicesCarTecho = new[] { 10, 9, 27, 28 };
            int[] indicesCarParabrisasTrasero = new[] { 9, 8, 26, 27 };
            int[] indiceMaletero = new[] { 8, 7, 25, 26 };
            //int[] indicePosterior = new[] { 7, 6, 24, 25 };
            //int[] indiceInferior = new[] { 6, 13, 31, 24 };
            int[] indiceFrontal = new[] { 12, 13, 31, 30 };


            //int[] indicesCarLateralIzq = new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 };
            //int[] indicesCarLateralDer = new[]
            //    { 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35 };
            //int[] indicePosterior = new[] { 7, 6, 24, 25 };
            //int[] indiceInferior = new[] { 6, 13, 31, 24 };
            //int[] indiceFrontal = new[] { 12, 13, 31, 30 };

            int[] indiceChasis = new[]
            {
                0, 1, 2, 3, 4, 5, 6,

                13, 31, 24, 6, 7, 6, 24, 25, 7,

                6, 13, 31, 24, 6, 7,


                8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 0,
                18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 18

                //      7, 6, 24, 25 , 7 ,
                //     6, 13, 31, 24 , 6,

                //6, 13, 31, 24, 6
            };


            Dictionary<string, Part> carParts = new Dictionary<string, Part>();
            //var carLateralIzq = new Part(verticesCar, indicesCarLateralIzq, Point.MapFrom(originCar));
            //var carLateralDer = new Part(verticesCar, indicesCarLateralDer, Point.MapFrom(originCar));
            var caraCapot = new Part(verticesCar, indicesCarCapot, Point.MapFrom(originCar));
            var caraParabrisas = new Part(verticesCar, indicesCarParabrisas, Point.MapFrom(originCar));
            var caraTecho = new Part(verticesCar, indicesCarTecho, Point.MapFrom(originCar));
            var caraParabrisasTrasero =
                new Part(verticesCar, indicesCarParabrisasTrasero, Point.MapFrom(originCar));
            var caraMaletero = new Part(verticesCar, indiceMaletero, Point.MapFrom(originCar));
            //var caraPosterior = new Part(verticesCar, indicePosterior, Point.MapFrom(originCar));
            //var caraInferior = new Part(verticesCar, indiceInferior, Point.MapFrom(originCar));
            //var caraFrontal = new Part(verticesCar, indiceFrontal, Point.MapFrom(originCar));
            var chasis = new Part(verticesCar, indiceChasis, Point.MapFrom(originCar));
            //carParts.Add("carLateralIzq", carLateralIzq);
            //carParts.Add("carLateralDer", carLateralDer);
            //carParts.Add("caraPosterior", caraPosterior);
            //carParts.Add("caraInferior", caraInferior);
            //carParts.Add("caraFrontal", caraFrontal);

            carParts.Add("chasis", chasis);
            carParts.Add("capot", caraCapot);
            carParts.Add("parabrisas", caraParabrisas);
            carParts.Add("techo", caraTecho);
            carParts.Add("parabrisasTrasero", caraParabrisasTrasero);
            carParts.Add("maletero", caraMaletero);

            var carObject = new GraphicObject(Point.MapFrom(originStage), Point.MapFrom(Vector3.Zero), carParts);

            houseAndCar.AddObject("house", houseObject);
            houseAndCar.AddObject("car", carObject);

            // stage.AddObject("car", graphicObject);

            Dictionary<string, Stage> stages = new Dictionary<string, Stage>();

            stages.Add("HouseAndCar", houseAndCar);

            return stages;
        }
    }
}