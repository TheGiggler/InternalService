using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace InternalService.Controllers
{
    [Route("api/time")]
    [ApiController]
    public class TimeController : ControllerBase
    {
        [HttpGet("")]
        public ActionResult<string> Get()
        {
            //get HOSTNAME variable for Pod
            //var hostnameMachine = Environment.GetEnvironmentVariable("HOSTNAME", EnvironmentVariableTarget.Machine);
            var hostnameProcess = Environment.GetEnvironmentVariable("HOSTNAME", EnvironmentVariableTarget.Process);
            //var hostnameUser = Environment.GetEnvironmentVariable("HOSTNAME", EnvironmentVariableTarget.User);

            return DateTime.UtcNow +  $", Service1 Hostname: {hostnameProcess}";
        }

        [HttpGet("health")]
        public StatusCodeResult GetIsAlive()
        {
            Random rnd = new Random();
            var x = rnd.Next();

            if (x % 2 == 0)
            {
                return new StatusCodeResult(200);
            }

            return new StatusCodeResult(500);

        }

    }
}