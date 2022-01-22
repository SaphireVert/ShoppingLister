using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;


public class ListDTO
{
    public ListDTO() { }
    public ListDTO(T_List list)
    {
        Id = list.id;
        Name = list.Name;
    }
    public ListDTO(string name)
    {
        Name = name;
    }
    public ListDTO(int id, string name)
    {
        Id = id;
        Name = name;
    }
    public int Id { get; set; }
    public string Name { get; set; }
}
