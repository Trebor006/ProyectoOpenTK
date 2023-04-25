using System;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;
using ProyectoOpenTK.GameLogic;

namespace ProyectoOpenTK.Utils
{
    public class FileHelper
    {
        public static Stage loadFromJson(string fileName)
        {
            try
            {
                string jsonString = File.ReadAllText(fileName);
                Stage objeto = JsonConvert.DeserializeObject<Stage>(jsonString);
                Console.WriteLine(objeto);
                if (objeto is null) throw new Exception("Error on loading file");
                return objeto;
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
                var jsonSerializerSettings = new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                };
                string jsonString = JsonConvert.SerializeObject(stage, Formatting.Indented, jsonSerializerSettings);

                // string directoryPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                string directoryPath = "./Resources/";
                string finalPath = Path.Combine(directoryPath, "archivito.json");
                // File.Create(finalPath);
                // var fileStream = File.Open(finalPath, FileMode.Create);
                // // File.WriteAllText(Path.Combine(directoryPath, "archivito.json"), jsonString);
                // fileStream.

                
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