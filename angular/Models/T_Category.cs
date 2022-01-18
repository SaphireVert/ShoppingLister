using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

public class T_Category
{
    public int id { get; set; }
    public string Name { get; set; }
    public ICollection<T_Product> fk_Product { get; set; }
}
