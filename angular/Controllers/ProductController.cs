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
    public class ProductController : ControllerBase
    {
        private readonly AppDataContext _context;

        public ProductController(AppDataContext context)
        {
            _context = context;
        }

        private readonly ILogger<ProductController> _logger;

        [HttpGet]
        public T_Product Get(int id){
            return _context.T_Product.FirstOrDefault(c => c.id == id);
        }


        [HttpGet]
        [Route("getAll")]

        public IEnumerable<T_Product> GetAll(int id){
            return _context.T_Product.Where(c => 1 == 1);
        }

        [HttpPost]
        public ProductDTO Post([FromBody] ProductDTO productDto){
            T_Product product = new T_Product(productDto);
            product.fk_Category = _context.T_Category.Find(productDto.CategoryId);
            _context.Add(product);
            _context.SaveChanges();
            if (product.fk_Category == null)
            {
                productDto.CategoryId = null;
            }
                productDto.Id = product.id;
            return productDto;
        }

        [HttpPatch]
        public StatusCodeResult Patch([FromBody] ProductDTO productDto)
        {
            // T_Product product = new T_Product() { id = id, Name = name };
            T_Product product = new T_Product(productDto);
            product.fk_Category = _context.T_Category.Find(productDto.CategoryId);
            _context.Update(product);
            try
            {
                _context.SaveChanges();

            }
            catch (System.Exception)
            {
                return StatusCode(400);
            }
            _context.SaveChanges();
            ProductDTO productReturn = new ProductDTO(_context.T_Product.Find(productDto.Id));
            productReturn.CategoryId = productDto.CategoryId;
            return StatusCode(200);
        }

        [HttpDelete]
        public string Delete(int id)
        {
            // T_Product product = new T_Product() { id = id};
            // _context.Remove(product);
            // _context.SaveChanges();
            return "Succeed";
        }
    }
}
