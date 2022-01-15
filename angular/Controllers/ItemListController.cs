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
    public class ItemListController : ControllerBase
    {
        private readonly AppDataContext _context;

        public ItemListController(AppDataContext context)
        {
            _context = context;
        }

        private readonly ILogger<ItemListController> _logger;

        [HttpGet]
        public ItemList Get(int id){
            return _context.ItemList.FirstOrDefault(c => c.id == id);
        }


        [HttpGet]
        [Route("getAll")]

        public IEnumerable<ItemList> GetAll(){
            Console.WriteLine("itemList.Name-----");
            return _context.ItemList.Where(c => 1 == 1);
        }

        [HttpPost]
        public ItemList Post(ItemList itemList){
            Console.WriteLine("itemList.Name-----");
            Console.WriteLine(itemList.Name);
            _context.Add(itemList);
            _context.SaveChanges();
            return itemList;
        }
        // [HttpPost]
        // [Route("addItemToList")]
        // public ItemList Post(Item item)
        // {
        //     // Console.WriteLine("itemList.Name-----");
        //     // Console.WriteLine(itemList.Name);
        //     // _context.ItemList.FromSqlRaw();
        //     // _context.SaveChanges();
        //     // return itemList;
        // }


        [HttpPatch]
        public string Patch(int id, string name)
        {
            ItemList itemList = new ItemList() { id = id, Name = name };
            _context.Update(itemList);
            _context.SaveChanges();
            return "Succeed";
        }

        [HttpDelete]
        public string Delete(int id)
        {
            ItemList itemList = new ItemList() { id = id};
            _context.Remove(itemList);
            _context.SaveChanges();
            return "Succeed";
        }
    }
}
