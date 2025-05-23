﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace To_Do_List.Data
{
    public class ToDoListContext: DbContext
    {
        public ToDoListContext(DbContextOptions<ToDoListContext> options) : base(options) { }

        public DbSet<Item> Items { get; set; }
    }
}
