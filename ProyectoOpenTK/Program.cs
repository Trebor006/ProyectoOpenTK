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
            var frontal = new Part(new float[] { 5f, 5f, 5f, 5f, -5f, 5f, -5f, -5f, 5f, -5f, 5f, 5f },
                Point.MapFrom(originParedes));
            var posterior = new Part(new float[] { 5f, 5f, -5f, 5f, -5f, -5f, -5f, -5f, -5f, -5f, 5f, -5f },
                Point.MapFrom(originParedes));
            var lateralDerecho = new Part(new float[] { 5f, 5f, 5f, 5f, -5f, 5f, 5f, -5f, -5f, 5f, 5f, -5f },
                Point.MapFrom(originParedes));
            var lateralIzquierdo = new Part(new float[] { -5f, -5f, 5f, -5f, 5f, 5f, -5f, 5f, -5f, -5f, -5f, -5f },
                Point.MapFrom(originParedes));
            var superior = new Part(new float[] { 5f, 5f, 5f, -5f, 5f, 5f, -5f, 5f, -5f, 5f, 5f, -5f },
                Point.MapFrom(originParedes));
            var inferior = new Part(new float[] { 5f, -5f, 5f, -5f, -5f, 5f, -5f, -5f, -5f, 5f, -5f, -5f },
                Point.MapFrom(originParedes));

            var originTecho = new Vector3(0, 0, 0);

            var caraFrontalTecho = new Part(new float[] { -5, -5, 5, 5, -5, 5, 0, 5, 5, }, Point.MapFrom(originTecho));
            var caraPosteriorTecho =
                new Part(new float[] { -5, -5, -5, 5, -5, -5, 0, 5, -5 }, Point.MapFrom(originTecho));
            var caraLateralDerechaTecho = new Part(new float[] { 5, -5, 5, 5, -5, -5, 0, 5, -5, 0, 5, 5, },
                Point.MapFrom(originTecho));
            var caraLateralIzquierdaTecho = new Part(
                new float[] { 0 - 5, -5, 0 + 5, 0 - 5, -5, 0 - 5, 0, 5, 0 - 5, 0, 5, 0 + 5, },
                Point.MapFrom(originTecho));
            var caraInferiorTecho = new Part(new float[] { -5, -5, 0 - 5, 5, -5, 0 - 5, +5, -5, 0 + 5, -5, -5, 0 + 5 },
                Point.MapFrom(originTecho));

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