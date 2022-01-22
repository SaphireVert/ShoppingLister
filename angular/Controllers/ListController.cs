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
        public ActionResult<ListDTO> Get(int id){
            try
            {
                return new ListDTO(_context.T_List.FirstOrDefault(c => c.id == id));
            }
            catch (System.Exception)
            {
                return StatusCode(404);
            }
        }


        [HttpGet]
        [Route("getAll")]

        public ActionResult<List<ListDTO>> GetAll(){
            var tlist = _context.T_List.Where(c => c.isDeleted == false);
            List<ListDTO> returnList = new List<ListDTO>();
            foreach (var element in tlist)
            {
                returnList.Add(new ListDTO(element));
            }
            return returnList;
        }

        [HttpPost]
        public StatusCodeResult Post([FromBody] ListDTO listDto){
            try
            {
                T_List list = new T_List(listDto);
                _context.Add(list);
                _context.SaveChanges();
                listDto.Id = list.id;
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
                T_List list = _context.T_List.Find(id);
                list.isDeleted = true;
                _context.Update(list);
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
