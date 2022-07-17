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
    public class AtencionsController : Controller
    {
        private readonly KillCoronaVirusContext _context;

        public AtencionsController(KillCoronaVirusContext context)
        {
            _context = context;
        }

        // GET: Atencions
        public async Task<IActionResult> Index()
        {
            var killCoronaVirusContext = _context.Atencions.Include(a => a.IdPacNavigation).Include(a => a.IdUsuarioNavigation);
            return View(await killCoronaVirusContext.ToListAsync());
        }

        // GET: Atencions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Atencions == null)
            {
                return NotFound();
            }

            var atencion = await _context.Atencions
                .Include(a => a.IdPacNavigation)
                .Include(a => a.IdUsuarioNavigation)
                .FirstOrDefaultAsync(m => m.NroAtencion == id);
            if (atencion == null)
            {
                return NotFound();
            }

            return View(atencion);
        }

        // GET: Atencions/Create
        public IActionResult Create(int id)
        {


            Paciente objPaciente = _context.Pacientes.Where(pac => pac.IdPac == id).FirstOrDefault();

            Atencion objAtencion = new Atencion
            {
                IdPac = objPaciente.IdPac,
                IdUsuario = "" //TODO: actualizar este dato
            };
            return View(objAtencion);
        }

        // POST: Atencions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NroAtencion,DatAtencion,IdPac,IdUsuario,FechaHora")] Atencion atencion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(atencion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdPac"] = new SelectList(_context.Pacientes, "IdPac", "IdPac", atencion.IdPac);
            return View(atencion);
        }

        // GET: Atencions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Atencions == null)
            {
                return NotFound();
            }

            var atencion = await _context.Atencions.FindAsync(id);
            if (atencion == null)
            {
                return NotFound();
            }
            ViewData["IdPac"] = new SelectList(_context.Pacientes, "IdPac", "IdPac", atencion.IdPac);
            return View(atencion);
        }

        // POST: Atencions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NroAtencion,DatAtencion,IdPac,IdUsuario,FechaHora")] Atencion atencion)
        {
            if (id != atencion.NroAtencion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(atencion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AtencionExists(atencion.NroAtencion))
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
            ViewData["IdPac"] = new SelectList(_context.Pacientes, "IdPac", "IdPac", atencion.IdPac);
            return View(atencion);
        }

        // GET: Atencions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Atencions == null)
            {
                return NotFound();
            }

            var atencion = await _context.Atencions
                .Include(a => a.IdPacNavigation)
                .Include(a => a.IdUsuarioNavigation)
                .FirstOrDefaultAsync(m => m.NroAtencion == id);
            if (atencion == null)
            {
                return NotFound();
            }

            return View(atencion);
        }

        // POST: Atencions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Atencions == null)
            {
                return Problem("Entity set 'KillCoronaVirusContext.Atencions'  is null.");
            }
            var atencion = await _context.Atencions.FindAsync(id);
            if (atencion != null)
            {
                _context.Atencions.Remove(atencion);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AtencionExists(int id)
        {
            return (_context.Atencions?.Any(e => e.NroAtencion == id)).GetValueOrDefault();
        }
    }
}
