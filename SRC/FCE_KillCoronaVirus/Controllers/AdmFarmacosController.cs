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
    public class AdmFarmacosController : Controller
    {
        private readonly KillCoronaVirusContext _context;

        public AdmFarmacosController(KillCoronaVirusContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(string NomFar, double Concentracion, int UOM, int NomPresentacion)
        {
            if (NomFar != null || Concentracion != 0 || UOM != 0 || NomPresentacion != 0)
            {
                var farmacos = await _context.Farmacos
                    .Include(m => m.CodPresentacionNavigation)
                    .Include(m => m.CodUomNavigation)
                    .Where(m =>
                        m.NomFar.Contains(NomFar) ||
                        m.Concentracion == Concentracion ||
                        m.CodPresentacion == NomPresentacion ||
                        m.CodUom == UOM)
                    .ToListAsync();
                return View(farmacos);
            }
            else
            {
                var farmacos = await _context.Farmacos
                     .Include(m => m.CodPresentacionNavigation)
                     .Include(m => m.CodUomNavigation)
                     .ToListAsync();
                return View(farmacos);
            }

        }

    }
}
