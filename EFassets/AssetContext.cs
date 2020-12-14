using Microsoft.EntityFrameworkCore;
using EFassets.Domains;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace EFassets.Data
{
    public class AssetContext : DbContext
    {
        public DbSet<Asset> Assets { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Office> Offices { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
              "Server = (localdb)\\mssqllocaldb; Database = EFAssets;");
        }

    }
}
