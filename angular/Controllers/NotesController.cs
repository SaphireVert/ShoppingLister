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

        private readonly ILogger<NotesController> _logger;

        [HttpGet]
        public Note Get(int id){
            return _context.Note.FirstOrDefault(c => c.id == id);
        }


        [HttpGet]
        [Route("getAll")]

        public IEnumerable<Note> GetAll(int id){
            return _context.Note.Where(c => 1 == 1);
        }

        [HttpPost]
        public string Post(string title, string content){
            _context.Add(new Note { Title = title, Content = content });
            _context.SaveChanges();
            return "Succeed";
        }

        [HttpPatch]
        public string Patch(int id, string title, string content)
        {
            Note note = new Note() { id = id, Title = title, Content = content };
            _context.Update(note);
            _context.SaveChanges();
            return "Succeed";
        }

        [HttpDelete]
        public string Delete(int id)
        {
            Note note = new Note() { id = id};
            _context.Remove(note);
            _context.SaveChanges();
            return "Succeed";
        }
    }
}
