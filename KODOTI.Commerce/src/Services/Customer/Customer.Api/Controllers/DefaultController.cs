using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customer.Api.Controllers
{

    [ApiController]
    [Route("/")]
    public class Controller : ControllerBase   {


        private readonly ILogger<Controller> _logger;

        public Controller(ILogger<Controller> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Get()
        {
            return "Running...";
        }
    }
}
