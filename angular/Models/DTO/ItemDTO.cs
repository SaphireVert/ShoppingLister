using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;


public class ItemDTO
{
    public ItemDTO() { }
    public ItemDTO(T_Item item)
    {
        Id = item.id;
        Quantity = item.Quantity;
        ListId = item.ListId;
        ProductId = item.ProductId;
    }
    public ItemDTO(int quantity)
    {
        Quantity = quantity;
    }
    public ItemDTO(int id, int quantity)
    {
        Id = id;
        Quantity = quantity;
    }
    public int Id { get; set; }
    public int Quantity { get; set; }
    public int ListId { get; set; }
    public int ProductId { get; set; }

}
