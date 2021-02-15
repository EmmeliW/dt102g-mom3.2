using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EFprojekt.Data;
using EFprojekt.Models;

namespace EFProjektTry3.Controllers
{
    public class RecordController : Controller
    {
        private readonly RecordContext _context;

        public RecordController(RecordContext context)
        {
            _context = context;
        }

        // GET: Record
        public async Task<IActionResult> Index(string searchString)
        {
            var records = from m in _context.Records
                         select m;

            // If a searchstring is available Pick out all the matching data in database.
            // Tis includes all the columns in the table Record
            // You can search in artist, title or genre.
            if (!String.IsNullOrEmpty(searchString))
            {
                records = records.Where(s => s.Artist.ToLower().Contains(searchString.ToLower())
                                        || s.Title.ToLower().Contains(searchString.ToLower())
                                        || s.RecordGenre.ToLower().Contains(searchString.ToLower()));
            }

            return View(await records.ToListAsync());
        }
        // GET: Record/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var records = await _context.Records
                .FirstOrDefaultAsync(m => m.Id == id);
            if (records == null)
            {
                return NotFound();
            }

            return View(records);
        }

        // GET: Record/Create
        public IActionResult Create()
        {
            // Selecting genres from genre table to make it possible to choose between embedded genres
            var genresList = _context.Genres.FromSqlRaw("Select * from Genres").ToList();
            
            ViewBag.GenresList = genresList;

            return View();
        }

        // POST: Record/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Artist,Title,RecordGenre")] Records records)
        {
            if (ModelState.IsValid)
            {
                _context.Add(records);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(records);
        }

        // GET: Record/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var records = await _context.Records.FindAsync(id);
            if (records == null)
            {
                return NotFound();
            }
            // Selecting genres from genre table to make it possible to choose between embedded genres
            var genresList = _context.Genres.FromSqlRaw("Select * from Genres").ToList();
            
            ViewBag.GenresList = genresList;

            return View(records);
        }

        // POST: Record/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Artist,Title,RecordGenre")] Records records)
        {
            if (id != records.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(records);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecordsExists(records.Id))
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
            return View(records);
        }

        // GET: Record/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var records = await _context.Records
                .FirstOrDefaultAsync(m => m.Id == id);
            if (records == null)
            {
                return NotFound();
            }

            return View(records);
        }

        // POST: Record/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var records = await _context.Records.FindAsync(id);
            _context.Records.Remove(records);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecordsExists(int id)
        {
            return _context.Records.Any(e => e.Id == id);
        }
    }
}
