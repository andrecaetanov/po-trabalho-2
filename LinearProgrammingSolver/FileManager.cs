using LinearProgrammingSolver.Domain.Entities.Model;
using LinearProgrammingSolver.Domain.Entities.Result;
using System.IO;
using System.Text.Json;

namespace LinearProgrammingSolver
{
    public class FileManager
    {
        public static Model ReadModelFile(string fileName)
        {
            var jsonString = File.ReadAllText(fileName);
            return JsonSerializer.Deserialize<Model>(jsonString);
        }

        public static void WriteResultFile(string fileName, Result result)
        {
            var jsonString = JsonSerializer.Serialize(result);
            File.WriteAllText(fileName, jsonString);
        }
    }
}
