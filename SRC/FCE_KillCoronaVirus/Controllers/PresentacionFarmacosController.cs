using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FCE_KillCoronaVirus.Models;

namespace FCE_KillCoronaVirus.Controllers
{
    public class PresentacionFarmacosController : Controller
    {
        private readonly KillCoronaVirusContext _context;

        public PresentacionFarmacosController(KillCoronaVirusContext context)
        {
            _context = context;
        }

        // GET: PresentacionFarmacos
        public async Task<IActionResult> Index(string NomPresentacion)
        {
            if (NomPresentacion != null)
            {
                var nompre = await _context.PresentacionFarmacos
                    .Where(p => p.NomPresentacion.Contains(NomPresentacion))
                    .ToListAsync();

                if (nompre == null)
                {
                    return NotFound();
                }
                return View(nompre);
            }
            else
            {
                return View(await _context.PresentacionFarmacos.ToListAsync());
            }
        }

        // GET: PresentacionFarmacos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PresentacionFarmacos == null)
            {
                return NotFound();
            }

            var presentacionFarmaco = await _context.PresentacionFarmacos
                .FirstOrDefaultAsync(m => m.CodPresentacion == id);
            if (presentacionFarmaco == null)
            {
                return NotFound();
            }

            return View(presentacionFarmaco);
        }

        // GET: PresentacionFarmacos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PresentacionFarmacos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodPresentacion,NomPresentacion")] PresentacionFarmaco presentacionFarmaco)
        {
            if (ModelState.IsValid)
            {
                _context.Add(presentacionFarmaco);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(presentacionFarmaco);
        }

        // GET: PresentacionFarmacos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PresentacionFarmacos == null)
            {
                return NotFound();
            }

            var presentacionFarmaco = await _context.PresentacionFarmacos.FindAsync(id);
            if (presentacionFarmaco == null)
            {
                return NotFound();
            }
            return View(presentacionFarmaco);
        }

        // POST: PresentacionFarmacos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodPresentacion,NomPresentacion")] PresentacionFarmaco presentacionFarmaco)
        {
            if (id != presentacionFarmaco.CodPresentacion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(presentacionFarmaco);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PresentacionFarmacoExists(presentacionFarmaco.CodPresentacion))
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
            return View(presentacionFarmaco);
        }

        // GET: PresentacionFarmacos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PresentacionFarmacos == null)
            {
                return NotFound();
            }

            var presentacionFarmaco = await _context.PresentacionFarmacos
                .FirstOrDefaultAsync(m => m.CodPresentacion == id);
            if (presentacionFarmaco == null)
            {
                return NotFound();
            }

            return View(presentacionFarmaco);
        }

        // POST: PresentacionFarmacos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PresentacionFarmacos == null)
            {
                return Problem("Entity set 'KillCoronaVirusContext.PresentacionFarmacos'  is null.");
            }
            var presentacionFarmaco = await _context.PresentacionFarmacos.FindAsync(id);
            if (presentacionFarmaco != null)
            {
                _context.PresentacionFarmacos.Remove(presentacionFarmaco);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PresentacionFarmacoExists(int id)
        {
            return _context.PresentacionFarmacos.Any(e => e.CodPresentacion == id);
        }
    }
}
