using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TowerDefense.Data;
using TowerDefense.GameManagerSingleton;
using TowerDefense.ViewModels.Maps;

namespace TowerDefense.Controllers
{
    public class TowerDefenseController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TowerDefenseController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            
            return RedirectToAction(nameof(Game), new { mapId = 1 });
        }

        public IActionResult Game(int mapId)
        {
            var map = _context.Maps.Include(x => x.MapPathCoordinates).FirstOrDefault(x => x.Id == mapId);

            GameManager gameManager = GameManager.GetGameManager();
            gameManager.SetCoordinates(map.MapPathCoordinates.OrderBy(x => x.CoordinateIndex).ToList());

            return View(MapViewModel.ConvertToViewModel(map));
        }
    }
}
