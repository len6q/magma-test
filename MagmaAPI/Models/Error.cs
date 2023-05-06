using System.Text.Json.Serialization;

namespace MagmaAPI.Models
{
    public class Error
    {
        public string Module { get; set; }
        public int ECode { get; set; }
        
        [JsonPropertyName(nameof(Error))]
        public string ErrorName { get; set; }
    }
}
