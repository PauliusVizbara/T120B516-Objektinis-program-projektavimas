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

            modelBuilder.Entity<Map>().HasData(new Map
            {
                Id = 1,
                Name = "Miškas"                
            });

            modelBuilder.Entity<MapPathCoordinate>().HasData(
                new MapPathCoordinate { CoordinateIndex = 1, XCoordinate = 1, YCoordinate = 2, MapId = 1, Id = 1 },
                new MapPathCoordinate { CoordinateIndex = 2, XCoordinate = 2, YCoordinate = 2, MapId = 1, Id = 2 },
                new MapPathCoordinate { CoordinateIndex = 3, XCoordinate = 3, YCoordinate = 2, MapId = 1, Id = 3 },
                new MapPathCoordinate { CoordinateIndex = 4, XCoordinate = 4, YCoordinate = 2, MapId = 1, Id = 4 },
                new MapPathCoordinate { CoordinateIndex = 5, XCoordinate = 5, YCoordinate = 2, MapId = 1, Id = 5 },
                new MapPathCoordinate { CoordinateIndex = 6, XCoordinate = 6, YCoordinate = 2, MapId = 1, Id = 6 },
                new MapPathCoordinate { CoordinateIndex = 7, XCoordinate = 7, YCoordinate = 2, MapId = 1, Id = 7 },
                new MapPathCoordinate { CoordinateIndex = 8, XCoordinate = 8, YCoordinate = 2, MapId = 1, Id = 8 },
                new MapPathCoordinate { CoordinateIndex = 9, XCoordinate = 8, YCoordinate = 3, MapId = 1, Id = 9 },
                new MapPathCoordinate { CoordinateIndex = 10, XCoordinate = 8, YCoordinate = 4, MapId = 1, Id = 10 },
                new MapPathCoordinate { CoordinateIndex = 11, XCoordinate = 8, YCoordinate = 5, MapId = 1, Id = 11 },
                new MapPathCoordinate { CoordinateIndex = 12, XCoordinate = 9, YCoordinate = 5, MapId = 1, Id = 12 },
                new MapPathCoordinate { CoordinateIndex = 13, XCoordinate = 10, YCoordinate = 5, MapId = 1, Id = 13 },
                new MapPathCoordinate { CoordinateIndex = 14, XCoordinate = 11, YCoordinate = 5, MapId = 1, Id = 14 },
                new MapPathCoordinate { CoordinateIndex = 15, XCoordinate = 12, YCoordinate = 5, MapId = 1, Id = 15 },
                new MapPathCoordinate { CoordinateIndex = 16, XCoordinate = 13, YCoordinate = 5, MapId = 1, Id = 16 },
                new MapPathCoordinate { CoordinateIndex = 17, XCoordinate = 14, YCoordinate = 5, MapId = 1, Id = 17 },
                new MapPathCoordinate { CoordinateIndex = 18, XCoordinate = 15, YCoordinate = 5, MapId = 1, Id = 18 }
            );
        }
    }
}
