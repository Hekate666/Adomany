using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AdomanyRaktar.Data;
using AdomanyRaktar.Models;
using Microsoft.AspNetCore.Authorization;

namespace AdomanyRaktar.Controllers
{
    public class AdatsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdatsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Adats
        public async Task<IActionResult> Index(string AdomanyKereso, string Kategoriakereso)
        {
            AdomanyKereses keresoAdomanyok = new AdomanyKereses();
            var adomanyok = _context.Adat.Select(x => x);
            if (!string.IsNullOrEmpty(AdomanyKereso))
            {
                keresoAdomanyok.AdomanyKereso = AdomanyKereso;
                adomanyok = adomanyok.Where(x => x.Adomany.Contains(AdomanyKereso));
            }

            if (!string.IsNullOrEmpty(Kategoriakereso))
            {
                keresoAdomanyok.KategoriaKereso = Kategoriakereso;
                adomanyok = adomanyok.Where(x => x.Kategoria.Equals(Kategoriakereso));
            }

            keresoAdomanyok.KategoriaLista = new SelectList(await _context.Adat.Select(x => x.Kategoria).Distinct().ToListAsync());
            keresoAdomanyok.Adomanyok = await adomanyok.ToListAsync();

            return View(keresoAdomanyok);

        }
        // GET: Adats/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adat = await _context.Adat
                .FirstOrDefaultAsync(m => m.Id == id);
            if (adat == null)
            {
                return NotFound();
            }

            return View(adat);
        }


        // GET: Adats/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Adats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Adomany,Kategoria,Csomegyseg,Mennyiseg")] Adat adat)
        {
            if (ModelState.IsValid)
            {
                _context.Add(adat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(adat);
        }

        // GET: Adats/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adat = await _context.Adat.FindAsync(id);
            if (adat == null)
            {
                return NotFound();
            }
            return View(adat);
        }

        // POST: Adats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Adomany,Kategoria,Csomegyseg,Mennyiseg")] Adat adat)
        {
            if (id != adat.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(adat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdatExists(adat.Id))
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
            return View(adat);
        }

        // GET: Adats/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adat = await _context.Adat
                .FirstOrDefaultAsync(m => m.Id == id);
            if (adat == null)
            {
                return NotFound();
            }

            return View(adat);
        }

        // POST: Adats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var adat = await _context.Adat.FindAsync(id);
            _context.Adat.Remove(adat);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdatExists(int id)
        {
            return _context.Adat.Any(e => e.Id == id);
        }
    }
}
