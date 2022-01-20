using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;


namespace angular.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ListController : ControllerBase
    {
        private readonly AppDataContext _context;

        public ListController(AppDataContext context)
        {
            _context = context;
        }

        private readonly ILogger<ListController> _logger;

        [HttpGet]
        public T_List Get(int id){
            return _context.T_List.FirstOrDefault(c => c.id == id);
        }


        [HttpGet]
        [Route("getAll")]

        public IEnumerable<T_List> GetAll(){
            Console.WriteLine("list.Name-----");
            return _context.T_List.Where(c => 1 == 1);
        }

        [HttpPost]
        public T_List Post(T_List list){
            Console.WriteLine("Posting list...");
            Console.WriteLine(list.Name);
            _context.Add(list);
            _context.SaveChanges();
            return list;
        }

        [HttpPatch]
        public string Patch(int id, string name)
        {
            T_List list = new T_List() { id = id, Name = name };
            _context.Update(list);
            _context.SaveChanges();
            return "Succeed";
        }

        [HttpDelete]
        public string Delete(int id)
        {
            T_List list = new T_List() { id = id};
            _context.Remove(list);
            _context.SaveChanges();
            return "Succeed";
        }
    }
}
