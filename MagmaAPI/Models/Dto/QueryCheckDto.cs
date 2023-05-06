using System.Collections.Generic;

namespace MagmaAPI.Models.Dto
{
    public class QueryCheckDto
    {
        public int Total { get; set; }
        public int Correct { get; set; }
        public int Errors { get; set; }
        public List<string> Filenames { get; set; }
    }
}
