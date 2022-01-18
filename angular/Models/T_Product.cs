using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;


public class T_Product
{
    public int id { get; set; }
    public string Name { get; set; }
    public string Brand { get; set; }

    public ICollection<T_Item> fk_Item { get; set; }

    public T_Category fk_Category { get; set; }
}
