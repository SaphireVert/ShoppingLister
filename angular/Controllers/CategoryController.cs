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
        private readonly ILogger<CategoryController> _logger;


        public CategoryController(AppDataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public T_Category Get(int id){
            return _context.T_Category.FirstOrDefault(c => c.id == id);
        }

        [HttpGet]
        [Route("getAll")]
        public IEnumerable<T_Category> GetAll(){
            return _context.T_Category;
        }   

        [HttpPost]
        public string Post(T_Category category){
            Console.WriteLine("Posting Category...");
            _context.Add(category);
            _context.SaveChanges();
            return "Succeed";
        }

        [HttpPatch]
        public string Patch(int id, string name)
        {
            T_Category category = new T_Category() { id = id, Name = name };
            _context.Update(category);
            _context.SaveChanges();
            return "Succeed";
        }

        [HttpDelete]
        public string Delete(int id)
        {
            T_Category category = new T_Category() { id = id};
            _context.Remove(category);
            _context.SaveChanges();
            return "Succeed";
        }
    }
}
