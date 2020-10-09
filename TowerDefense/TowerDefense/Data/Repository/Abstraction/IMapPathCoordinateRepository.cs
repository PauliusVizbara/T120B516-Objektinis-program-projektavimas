using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TowerDefense.Data.Repository.Abstraction
{
    public interface IMapPathCoordinateRepository
    {
        List<MapPathCoordinate> GetMapPathCoordinates(int mapId);
    }
}
