using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TowerDefense.Data;

namespace TowerDefense.Controllers
{
    public class MapPathCoordinatesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MapPathCoordinatesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MapPathCoordinates
        public async Task<IActionResult> Index()
        {
            var towerDefenseContext = _context.MapPathCoordinates.Include(m => m.Map);
            return View(await towerDefenseContext.ToListAsync());
        }

        // GET: MapPathCoordinates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mapPathCoordinate = await _context.MapPathCoordinates
                .Include(m => m.Map)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mapPathCoordinate == null)
            {
                return NotFound();
            }

            return View(mapPathCoordinate);
        }

        // GET: MapPathCoordinates/Create
        public IActionResult Create()
        {
            ViewData["MapId"] = new SelectList(_context.Set<Map>(), "Id", "Name");
            return View();
        }

        // POST: MapPathCoordinates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,XCoordinate,YCoordinate,CoordinateIndex,MapId")] MapPathCoordinate mapPathCoordinate)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mapPathCoordinate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MapId"] = new SelectList(_context.Set<Map>(), "Id", "Name", mapPathCoordinate.MapId);
            return View(mapPathCoordinate);
        }

        // GET: MapPathCoordinates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mapPathCoordinate = await _context.MapPathCoordinates.FindAsync(id);
            if (mapPathCoordinate == null)
            {
                return NotFound();
            }
            ViewData["MapId"] = new SelectList(_context.Set<Map>(), "Id", "Name", mapPathCoordinate.MapId);
            return View(mapPathCoordinate);
        }

        // POST: MapPathCoordinates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,XCoordinate,YCoordinate,CoordinateIndex,MapId")] MapPathCoordinate mapPathCoordinate)
        {
            if (id != mapPathCoordinate.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mapPathCoordinate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MapPathCoordinateExists(mapPathCoordinate.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["MapId"] = new SelectList(_context.Set<Map>(), "Id", "Name", mapPathCoordinate.MapId);
            return View(mapPathCoordinate);
        }

        // GET: MapPathCoordinates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mapPathCoordinate = await _context.MapPathCoordinates
                .Include(m => m.Map)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mapPathCoordinate == null)
            {
                return NotFound();
            }

            return View(mapPathCoordinate);
        }

        // POST: MapPathCoordinates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mapPathCoordinate = await _context.MapPathCoordinates.FindAsync(id);
            _context.MapPathCoordinates.Remove(mapPathCoordinate);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MapPathCoordinateExists(int id)
        {
            return _context.MapPathCoordinates.Any(e => e.Id == id);
        }
    }
}
