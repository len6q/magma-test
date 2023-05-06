using System;
using System.Collections.Generic;

namespace MagmaAPI.Models
{
    public class File
    {
        public string Filename { get; set; }
        public bool Result { get; set; }
        public List<Error> Errors { get; set; }
        public DateTime ScanTime { get; set; }
    }
}
