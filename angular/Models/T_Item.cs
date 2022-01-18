using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;


public class T_Item
{
    public int id { get; set; }
    public int Quantity { get; set; }

    public T_List fk_List { get; set; }
    public T_Product fk_Product { get; set; }
}
