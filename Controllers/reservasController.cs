using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Wanderley_Flores_WF_Examen.Data;
using Wanderley_Flores_WF_Examen.Models;

namespace Wanderley_Flores_WF_Examen.Controllers
{
    public class reservasController : Controller
    {
        private readonly Wanderley_Flores_WF_ExamenContext _context;

        public reservasController(Wanderley_Flores_WF_ExamenContext context)
        {
            _context = context;
        }

        // GET: reservas
        public async Task<IActionResult> Index()
        {
              return _context.reserva != null ? 
                          View(await _context.reserva.ToListAsync()) :
                          Problem("Entity set 'Wanderley_Flores_WF_ExamenContext.reserva'  is null.");
        }

        // GET: reservas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.reserva == null)
            {
                return NotFound();
            }

            var reserva = await _context.reserva
                .FirstOrDefaultAsync(m => m.dias == id);
            if (reserva == null)
            {
                return NotFound();
            }

            return View(reserva);
        }

        // GET: reservas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: reservas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("dias,nombre,precio,apellido")] reserva reserva)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reserva);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(reserva);
        }

        // GET: reservas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.reserva == null)
            {
                return NotFound();
            }

            var reserva = await _context.reserva.FindAsync(id);
            if (reserva == null)
            {
                return NotFound();
            }
            return View(reserva);
        }

        // POST: reservas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("dias,nombre,precio,apellido")] reserva reserva)
        {
            if (id != reserva.dias)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reserva);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!reservaExists(reserva.dias))
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
            return View(reserva);
        }

        // GET: reservas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.reserva == null)
            {
                return NotFound();
            }

            var reserva = await _context.reserva
                .FirstOrDefaultAsync(m => m.dias == id);
            if (reserva == null)
            {
                return NotFound();
            }

            return View(reserva);
        }

        // POST: reservas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.reserva == null)
            {
                return Problem("Entity set 'Wanderley_Flores_WF_ExamenContext.reserva'  is null.");
            }
            var reserva = await _context.reserva.FindAsync(id);
            if (reserva != null)
            {
                _context.reserva.Remove(reserva);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool reservaExists(int id)
        {
          return (_context.reserva?.Any(e => e.dias == id)).GetValueOrDefault();
        }
    }
}
