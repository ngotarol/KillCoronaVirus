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
    public class PacientesController : Controller
    {
        private readonly KillCoronaVirusContext _context;

        public PacientesController(KillCoronaVirusContext context)
        {
            _context = context;
        }

        // GET: Pacientes
        public async Task<IActionResult> Index()
        {
            var killCoronaVirusContext = _context.Pacientes.Include(p => p.CodSexoNavigation);
            return View(await killCoronaVirusContext.ToListAsync());
        }

        // GET: Pacientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Pacientes == null)
            {
                return NotFound();
            }

            var paciente = await _context.Pacientes
                .Include(p => p.CodSexoNavigation)
                .FirstOrDefaultAsync(m => m.IdPac == id);
            if (paciente == null)
            {
                return NotFound();
            }

            return View(paciente);
        }

        // GET: Pacientes/Create
        public IActionResult Create()
        {
            ViewData["CodSexo"] = new SelectList(_context.Sexos, "CodSexo", "NomSexo");
            return View();
        }

        // POST: Pacientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPac,RutPac,NomPac,apPaterno,apMaterno,FecNacPac,EdadPac,CodSexo")] Paciente paciente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(paciente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CodSexo"] = new SelectList(_context.Sexos, "CodSexo", "NomSexo", paciente.CodSexo);
            return View(paciente);
        }

        // GET: Pacientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Pacientes == null)
            {
                return NotFound();
            }

            var paciente = await _context.Pacientes.FindAsync(id);
            if (paciente == null)
            {
                return NotFound();
            }
            ViewData["CodSexo"] = new SelectList(_context.Sexos, "CodSexo", "NomSexo", paciente.CodSexo);
            return View(paciente);
        }

        // POST: Pacientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPac,RutPac,NomPac,apPaterno,apMaterno,FecNacPac,EdadPac,CodSexo")] Paciente paciente)
        {
            if (id != paciente.IdPac)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(paciente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PacienteExists(paciente.IdPac))
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
            ViewData["CodSexo"] = new SelectList(_context.Sexos, "CodSexo", "NomSexo", paciente.CodSexo);
            return View(paciente);
        }

        // GET: Pacientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Pacientes == null)
            {
                return NotFound();
            }

            var paciente = await _context.Pacientes
                .Include(p => p.CodSexoNavigation)
                .FirstOrDefaultAsync(m => m.IdPac == id);
            if (paciente == null)
            {
                return NotFound();
            }

            return View(paciente);
        }

        // POST: Pacientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Pacientes == null)
            {
                return Problem("Entity set 'KillCoronaVirusContext.Pacientes'  is null.");
            }
            var paciente = await _context.Pacientes.FindAsync(id);
            if (paciente != null)
            {
                _context.Pacientes.Remove(paciente);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PacienteExists(int id)
        {
            return (_context.Pacientes?.Any(e => e.IdPac == id)).GetValueOrDefault();
        }


        [HttpGet]
        public async Task<IActionResult> buscarPaciente(string RUN,string nombrePac, string apPaterno, string apMaterno)
        {
            // funcion lambda para buscar los pacientes que coincidan con cualquiera de las opciones de busqueda
            var pacientes = await _context.Pacientes
                .Include(p => p.CodSexoNavigation)
                .Where(p => 
                p.RutPac.ToString() == RUN || 
                    (
                        p.NomPac.Contains(nombrePac)||
                        p.ApPaterno.Contains(apPaterno)||
                        p.ApMaterno.Contains(apMaterno)
                    )
                ).ToListAsync();

            if (pacientes == null)
            {
                return NotFound();
            }
            return View(pacientes);
        }
    }
}
