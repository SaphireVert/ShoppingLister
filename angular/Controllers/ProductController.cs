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
        public ActionResult<ProductDTO> Get(int id){

            T_Product product = _context.T_Product.FirstOrDefault(c => c.id == id);
            return new ProductDTO(product);

            // T_Product test = _context.T_Product.FirstOrDefault(c => c.id == id).;

            // return test.CategoryId;
            // _context.Entry(product).GetDatabaseValues();
            // Console.WriteLine(product.CategoryId);
            // try
            // {
            //     return new ProductDTO(_context.T_Product.FirstOrDefault(c => c.id == id));
            // }
            // catch (System.Exception)
            // {
            //     return StatusCode(404);
            // }
        }


        [HttpGet]
        [Route("getAll")]

        public ActionResult<List<ProductDTO>> GetAll(){

            // _context.T_Product

            // return _context.T_Product.FromSqlRaw("SELECT * FROM T_Product").ToList();
            // return Pro
            // return _context.T_Product.Select(p => new ProductDTO() {Id = p.id, Name = p.Name, Brand = p.Brand, CategoryId = p.CategoryId})
            //     .OrderBy(p => p.Id)
            //     .ToList();


            var tproducts = _context.T_Product.Where(c => c.isDeleted == false);
            List<ProductDTO> returnProduct = new List<ProductDTO>();
            foreach (var element in tproducts)
            {
                
                var tmpPdto = new ProductDTO(element);
                // Console.WriteLine(_context.T_Category.Find(tmpPdto.CategoryId).Name);
                if (tmpPdto.CategoryId != 0)
                {
                    tmpPdto.CategoryName = _context.T_Category.Find(tmpPdto.CategoryId).Name;
                    Console.WriteLine(_context.T_Category.Find(tmpPdto.CategoryId).Name);
                }
                returnProduct.Add(tmpPdto);
            }
            return returnProduct;
        }

        [HttpPost]
        public StatusCodeResult Post([FromBody] ProductDTO productDto){
            try
            {
                T_Product product = new T_Product(productDto);
                product.fk_Category = _context.T_Category.Find(productDto.CategoryId);
                _context.Add(product);
                _context.SaveChanges();
                if (product.fk_Category == null)
                {
                    productDto.CategoryId = 0;
                }
                productDto.Id = product.id;
                return StatusCode(200);
            }
            catch (System.Exception)
            {
                return StatusCode(400);
            }
            
        }

        [HttpPatch]
        public StatusCodeResult Patch([FromBody] ProductDTO productDto)
        {
            try
            {
                T_Product product = new T_Product(productDto);
                product.fk_Category = _context.T_Category.Find(productDto.CategoryId);
                _context.Update(product);
                _context.SaveChanges();
                ProductDTO productReturn = new ProductDTO(_context.T_Product.Find(productDto.Id));
                productReturn.CategoryId = productDto.CategoryId;
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
                T_Product product = _context.T_Product.Find(id);
                product.isDeleted = true;
                _context.Update(product);
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
