using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;


public class CategoryDTO
{
    public CategoryDTO() {}
    public CategoryDTO(T_Category category){
        Id = category.id;
        Name = category.Name;
    }
    public CategoryDTO(string name){
        Name = name;
    }
    public CategoryDTO(int id, string name){
        Id = id;
        Name = name;
    }
    public int Id { get; set; }
    public string Name { get; set; }

}
