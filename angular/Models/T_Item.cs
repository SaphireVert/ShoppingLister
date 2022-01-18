using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;


public class T_Item
{
    public int id { get; set; }
    public string Name { get; set; }
    public string Quantity { get; set; }

    public ICollection<T_List> fk_List { get; set; }
    public T_Product fk_Product { get; set; }
}
