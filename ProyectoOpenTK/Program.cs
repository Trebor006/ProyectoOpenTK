using System;
using System.Collections.Generic;
using ProyectoOpenTK.GameLogic;
using Newtonsoft.Json;
using OpenTK;
using ProyectoOpenTK.Utils;

namespace ProyectoOpenTK
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Game juego = new Game(800, 600, "Demo OpenTK");
            juego.stages = LoadFromJson();
            // juego.stages = LoadStage();
            // FileHelper.mapToJson(juego.stages);
            juego.Run(60);
        }

        private static Dictionary<string, Stage> LoadFromJson()
        {
            return FileHelper.loadFromJson("./Resources/archivito.json");
        }

        public static Dictionary<string, Stage> LoadStage()
        {
            var originStage = Vector3.Zero;
            var originParedes = Vector3.Zero;
            var originTecho = new Vector3(0, 5, 0);

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

            int[] indicesFrontal = new[] { 0, 1, 2, 3 };
            int[] indicesPosterior = new[] { 4, 5, 6, 7 };
            int[] indicesLateralDerecho = new[] { 0, 1, 5, 4 };
            int[] indicesLateralIzquierdo = new[] { 2, 3, 7, 6 };
            int[] indicesSuperior = new[] { 0, 3, 7, 4 };
            int[] indicesInferior = new[] { 1, 2, 6, 5 };

            int[] indicesCaraFrontalTecho = new[] { 2, 1, 8 };
            int[] indicesCaraPosteriorTecho = new[] { 6, 5, 9 };
            int[] indicesCaraLateralDerechaTecho = new[] { 1, 5, 10, 8 };
            int[] indicesCaraLateralIzquierdaTecho = new[] { 2, 6, 9, 8 };
            int[] indicesCaraInferiorTecho = new[] { 6, 5, 1 , 2 };

            var frontal = new Part(vertices, indicesFrontal, Point.MapFrom(originParedes));
            var posterior = new Part(vertices, indicesPosterior, Point.MapFrom(originParedes));
            var lateralDerecho = new Part(vertices, indicesLateralDerecho, Point.MapFrom(originParedes));
            var lateralIzquierdo = new Part(vertices, indicesLateralIzquierdo, Point.MapFrom(originParedes));

            var superior = new Part(vertices, indicesSuperior, Point.MapFrom(originParedes));
            var inferior = new Part(vertices, indicesInferior, Point.MapFrom(originParedes));

            var caraFrontalTecho = new Part(vertices, indicesCaraFrontalTecho, Point.MapFrom(originTecho));
            var caraPosteriorTecho = new Part(vertices, indicesCaraPosteriorTecho, Point.MapFrom(originTecho));
            var caraLateralDerechaTecho = new Part(vertices, indicesCaraLateralDerechaTecho, Point.MapFrom(originTecho));
            var caraLateralIzquierdaTecho = new Part(vertices, indicesCaraLateralIzquierdaTecho, Point.MapFrom(originTecho));
            var caraInferiorTecho = new Part(vertices, indicesCaraInferiorTecho, Point.MapFrom(originTecho));

            var houseAndCar = new Stage(Point.MapFrom(Vector3.Zero), Point.MapFrom(Vector3.Zero));

            Dictionary<string, Part> houseParts = new Dictionary<string, Part>();
            houseParts.Add("frontal", frontal);
            houseParts.Add("posterior", posterior);
            houseParts.Add("lateralDerecho", lateralDerecho);
            houseParts.Add("lateralIzquierdo", lateralIzquierdo);
            houseParts.Add("superior", superior);
            houseParts.Add("inferior", inferior);
            houseParts.Add("caraFrontalTecho", caraFrontalTecho);
            houseParts.Add("caraPosteriorTecho", caraPosteriorTecho);
            houseParts.Add("caraLateralDerechaTecho", caraLateralDerechaTecho);
            houseParts.Add("caraLateralIzquierdaTecho", caraLateralIzquierdaTecho);
            houseParts.Add("caraInferiorTecho", caraInferiorTecho);

            var houseObject = new GraphicObject(Point.MapFrom(originStage), Point.MapFrom(Vector3.Zero), houseParts);
            houseAndCar.AddObject("house", houseObject);
            // stage.AddObject("car", graphicObject);

            Dictionary<string, Stage> stages = new Dictionary<string, Stage>();

            stages.Add("HouseAndCar", houseAndCar);

            return stages;
        }
    }
}