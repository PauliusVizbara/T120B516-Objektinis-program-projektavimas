using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TowerDefense.Models.Tower
{
    public class BuiltTower
    {
        public string TowerType { get; set; }
        public int xCoordinate { get; set; }
        public int yCoordinate { get; set; }
        public int Damage { get; set; }
        public int Range { get; set; }
        public int Id { get; set; }
    }
}
