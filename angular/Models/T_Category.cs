using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

public class T_Category
{
    public T_Category()
    {

    }
    public T_Category(CategoryDTO listDTO)
    {
        id = listDTO.Id;
        Name = listDTO.Name;
    }
    public T_Category(string name)
    {
        Name = name;
    }
    public T_Category(int id, string name)
    {
        this.id = id;
        Name = name;
    }
    public int id { get; set; }
    public string Name { get; set; }
    public bool isDeleted { get; set; }

    public ICollection<T_Product> fk_Product { get; set; }
}
