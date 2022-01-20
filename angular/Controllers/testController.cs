using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace angular.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class testController : ControllerBase
    {
        private readonly AppDataContext _context;

        public testController(AppDataContext context)
        {
            _context = context;
        }

        private readonly ILogger<testController> _logger;

        [HttpGet]
        public T_Category Get()
        {
            return _context.T_Category.FirstOrDefault();
        }
    }
}
