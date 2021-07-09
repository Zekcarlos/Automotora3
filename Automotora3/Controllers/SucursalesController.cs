using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Automotora3.Data;
using Automotora3.Models;

namespace Automotora3.Controllers
{
    public class SucursalesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SucursalesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Sucursales
        public async Task<IActionResult> Index()
        {
            return View(await _context.Sucursales.ToListAsync());
        }
        public async Task<IActionResult> Index1()
        {
            return View(await _context.Sucursales.ToListAsync());
        }
        // GET: Sucursales/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sucursales = await _context.Sucursales
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sucursales == null)
            {
                return NotFound();
            }

            return View(sucursales);
        }

        // GET: Sucursales/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sucursales/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Pais,Ciudad,Dueño,Telefono")] Sucursales sucursales)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sucursales);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sucursales);
        }

        // GET: Sucursales/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sucursales = await _context.Sucursales.FindAsync(id);
            if (sucursales == null)
            {
                return NotFound();
            }
            return View(sucursales);
        }

        // POST: Sucursales/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Pais,Ciudad,Dueño,Telefono")] Sucursales sucursales)
        {
            if (id != sucursales.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sucursales);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SucursalesExists(sucursales.Id))
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
            return View(sucursales);
        }

        // GET: Sucursales/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sucursales = await _context.Sucursales
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sucursales == null)
            {
                return NotFound();
            }

            return View(sucursales);
        }

        // POST: Sucursales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sucursales = await _context.Sucursales.FindAsync(id);
            _context.Sucursales.Remove(sucursales);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SucursalesExists(int id)
        {
            return _context.Sucursales.Any(e => e.Id == id);
        }
    }
}
