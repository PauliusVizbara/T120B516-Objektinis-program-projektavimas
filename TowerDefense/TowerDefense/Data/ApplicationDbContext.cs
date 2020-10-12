using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TowerDefense.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Map> Maps { get; set; }
        public DbSet<MapPathCoordinate> MapPathCoordinates { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
