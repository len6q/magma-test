using MagmaAPI.Models;
using MagmaAPI.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Reflection;

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

        [HttpGet("errors")]
        public IActionResult GetErrors()
        {
            var errorDtos = _data.Files
                .Where(f => f.Result == false)
                .Select(f => new ErrorDto
                {
                    Filename = f.Filename,
                    Errors = f.Errors.Select(e => e.ErrorName).ToList()
                })
                .ToList();

            return Ok(errorDtos);
        }

        [HttpGet("errors/count")]
        public IActionResult GetErrorsCount()
        {
            return Ok(_data.Scan.ErrorCount);
        }

        [HttpGet("errors/{index}")]
        public IActionResult GetError(int index)
        {
            if(index < 0 || index >= _data.Scan.ErrorCount)
            {
                return BadRequest("Invalid index");
            }

            var errorDtos = _data.Files
                .Where(f => f.Result == false)
                .Select(f => new ErrorDto
                {
                    Filename = f.Filename,
                    Errors = f.Errors.Select(e => e.ErrorName).ToList()
                })
                .ToList();
            return Ok(errorDtos[index]);
        }

        [HttpGet("query/check")]
        public IActionResult GetQueryCheck()
        {
            var queryFiles = _data.Files
                .Where(f => f.Filename.ToLower().StartsWith("query_"));

            var queryCheckDto = new QueryCheckDto
            {
                Total = queryFiles.Count(),
                Correct = queryFiles.Count(f => f.Result == true),
                Errors = queryFiles.Count(f => f.Result == false),
                Filenames = queryFiles
                    .Where(f => f.Result == false)
                    .Select(f => f.Filename)
                    .ToList()
            };

            return Ok(queryCheckDto);
        }

        [HttpPost("newErrors")]
        public IActionResult PostNewErrors(
            [FromBody] NewErrorDto newErrorDto)
        {
            try
            {
                Serializer.Serialize(newErrorDto);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }            
        }

        [HttpGet("service/serviceInfo")]
        public IActionResult GetServiceInfo()
        {
            var assembly = Assembly.GetExecutingAssembly();           
            var serviceInfoDto = new ServiceInfoDto
            {
                AppName = assembly.GetName().Name,
                Version = assembly.GetName().Version.ToString()
            };

            return Ok(serviceInfoDto);
        }
    }
}
