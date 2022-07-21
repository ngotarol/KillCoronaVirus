﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FCE_KillCoronaVirus.Models;

namespace FCE_KillCoronaVirus.Controllers
{
    public class EspecialidadesController : Controller
    {
        private readonly KillCoronaVirusContext _context;

        public EspecialidadesController(KillCoronaVirusContext context)
        {
            _context = context;
        }

        // GET: Especialidades
        public async Task<IActionResult> Index()
        {
              return View(await _context.Especilidads.ToListAsync());
        }

        // GET: Especialidades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Especilidads == null)
            {
                return NotFound();
            }

            var especialidad = await _context.Especilidads
                .FirstOrDefaultAsync(m => m.CodEsp == id);
            if (especialidad == null)
            {
                return NotFound();
            }

            return View(especialidad);
        }

        // GET: Especialidades/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Especialidades/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodEsp,NomEsp")] Especialidad especialidad)
        {
            if (ModelState.IsValid)
            {
                _context.Add(especialidad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(especialidad);
        }

        // GET: Especialidades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Especilidads == null)
            {
                return NotFound();
            }

            var especialidad = await _context.Especilidads.FindAsync(id);
            if (especialidad == null)
            {
                return NotFound();
            }
            return View(especialidad);
        }

        // POST: Especialidades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodEsp,NomEsp")] Especialidad especialidad)
        {
            if (id != especialidad.CodEsp)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(especialidad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EspecialidadExists(especialidad.CodEsp))
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
            return View(especialidad);
        }

        // GET: Especialidades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Especilidads == null)
            {
                return NotFound();
            }

            var especialidad = await _context.Especilidads
                .FirstOrDefaultAsync(m => m.CodEsp == id);
            if (especialidad == null)
            {
                return NotFound();
            }

            return View(especialidad);
        }

        // POST: Especialidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Especilidads == null)
            {
                return Problem("Entity set 'KillCoronaVirusContext.Especilidads'  is null.");
            }
            var especialidad = await _context.Especilidads.FindAsync(id);
            if (especialidad != null)
            {
                _context.Especilidads.Remove(especialidad);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EspecialidadExists(int id)
        {
          return _context.Especilidads.Any(e => e.CodEsp == id);
        }
    }
}
