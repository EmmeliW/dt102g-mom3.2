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
    public class LoanController : Controller 
    {
        private readonly RecordContext _context;

        public LoanController(RecordContext context)
        {
            _context = context;
        }

        // GET: Loan
        public async Task<IActionResult> Index()
        {
            return View(await _context.Loans.ToListAsync());
        }

        // GET: Loan/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loans = await _context.Loans
                .FirstOrDefaultAsync(m => m.Id == id);
            if (loans == null)
            {
                return NotFound();
            }

            return View(loans);
        }

        // GET: Loan/Create
        public IActionResult Create()
        {
            // Selecting Record data from Record table
            var TitleList = _context.Records.FromSqlRaw("Select * from Records").ToList();
            // Selecting Loan data fron Loan teble
            var LoanList = _context.Loans.FromSqlRaw("Select * from Loans").ToArray();

            // Create list to stor titles in
            List<string> Titles = new List<string>();
            // Loop the list witch recird data and add titles to list
            foreach (var item in TitleList)
            {
                Titles.Add(item.Title);
            }
            // Check the titles in Record table against the titles in Loan table to se if they match
            foreach (var TitleI in TitleList)
            {
                foreach (var TitleJ in LoanList)
                {
                    if (TitleJ.RecordName == TitleI.Title)
                    {
                        // If titles match remove them from list
                        // It means they are on loan already
                        Titles.Remove(TitleI.Title);
                    }
                }
            }
            // Send the title list with titles that are not on loan
            ViewBag.TitleList = Titles;
            return View();
        }

        // POST: Loan/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,LoanDate,Name,RecordName")] Loans loans)
        {
            if (ModelState.IsValid)
            {
                _context.Add(loans);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(loans);
        }

        // GET: Loan/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loans = await _context.Loans.FindAsync(id);
            if (loans == null)
            {
                return NotFound();
            }

            // Selecting Record data from Record table
            var TitleList = _context.Records.FromSqlRaw("Select * from Records").ToList();
            // Selecting Loan data fron Loan teble
            var LoanList = _context.Loans.FromSqlRaw("Select * from Loans").ToArray();

            // Create list to stor titles in
            List<string> Titles = new List<string>();
            // Loop the list witch recird data and add titles to list
            foreach (var item in TitleList)
            {
                Titles.Add(item.Title);
            }
            // Check the titles in Record table against the titles in Loan table to se if they match
            foreach (var TitleI in TitleList)
            {
                foreach (var TitleJ in LoanList)
                {
                    if (TitleJ.RecordName == TitleI.Title)
                    {
                        // If titles match remove them from list
                        // It means they are on loan already
                        Titles.Remove(TitleI.Title);
                    }
                }
            }
            // Send the title list with titles that are not on loan
            ViewBag.TitleList = Titles;
            return View(loans);
        }

        // POST: Loan/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,LoanDate,Name,RocordId")] Loans loans)
        {
            if (id != loans.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(loans);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoansExists(loans.Id))
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
            return View(loans);
        }

        // GET: Loan/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loans = await _context.Loans
                .FirstOrDefaultAsync(m => m.Id == id);
            if (loans == null)
            {
                return NotFound();
            }

            return View(loans);
        }

        // POST: Loan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var loans = await _context.Loans.FindAsync(id);
            _context.Loans.Remove(loans);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LoansExists(int id)
        {
            return _context.Loans.Any(e => e.Id == id);
        }
    }
}
