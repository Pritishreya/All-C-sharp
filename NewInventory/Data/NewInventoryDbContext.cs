using Microsoft.EntityFrameworkCore;
using NewInventory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewInventory.Data
{
    public class NewInventoryDbContext:DbContext
    {
        public NewInventoryDbContext(DbContextOptions options)
            :base(options)
        {

        }
        public DbSet<Inventory> Inventory { get; set; }
    }
}
