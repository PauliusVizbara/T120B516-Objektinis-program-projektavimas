using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TowerDefense.Data
{
    public class MapPathCoordinate
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }
        public int CoordinateIndex { get; set; }

        public int MapId { get; set; }
        [ForeignKey("MapId")]
        public Map Map { get; set; }
    }
}
