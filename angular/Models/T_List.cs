using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

public class T_List
{
    public int id { get; set; }
    public string Name { get; set; }

    public ICollection<T_Item> fk_Item { get; set; }
}
