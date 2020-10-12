using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TowerDefense.Data;

namespace TowerDefense.ViewModels.Maps
{
    public class MapViewModel
    {
        public string Name { get; set; }
        public List<MapPathCoordinate> Coordinates { get; set; }

        public static MapViewModel ConvertToViewModel(Map map)
        {
            return new MapViewModel
            {
                Name = map.Name,
                Coordinates = map.MapPathCoordinates.ToList()
            };
        }
    }
}
