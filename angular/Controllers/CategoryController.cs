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
        // [HttpGet("{id:int}")]
        [HttpGet]
        public ActionResult<CategoryDTO> Get(int id){
            return new CategoryDTO(_context.T_Category.FirstOrDefault(c => c.isDeleted == false));
        }

        [HttpGet]
        [Route("getAll")]
        public ActionResult<List<CategoryDTO>> GetAll(int id){
            var tcategory = _context.T_Category.Where(c => c.isDeleted == false);
            List<CategoryDTO> returnCategory = new List<CategoryDTO>();
            foreach (var element in tcategory)
            {
                returnCategory.Add(new CategoryDTO(element));
            }
            return returnCategory;
        }   

        [HttpPost]
        public StatusCodeResult Post([FromBody] CategoryDTO categoryDto){

            try
            {
                T_Category product = new T_Category(categoryDto);
                _context.Add(product);
                _context.SaveChanges();
                return StatusCode(200);
            }
            catch (System.Exception)
            {
                return StatusCode(400);
            }
        }

        [HttpPatch]
        public StatusCodeResult Patch([FromBody] CategoryDTO categoryDto)
        {
            try
            {
                T_Category category = new T_Category(categoryDto);
                _context.Update(category);
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
                T_Category category = _context.T_Category.Find(id);
                category.isDeleted = true;
                _context.Update(category);
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
