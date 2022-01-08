using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using UploadScorm.Core.Data;
using UploadScorm.Core.Service;

namespace UploadScorm.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScormVersionController : ControllerBase
    {
        private readonly IScormVersionService scormVersionService;
        public ScormVersionController(IScormVersionService scormVersionService)
        {
            this.scormVersionService = scormVersionService;
        }
        [ProducesResponseType(typeof(List<ScormVersion>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ScormVersion), StatusCodes.Status400BadRequest)]
        [HttpGet]
        [Route("GetScormVersion")]
        public List<ScormVersion> GetScormVersion()
        {
            return scormVersionService.GetScormVersion();
        }
    }
}
