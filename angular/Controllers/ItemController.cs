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
        public T_Item Get(int id){
            return _context.T_Item.FirstOrDefault(c => c.id == id);
        }


        [HttpGet]
        [Route("getAll")]

        public IEnumerable<T_Item> GetAll(){
            Console.WriteLine("item.Name-----");
            return _context.T_Item.Where(c => 1 == 1);
        }


        [HttpGet]
        [Route("getAllItemsInList")]
        public List<T_Item> GetAllT_ItemsInList(int listId){
            // _context.T_ItemT_ItemList.Add(new Dictionary<string, object> { ["T_ItemListsid"] = 1, ["itemsid"] = 2 });

            return _context.T_Item.FromSqlRaw("SELECT i.id, i.Name, i.Quantity FROM T_Item i JOIN T_ItemT_ItemList iil ON i.id = iil.T_Itemsid JOIN T_ItemList il ON iil.T_ItemListsid = il.id WHERE il.id = " + listId).ToList();
            // .FromSqlRaw("SELECT * FROM dbo.Blogs")
            // .ToList();

        }


        [HttpPost]
        public T_Item Post(T_Item item){
            Console.WriteLine("Posting Item...");
            Console.WriteLine(item);
            _context.Add(item);
            _context.SaveChanges();
            return item;
        }

        [HttpPatch]
        public string Patch(int id, string name)
        {
            T_Item item = new T_Item() { id = id };
            _context.Update(item);
            _context.SaveChanges();
            return "Succeed";
        }

        [HttpDelete]
        public string Delete(int id)
        {
            T_Item item = new T_Item() { id = id};
            _context.Remove(item);
            _context.SaveChanges();
            Console.WriteLine("T_Item deleted");
            return "Succeed";
        }
    }
}
