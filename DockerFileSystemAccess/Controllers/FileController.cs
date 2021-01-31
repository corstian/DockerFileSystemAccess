using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;

namespace DockerFileSystemAccess.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FileController : ControllerBase
    {
        private readonly ILogger<FileController> _logger;

        public FileController(ILogger<FileController> logger)
        {
            _logger = logger;
        }

        [HttpGet("buildDirectory")]
        public IEnumerable<string> BuilDirectory()
        {
            var path = Path.Combine(
                Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location),
                "files");

            return Directory.GetFiles(path);
        }

        [HttpGet("specialFolders")]
        public IEnumerable<string> SpecialFolders()
        {
            var path = Path.Combine(
                Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location),
                "files");

            foreach (var val in (Environment.SpecialFolder[])Enum.GetValues(typeof(Environment.SpecialFolder)))
            {
                yield return $"{val.ToString()}: `{Environment.GetFolderPath(val)}`";

            }
        }

        [HttpGet("programData")]
        public IEnumerable<string> ProgramData()
        {
            var path = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
                "appName");

            return Directory.GetFiles(path);
        }
    }
}
