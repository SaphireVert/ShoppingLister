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
    public class NotesController : ControllerBase
    {
        private readonly AppDataContext _context;

        public NotesController(AppDataContext context)
        {
            _context = context;
        }
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<NotesController> _logger;

        // public NotesController(ILogger<NotesController> logger)
        // {
        //     _logger = logger;
        // }

        [HttpGet]
        public string Get(int id, string toto){

            
            // _context.Add(new Note { Title = "tototutu", Content = "http://blogs.msdn.com/adonet" });
            // _context.SaveChanges();
            return "toto" + id + toto;
        }

        [HttpPost]
        public string Post(){
            _context.Add(new Note { Title = "tototutu", Content = "http://blogs.msdn.com/adonet" });
            _context.SaveChanges();
            return "toto";
        }

        [HttpPatch]
        public string Patch()
        {


            _context.Add(new Note { Title = "tototutu", Content = "http://blogs.msdn.com/adonet" });
            _context.SaveChanges();
            return "toto";
        }

        [HttpDelete]
        public string Delete()
        {


            _context.Add(new Note { Title = "tototutu", Content = "http://blogs.msdn.com/adonet" });
            _context.SaveChanges();
            return "toto";
        }
    }
}
