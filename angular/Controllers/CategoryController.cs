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
    public class CategoryController : ControllerBase
    {
        private readonly AppDataContext _context;

        public CategoryController(AppDataContext context)
        {
            _context = context;
        }

        private readonly ILogger<CategoryController> _logger;

        [HttpGet]
        public Category Get(int id){
            return _context.Category.FirstOrDefault(c => c.id == id);
        }


        [HttpGet]
        [Route("getAll")]

        public IEnumerable<Category> GetAll(int id){
            return _context.Category.Where(c => 1 == 1);
        }

        [HttpPost]
        public string Post(string name){
            _context.Add(new Category { Name = name });
            _context.SaveChanges();
            return "Succeed";
        }

        [HttpPatch]
        public string Patch(int id, string name)
        {
            Category category = new Category() { id = id, Name = name };
            _context.Update(category);
            _context.SaveChanges();
            return "Succeed";
        }

        [HttpDelete]
        public string Delete(int id)
        {
            Category category = new Category() { id = id};
            _context.Remove(category);
            _context.SaveChanges();
            return "Succeed";
        }
    }
}
