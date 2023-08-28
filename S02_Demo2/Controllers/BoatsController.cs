using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using S02_Demo2.Data;
using S02_Demo2.Models;

namespace S02_Demo2.Controllers
{
    public class BoatsController : Controller
    {
        private readonly S02_Demo2Context _context;

        public BoatsController(S02_Demo2Context context)
        {
            _context = context;
        }

        // GET: Boats
        public IActionResult Index()
        {
              return View(_context.Boat.ToList());
        }

        // GET: Boats/Details/5
        public IActionResult Details(int? id)
        {
            var boat = _context.Boat
                .FirstOrDefault(m => m.Id == id);
            if (boat == null)
            {
                return NotFound();
            }

            return View(boat);
        }

        // GET: Boats/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Boats/Create
        [HttpPost]
        public IActionResult Create(Boat boat)
        {
            if (ModelState.IsValid)
            {
                _context.Add(boat);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(boat);
        }

        // GET: Boats/Edit/5
        public IActionResult Edit(int? id)
        {

            var boat = _context.Boat.Find(id);
            if (boat == null)
            {
                return NotFound();
            }
            return View(boat);
        }

        // POST: Boats/Edit/5
        [HttpPost]
        public IActionResult Edit(int id, Boat boat)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(boat);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BoatExists(boat.Id))
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
            return View(boat);
        }

        // GET: Boats/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Boat == null)
            {
                return NotFound();
            }

            var boat = await _context.Boat
                .FirstOrDefaultAsync(m => m.Id == id);
            if (boat == null)
            {
                return NotFound();
            }

            return View(boat);
        }

        // POST: Boats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Boat == null)
            {
                return Problem("Entity set 'S02_Demo2Context.Boat'  is null.");
            }
            var boat = await _context.Boat.FindAsync(id);
            if (boat != null)
            {
                _context.Boat.Remove(boat);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BoatExists(int id)
        {
          return (_context.Boat?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
