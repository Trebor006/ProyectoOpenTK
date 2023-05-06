using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;
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

        public static Dictionary<string, Stage> loadFromJsonString(string jsonString)
        {
            try
            {
                Dictionary<string, Stage> stages = JsonConvert.DeserializeObject<Dictionary<string, Stage>>(jsonString);
                return stages;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static string mapToJson(Dictionary<string, Stage> stages)
        {
            try
            {
                string jsonString = JsonConvert.SerializeObject(stages, Formatting.Indented);
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
    }
}