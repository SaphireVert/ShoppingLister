using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;


public class ItemViewDTO
{
    public ItemViewDTO() { }
    public ItemViewDTO(T_Item item)
    {
        Id = item.id;
        Quantity = item.Quantity;
        ListId = item.ListId;
        ProductId = item.ProductId;
    }
    public ItemViewDTO(int quantity)
    {
        Quantity = quantity;
    }
    public ItemViewDTO(int id, int quantity)
    {
        Id = id;
        Quantity = quantity;
    }
    public int Id { get; set; }
    public int Quantity { get; set; }
    public int ListId { get; set; }
    public int ProductId { get; set; }

}
