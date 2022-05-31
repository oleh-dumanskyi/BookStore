﻿using Microsoft.EntityFrameworkCore;

namespace BookStore.Models.Entities
{
    [Owned]
    public class Role
    {
        public string Name { get; set; }
        public Role(string name) => Name = name;
    }
}
