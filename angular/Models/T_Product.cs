using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;



public class T_Product
{
    public T_Product()
    {
        
    }
    public T_Product(ProductDTO productDTO){
        id = productDTO.Id;
        Name = productDTO.Name;
        Brand = productDTO.Brand;
        CategoryId = productDTO.CategoryId;
    }
    public T_Product(string name, string brand){
        Name = name;
        Brand = brand;
    }
    public T_Product(int id, string name, string brand){
        this.id = id;
        Name = name;
        Brand = brand;
    }
    public int id { get; set; }
    public string Name { get; set; }
    public string Brand { get; set; }
    public bool isDeleted { get; set; }

    public int CategoryId { get; set; }
    public T_Category fk_Category { get; set; }
}
