using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AutoDijelovi1.Models;

namespace AutoDijelovi1.Controllers
{
    public class SkladistesController : Controller
    {
        private readonly AutoDijelovi1Context _context;

        public SkladistesController(AutoDijelovi1Context context)
        {
            _context = context;
        }

        // GET: Skladistes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Skladiste.ToListAsync());
        }

        // GET: Skladistes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var skladiste = await _context.Skladiste
                .FirstOrDefaultAsync(m => m.SkladisteId == id);
            if (skladiste == null)
            {
                return NotFound();
            }

            return View(skladiste);
        }

        // GET: Skladistes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Skladistes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SkladisteId,NazivSkladista,Lokacija")] Skladiste skladiste)
        {
            if (ModelState.IsValid)
            {
                _context.Add(skladiste);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(skladiste);
        }

        // GET: Skladistes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var skladiste = await _context.Skladiste.FindAsync(id);
            if (skladiste == null)
            {
                return NotFound();
            }
            return View(skladiste);
        }

        // POST: Skladistes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SkladisteId,NazivSkladista,Lokacija")] Skladiste skladiste)
        {
            if (id != skladiste.SkladisteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(skladiste);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SkladisteExists(skladiste.SkladisteId))
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
            return View(skladiste);
        }

        // GET: Skladistes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var skladiste = await _context.Skladiste
                .FirstOrDefaultAsync(m => m.SkladisteId == id);
            if (skladiste == null)
            {
                return NotFound();
            }

            return View(skladiste);
        }

        // POST: Skladistes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var skladiste = await _context.Skladiste.FindAsync(id);
            _context.Skladiste.Remove(skladiste);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SkladisteExists(int id)
        {
            return _context.Skladiste.Any(e => e.SkladisteId == id);
        }
    }
}
