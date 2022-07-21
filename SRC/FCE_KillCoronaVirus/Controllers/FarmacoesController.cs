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
    public class FarmacoesController : Controller
    {
        private readonly KillCoronaVirusContext _context;

        public FarmacoesController(KillCoronaVirusContext context)
        {
            _context = context;
        }

        // GET: Farmacoes
        public async Task<IActionResult> Index()
        {
            var killCoronaVirusContext = _context.Farmacos.Include(f => f.CodPresentacionNavigation).Include(f => f.CodUomNavigation);
            return View(await killCoronaVirusContext.ToListAsync());
        }

        // GET: Farmacoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Farmacos == null)
            {
                return NotFound();
            }

            var farmaco = await _context.Farmacos
                .Include(f => f.CodPresentacionNavigation)
                .Include(f => f.CodUomNavigation)
                .FirstOrDefaultAsync(m => m.CodFar == id);
            if (farmaco == null)
            {
                return NotFound();
            }

            return View(farmaco);
        }

        // GET: Farmacoes/Create
        public IActionResult Create()
        {
            ViewData["CodPresentacion"] = new SelectList(_context.PresentacionFarmacos, "CodPresentacion", "CodPresentacion");
            ViewData["CodUom"] = new SelectList(_context.UnidadDeMedida, "CodUom", "CodUom");
            return View();
        }

        // POST: Farmacoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodFar,NomFar,Concentracion,CodUom,CodPresentacion")] Farmaco farmaco)
        {
            if (ModelState.IsValid)
            {
                _context.Add(farmaco);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CodPresentacion"] = new SelectList(_context.PresentacionFarmacos, "CodPresentacion", "CodPresentacion", farmaco.CodPresentacion);
            ViewData["CodUom"] = new SelectList(_context.UnidadDeMedida, "CodUom", "CodUom", farmaco.CodUom);
            return View(farmaco);
        }

        // GET: Farmacoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Farmacos == null)
            {
                return NotFound();
            }

            var farmaco = await _context.Farmacos.FindAsync(id);
            if (farmaco == null)
            {
                return NotFound();
            }
            ViewData["CodPresentacion"] = new SelectList(_context.PresentacionFarmacos, "CodPresentacion", "CodPresentacion", farmaco.CodPresentacion);
            ViewData["CodUom"] = new SelectList(_context.UnidadDeMedida, "CodUom", "CodUom", farmaco.CodUom);
            return View(farmaco);
        }

        // POST: Farmacoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodFar,NomFar,Concentracion,CodUom,CodPresentacion")] Farmaco farmaco)
        {
            if (id != farmaco.CodFar)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(farmaco);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FarmacoExists(farmaco.CodFar))
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
            ViewData["CodPresentacion"] = new SelectList(_context.PresentacionFarmacos, "CodPresentacion", "CodPresentacion", farmaco.CodPresentacion);
            ViewData["CodUom"] = new SelectList(_context.UnidadDeMedida, "CodUom", "CodUom", farmaco.CodUom);
            return View(farmaco);
        }

        // GET: Farmacoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Farmacos == null)
            {
                return NotFound();
            }

            var farmaco = await _context.Farmacos
                .Include(f => f.CodPresentacionNavigation)
                .Include(f => f.CodUomNavigation)
                .FirstOrDefaultAsync(m => m.CodFar == id);
            if (farmaco == null)
            {
                return NotFound();
            }

            return View(farmaco);
        }

        // POST: Farmacoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Farmacos == null)
            {
                return Problem("Entity set 'KillCoronaVirusContext.Farmacos'  is null.");
            }
            var farmaco = await _context.Farmacos.FindAsync(id);
            if (farmaco != null)
            {
                _context.Farmacos.Remove(farmaco);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FarmacoExists(int id)
        {
          return _context.Farmacos.Any(e => e.CodFar == id);
        }
    }
}
