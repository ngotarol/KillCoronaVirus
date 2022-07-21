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
    public class TipoExamenesController : Controller
    {
        private readonly KillCoronaVirusContext _context;

        public TipoExamenesController(KillCoronaVirusContext context)
        {
            _context = context;
        }

        // GET: TipoExamenes
        public async Task<IActionResult> Index(string tipoExamen)
        {
            if (tipoExamen != null)
            {
                var tipo = await _context.TipoExamen
                    .Where(a =>
                        a.NomTipo.Contains(tipoExamen)
                        )
                    .ToListAsync();

                if (tipo == null)
                {
                    return NotFound();
                }
                return View(tipo);
            }
            else
            {
                var killCoronaVirusContext = _context.TipoExamen;
                return View(await killCoronaVirusContext.ToListAsync());
            }
        }

        // GET: TipoExamenes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TipoExamen == null)
            {
                return NotFound();
            }

            var tipoExaman = await _context.TipoExamen
                .FirstOrDefaultAsync(m => m.CodTipo == id);
            if (tipoExaman == null)
            {
                return NotFound();
            }

            return View(tipoExaman);
        }

        // GET: TipoExamenes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoExamenes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodTipo,NomTipo")] TipoExaman tipoExaman)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoExaman);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoExaman);
        }

        // GET: TipoExamenes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TipoExamen == null)
            {
                return NotFound();
            }

            var tipoExaman = await _context.TipoExamen.FindAsync(id);
            if (tipoExaman == null)
            {
                return NotFound();
            }
            return View(tipoExaman);
        }

        // POST: TipoExamenes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodTipo,NomTipo")] TipoExaman tipoExaman)
        {
            if (id != tipoExaman.CodTipo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoExaman);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoExamanExists(tipoExaman.CodTipo))
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
            return View(tipoExaman);
        }

        // GET: TipoExamenes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TipoExamen == null)
            {
                return NotFound();
            }

            var tipoExaman = await _context.TipoExamen
                .FirstOrDefaultAsync(m => m.CodTipo == id);
            if (tipoExaman == null)
            {
                return NotFound();
            }

            return View(tipoExaman);
        }

        // POST: TipoExamenes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TipoExamen == null)
            {
                return Problem("Entity set 'KillCoronaVirusContext.TipoExamen'  is null.");
            }
            var tipoExaman = await _context.TipoExamen.FindAsync(id);
            if (tipoExaman != null)
            {
                _context.TipoExamen.Remove(tipoExaman);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoExamanExists(int id)
        {
            return _context.TipoExamen.Any(e => e.CodTipo == id);
        }
    }
}
