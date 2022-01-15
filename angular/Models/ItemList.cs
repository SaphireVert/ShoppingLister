using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

public class ItemList
{
    public int id { get; set; }
    public string Name { get; set; }

    // public int ItemId { get; set; }
    public ICollection<Item> Items { get; set; }

    // public Item Item { get; set; }
    
}
