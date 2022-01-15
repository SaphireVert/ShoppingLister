using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

public class Category
{
    public int id { get; set; }
    public string Name { get; set; }
    public ICollection<Item> Items { get; set; }
}
