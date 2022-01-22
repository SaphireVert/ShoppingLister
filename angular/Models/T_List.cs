using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

public class T_List
{
    public T_List()
    {

    }
    public T_List(ListDTO listDTO)
    {
        id = listDTO.Id;
        Name = listDTO.Name;
    }
    public T_List(string name)
    {
        Name = name;
    }
    public T_List(int id, string name)
    {
        this.id = id;
        Name = name;
    }
    public int id { get; set; }
    public string Name { get; set; }
    public bool isDeleted { get; set; }

    public ICollection<T_Item> fk_Item { get; set; }
}
