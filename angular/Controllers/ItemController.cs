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
    public class ItemController : ControllerBase
    {
        private readonly AppDataContext _context;

        public ItemController(AppDataContext context)
        {
            _context = context;
        }

        private readonly ILogger<ItemController> _logger;

        [HttpGet]
        public Item Get(int id){
            return _context.Item.FirstOrDefault(c => c.id == id);
        }


        [HttpGet]
        [Route("getAll")]

        public IEnumerable<Item> GetAll(){
            Console.WriteLine("item.Name-----");
            return _context.Item.Where(c => 1 == 1);
        }

        
        [HttpGet]
        [Route("getAllItemsInList")]
        public List<Item> GetAllItemsInList(int listId){
            // _context.ItemItemList.Add(new Dictionary<string, object> { ["ItemListsid"] = 1, ["itemsid"] = 2 });

            return _context.Item.FromSqlRaw("SELECT i.id, i.Name, i.Quantity FROM Item i JOIN ItemItemList iil ON i.id = iil.Itemsid JOIN ItemList il ON iil.ItemListsid = il.id WHERE il.id = " + listId).ToList();
            // .FromSqlRaw("SELECT * FROM dbo.Blogs")
            // .ToList();

        }


        [HttpPost]
        public Item Post(Item item){
            Console.WriteLine("item.Name-----");
            Console.WriteLine(item.Name);
            _context.Add(item);
            _context.SaveChanges();
            return item;
        }

        [HttpPatch]
        public string Patch(int id, string name)
        {
            Item item = new Item() { id = id, Name = name };
            _context.Update(item);
            _context.SaveChanges();
            return "Succeed";
        }

        [HttpDelete]
        public string Delete(int id)
        {
            Item item = new Item() { id = id};
            _context.Remove(item);
            _context.SaveChanges();
            return "Succeed";
        }
    }
}
