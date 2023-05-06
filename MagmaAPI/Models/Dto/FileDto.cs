using System.Collections.Generic;

namespace MagmaAPI.Models.Dto
{
    public class FileDto
    {
        public string Filename { get; set; }
        public bool Result { get; set; }
        public List<ErrorDto> Errors { get; set; }
    }
}
