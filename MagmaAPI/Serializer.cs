using MagmaAPI.Models.Dto;
using System;
using System.IO;
using System.Text.Json;

namespace MagmaAPI
{
    public static class Serializer
    {
        private const string FILENAME = "Static/data.json";
        
        public static Models.Data Deserialize()
        {            
            string jsonString = File.ReadAllText(FILENAME);
            
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            Models.Data data = 
                JsonSerializer.Deserialize<Models.Data>(jsonString, options);
            
            return data;
        }

        public static void Serialize(NewErrorDto newErrorDto)
        {
            string path = $"Static/{DateTime.Now:dd-MM-yyyy_HH-mm-ss}.json";
            string json = JsonSerializer.Serialize(newErrorDto);
            File.WriteAllText(path, json);
        }
    }
}
