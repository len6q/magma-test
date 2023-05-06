using System.IO;
using System.Text.Json;

namespace MagmaAPI
{
    public static class Serializer
    {
        private const string FILENAME = "Static/data.json";
        
        public static void Deserialize()
        {            
            string jsonString = File.ReadAllText(FILENAME);
            
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            Models.Data data = 
                JsonSerializer.Deserialize<Models.Data>(jsonString, options);
            
        }
    }
}
