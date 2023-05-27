using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using ProyectoOpenTK.AnimationLogic;
using ProyectoOpenTK.GameLogic;
using Assimp;
using System.Linq;


namespace ProyectoOpenTK.Utils
{
    public class FileHelper
    {
        public static Dictionary<string, Stage> loadFromJson(string fileName)
        {
            try
            {
                string jsonString = File.ReadAllText(fileName);
                Dictionary<string, Stage> stages = JsonConvert.DeserializeObject<Dictionary<string, Stage>>(jsonString);
                Console.WriteLine(stages);
                if (stages is null) throw new Exception("Error on loading file");
                return stages;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static Stage loadFromJsonString(string jsonString)
        {
            try
            {
                Stage stage = JsonConvert.DeserializeObject<Stage>(jsonString);
                return stage;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static Libreto loadLibreto(string jsonString)
        {
            try
            {
                Libreto libreto = JsonConvert.DeserializeObject<Libreto>(jsonString);
                return libreto;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static string mapToJson(Stage stage)
        {
            try
            {
                string jsonString = JsonConvert.SerializeObject(stage, Formatting.Indented);
                string directoryPath = "./Resources/";
                string finalPath = Path.Combine(directoryPath, "initial_state.json");

                using (StreamWriter sw = new StreamWriter(finalPath, false))
                {
                    sw.Write(jsonString);
                }

                return jsonString;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        public static string mapLibretoToJson(Libreto libreto)
        {
            try
            {
                string jsonString = JsonConvert.SerializeObject(libreto, Formatting.Indented);
                string directoryPath = "./Resources/";
                string finalPath = Path.Combine(directoryPath, "libreto.json");

                using (StreamWriter sw = new StreamWriter(finalPath, false))
                {
                    sw.Write(jsonString);
                }

                return jsonString;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static Part LoadFileObj(string objectName)
        {
            string directoryPath = "./Resources/";
            string finalPath = Path.Combine(directoryPath, objectName);

            using (var importer = new AssimpContext())
            {
                var scene = importer.ImportFile(finalPath, PostProcessPreset.TargetRealTimeMaximumQuality);

                if (scene != null && scene.HasMeshes)
                {
                    var mesh = scene.Meshes[0]; // Suponemos que solo hay un mesh en el archivo

                    var vertices = mesh.Vertices.Select(v => new float[] { v.X, v.Y, v.Z }).SelectMany(v => v)
                        .ToArray();
                    var indices = mesh.GetIndices();

                    // Utiliza los datos de vértices e índices según tu estructura y necesidades

                    // Ejemplo:
                    var part = new Part(vertices, indices, new Point(0, 0, 0));
                    return part;
                }
            }

            return null;
        }
    }
}