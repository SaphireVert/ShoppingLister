using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;


public class ProductDTO
{
    public ProductDTO() {}
    public ProductDTO(T_Product product){
        Id = product.id;
        Name = product.Name;
        Brand = product.Brand;
        CategoryId = product.CategoryId;
    }
    public ProductDTO(string name, string brand){
        Name = name;
        Brand = Brand;
    }
    public ProductDTO(string name, string brand, int T_CategoryId){
        Name = name;
        Brand = Brand;
        CategoryId = T_CategoryId;
    }
    public ProductDTO(int id, string name, string brand, int T_CategoryId){
        Id = id;
        Name = name;
        Brand = Brand;
        CategoryId = T_CategoryId;
    }
    public int Id { get; set; }
    public string Name { get; set; }
    public string Brand { get; set; }

    public int CategoryId { get; set; }
    public string CategoryName { get; set; }

}
