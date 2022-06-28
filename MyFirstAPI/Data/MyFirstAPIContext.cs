using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyFirstAPI;

namespace MyFirstAPI.Data
{
    public class MyFirstAPIContext : DbContext
    {
        public MyFirstAPIContext (DbContextOptions<MyFirstAPIContext> options)
            : base(options)
        {
        }

        public DbSet<MyFirstAPI.Employee>? Employee { get; set; }
    }
}
