using Microsoft.EntityFrameworkCore;
using StockManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Shared.DataManagement
{
    public class ItemContext : DbContext
    {
        public DbSet<Laptop> Laptops { get; set; }

        public DbSet<GraphicsCard> GraphicsCards { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = ItemDataBase");
        }
    }
}