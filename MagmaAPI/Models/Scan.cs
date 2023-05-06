using System;

namespace MagmaAPI.Models
{
    public class Scan
    {
        public DateTime ScanTime { get; set; }
        public string Db { get; set; }
        public string Server { get; set; }
        public int ErrorCount { get; set; }
    }
}
