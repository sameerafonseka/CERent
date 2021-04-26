using CERent.Product.Lib.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CERent.Product.Lib.Domain
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {
        }

        public DbSet<Equipment> Equipments { get; set; }

        public DbSet<Inventory> Inventory { get; set; }
    }
}
