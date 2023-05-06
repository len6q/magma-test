using System.Collections.Generic;

namespace MagmaAPI.Models.Dto
{
    public class ErrorDto
    {
        public string Filename { get; set; }
        public List<string> Errors { get; set; }
    }
}
