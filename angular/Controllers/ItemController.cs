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
        public ActionResult<ItemDTO> Get(int id){
            try
            {
                return new ItemDTO(_context.T_Item.FirstOrDefault(c => c.id == id));
            }
            catch (System.Exception)
            {
                return StatusCode(404);
            }
            // return new ItemDTO();
        }


        [HttpGet]
        [Route("getAll")]

        public ActionResult<List<ItemDTO>> GetAll(int id){
            var titems = _context.T_Item.Where(c => 1 == 1);
            List<ItemDTO> returnItem = new List<ItemDTO>();
            foreach (var element in titems)
            {
                returnItem.Add(new ItemDTO(element));
            }
            return returnItem;
        }


        [HttpGet]
        [Route("fromList")]
        public ActionResult<List<ItemDTO>> GetAllT_ItemsInList(int id){
            var titems = _context.T_Item.Where(c => c.ListId == id);
            List<ItemDTO> returnItem = new List<ItemDTO>();
            foreach (var element in titems)
            {
                returnItem.Add(new ItemDTO(element));
            }
            return returnItem;
        }


        [HttpPost]
        public StatusCodeResult Post([FromBody] ItemDTO itemDto){
            try
            {
                T_Item item = new T_Item(itemDto);
                item.fk_List = _context.T_List.Find(itemDto.ListId);
                item.fk_Product = _context.T_Product.Find(itemDto.ProductId);
                _context.Add(item);
                _context.SaveChanges();
                return StatusCode(200);
            }
            catch (System.Exception)
            {
                return StatusCode(400);
            }
        }

        [HttpPatch]
        public StatusCodeResult Patch([FromBody] ListDTO listDto)
        {
            try
            {
                T_List list = new T_List(listDto);
                _context.Update(list);
                _context.SaveChanges();
                return StatusCode(200);
            }
            catch (System.Exception)
            {
                return StatusCode(404);
            }
        }

        [HttpDelete]
        public StatusCodeResult Delete(int id)
        {
            try
            {
                T_Item item = _context.T_Item.Find(id);
                _context.Remove(item);
                _context.SaveChanges();
                return StatusCode(200);
            }
            catch (System.Exception)
            {
                return StatusCode(404);
            }
        }
    }
}
