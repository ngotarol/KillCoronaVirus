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
    public class UnidadDeMedidumsController : Controller
    {
        private readonly KillCoronaVirusContext _context;

        public UnidadDeMedidumsController(KillCoronaVirusContext context)
        {
            _context = context;
        }

        // GET: UnidadDeMedidums
        public async Task<IActionResult> Index(string NombreUom, string unidadUom)
        {
            if (NombreUom != null || unidadUom != null)
            {
                var uoms = await _context.UnidadDeMedida
                    .Where(u => u.NomUom.Contains(NombreUom) ||
                    u.Uom.Contains(unidadUom)
                    )
                    .ToListAsync();

                if (uoms == null)
                {
                    return NotFound();
                }
                return View(uoms);
            }
            else
            {
                var killCoronaVirusContext = _context.UnidadDeMedida;
                return View(await killCoronaVirusContext.ToListAsync());
            }
            
        }

        // GET: UnidadDeMedidums/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.UnidadDeMedida == null)
            {
                return NotFound();
            }

            var unidadDeMedidum = await _context.UnidadDeMedida
                .FirstOrDefaultAsync(m => m.CodUom == id);
            if (unidadDeMedidum == null)
            {
                return NotFound();
            }

            return View(unidadDeMedidum);
        }

        // GET: UnidadDeMedidums/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UnidadDeMedidums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodUom,NomUom,Uom")] UnidadDeMedidum unidadDeMedidum)
        {
            if (ModelState.IsValid)
            {
                _context.Add(unidadDeMedidum);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(unidadDeMedidum);
        }

        // GET: UnidadDeMedidums/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.UnidadDeMedida == null)
            {
                return NotFound();
            }

            var unidadDeMedidum = await _context.UnidadDeMedida.FindAsync(id);
            if (unidadDeMedidum == null)
            {
                return NotFound();
            }
            return View(unidadDeMedidum);
        }

        // POST: UnidadDeMedidums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodUom,NomUom,Uom")] UnidadDeMedidum unidadDeMedidum)
        {
            if (id != unidadDeMedidum.CodUom)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(unidadDeMedidum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UnidadDeMedidumExists(unidadDeMedidum.CodUom))
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
            return View(unidadDeMedidum);
        }

        // GET: UnidadDeMedidums/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.UnidadDeMedida == null)
            {
                return NotFound();
            }

            var unidadDeMedidum = await _context.UnidadDeMedida
                .FirstOrDefaultAsync(m => m.CodUom == id);
            if (unidadDeMedidum == null)
            {
                return NotFound();
            }

            return View(unidadDeMedidum);
        }

        // POST: UnidadDeMedidums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.UnidadDeMedida == null)
            {
                return Problem("Entity set 'KillCoronaVirusContext.UnidadDeMedida'  is null.");
            }
            var unidadDeMedidum = await _context.UnidadDeMedida.FindAsync(id);
            if (unidadDeMedidum != null)
            {
                _context.UnidadDeMedida.Remove(unidadDeMedidum);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UnidadDeMedidumExists(int id)
        {
            return _context.UnidadDeMedida.Any(e => e.CodUom == id);
        }
    }
}
