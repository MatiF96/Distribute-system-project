using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CinemaSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HostController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            return Ok($"Server host name: {Environment.MachineName}");
        }
    }
}
