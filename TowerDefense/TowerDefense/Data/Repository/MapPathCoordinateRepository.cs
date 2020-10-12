using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TowerDefense.Data.Repository.Abstraction;

namespace TowerDefense.Data.Repository
{
    public class MapPathCoordinateRepository : IMapPathCoordinateRepository
    {
        private readonly ApplicationDbContext _context;

        public MapPathCoordinateRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<MapPathCoordinate>GetMapPathCoordinates(int mapId)
        {
            return _context.MapPathCoordinates.OrderBy(x => x.CoordinateIndex).ToList();
        }
    }
}
