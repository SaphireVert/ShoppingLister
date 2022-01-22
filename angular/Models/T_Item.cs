using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;


public class T_Item
{
    public T_Item()
    {

    }
    public T_Item(ItemDTO itemDto)
    {
        id = itemDto.Id;
        Quantity = itemDto.Quantity;
    }
    public T_Item(int quantity)
    {
        Quantity = quantity;
    }
    public T_Item(int id, int quantity)
    {
        this.id = id;
        Quantity = quantity;
    }
    public int id { get; set; }
    public int Quantity { get; set; }

    public T_List fk_List { get; set; }
    public T_Product fk_Product { get; set; }
}
