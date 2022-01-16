using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;


public class Item
{
    public int id { get; set; }
    public string Name { get; set; }
    public string Brand { get; set; }
    public ICollection<ItemList> ItemLists { get; set; }
    public ICollection<Category> Categories { get; set; }
    

    // public Note Note { get; set; }

}
