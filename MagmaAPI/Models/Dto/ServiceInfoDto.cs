using System;

namespace MagmaAPI.Models.Dto
{
    public class ServiceInfoDto
    {
        public string AppName { get; set; }
        public string Version { get; set; }
        public DateTime DateUtc => DateTime.UtcNow;
    }
}
