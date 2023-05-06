using MagmaAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace MagmaAPI.Controllers
{
    [ApiController]
    [Route("api")]
    public class DataController : ControllerBase
    {
        private readonly Data _data;
        
        public DataController(Data data) =>
            _data = data;

        [HttpGet("allData")]
        public IActionResult GetData()
        {            
            return Ok(_data);
        }

        [HttpGet("scan")]
        public IActionResult GetScan()
        {
            return Ok(_data.Scan);
        }

        [HttpGet("filenames")]
        public IActionResult GetFilenames(bool correct)
        {
            var filenames = _data.Files
                .Where(f => f.Result == correct)
                .Select(f => f.Filename)
                .ToList();
            
            return Ok(filenames);
        }
    }
}
