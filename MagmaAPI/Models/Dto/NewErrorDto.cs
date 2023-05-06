using System.Collections.Generic;

namespace MagmaAPI.Models.Dto
{
    public class NewErrorDto
    {
        public ScanDto Scan { get; set; }
        public List<FileDto> Files { get; set; }
    }
}
