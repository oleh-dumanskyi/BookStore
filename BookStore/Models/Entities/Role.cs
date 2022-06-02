using Microsoft.EntityFrameworkCore;

namespace BookStore.Models.Entities;

[Owned]
public class Role
{
    public Role(string name)
    {
        Name = name;
    }

    public string Name { get; set; }
}