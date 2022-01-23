using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;


public class ItemViewDTO
{
    public ItemViewDTO() { }
    public ItemViewDTO(T_Item item)
    {
        Id = item.id;
        Quantity = item.Quantity;
    }
    public ItemViewDTO(int quantity)
    {
        Quantity = quantity;
    }
    public ItemViewDTO(int id, int quantity, string name, string brand, string category)
    {
        Id = id;
        Quantity = quantity;
        Name = name;
        Brand = brand;
        Category = category;
    }
    public int Id { get; set; }
    public string Name { get; set; }
    public string Brand { get; set; }
    public string Category { get; set; }
    public int Quantity { get; set; }
    public int ListId { get; set; }
    public int ProductId { get; set; }

}
