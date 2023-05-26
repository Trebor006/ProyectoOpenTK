using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using ProyectoOpenTK.AnimationLogic;
using ProyectoOpenTK.GameLogic;

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
                string finalPath = Path.Combine(directoryPath, "archivito.json");

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
    }
}