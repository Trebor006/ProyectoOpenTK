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
            // var stage = JsonConvert.DeserializeObject<Stage>("");
            // var serializeObject = JsonConvert.SerializeObject(stage);

            var frontal = new Part(new float[] { 5f, 5f, 5f, 5f, -5f, 5f, -5f, -5f, 5f, -5f, 5f, 5f },
                Point.MapFrom(Vector3.Zero));
            var posterior = new Part(new float[] { 5f, 5f, -5f, 5f, -5f, -5f, -5f, -5f, -5f, -5f, 5f, -5f },
                Point.MapFrom(Vector3.Zero));
            var lateralDerecho = new Part(new float[] { 5f, 5f, 5f, 5f, -5f, 5f, 5f, -5f, -5f, 5f, 5f, -5f },
                Point.MapFrom(Vector3.Zero));
            var lateralIzquierdo = new Part(new float[] { -5f, -5f, 5f, -5f, 5f, 5f, -5f, 5f, -5f, -5f, -5f, -5f },
                Point.MapFrom(Vector3.Zero));
            var superior = new Part(new float[] { 5f, 5f, 5f, -5f, 5f, 5f, -5f, 5f, -5f, 5f, 5f, -5f },
                Point.MapFrom(Vector3.Zero));
            var inferior = new Part(new float[] { 5f, -5f, 5f, -5f, -5f, 5f, -5f, -5f, -5f, 5f, -5f, -5f },
                Point.MapFrom(Vector3.Zero));

            var stage = new Stage(Point.MapFrom(Vector3.Zero), Point.MapFrom(Vector3.Zero));

            Dictionary<string, Part> houseParts = new Dictionary<string, Part>();
            houseParts.Add("frontal", frontal);
            houseParts.Add("posterior", posterior);
            houseParts.Add("lateralDerecho", lateralDerecho);
            houseParts.Add("lateralIzquierdo", lateralIzquierdo);
            houseParts.Add("superior", superior);
            houseParts.Add("inferior", inferior);

            var houseObject = new GraphicObject(Point.MapFrom(Vector3.Zero), Point.MapFrom(Vector3.Zero), houseParts);
            stage.AddObject("house", houseObject);
            // stage.AddObject("car", graphicObject);


            Game juego = new Game(800, 600, "Demo OpenTK");
            juego.AddStage("HouseAndCar", stage);

            var mapToJson = FileHelper.mapToJson(stage);
            // var serializeObject = JsonConvert.SerializeObject(stage);
            Console.Write(mapToJson);

            juego.Run(60);
        }
    }
}