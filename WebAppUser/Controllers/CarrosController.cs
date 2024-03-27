using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAppUser.Data;
using WebAppUser.Models;

namespace WebAppUser.Controllers
{
    public class CarrosController : Controller
    {
        private readonly WebAppUserContext _context;

        public CarrosController(WebAppUserContext context)
        {
            _context = context;
        }

        // GET: Carros
        public async Task<IActionResult> Index()
        {
              return _context.CarrosModel != null ? 
                          View(await _context.CarrosModel.ToListAsync()) :
                          Problem("Entity set 'WebAppUserContext.CarrosModel'  is null.");
        }

        // GET: Carros/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CarrosModel == null)
            {
                return NotFound();
            }

            var carrosModel = await _context.CarrosModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carrosModel == null)
            {
                return NotFound();
            }

            return View(carrosModel);
        }

        // GET: Carros/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Carros/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Marca,Modelo,DataFabricacao")] CarrosModel carrosModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carrosModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(carrosModel);
        }

        // GET: Carros/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CarrosModel == null)
            {
                return NotFound();
            }

            var carrosModel = await _context.CarrosModel.FindAsync(id);
            if (carrosModel == null)
            {
                return NotFound();
            }
            return View(carrosModel);
        }

        // POST: Carros/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Marca,Modelo,DataFabricacao")] CarrosModel carrosModel)
        {
            if (id != carrosModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carrosModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarrosModelExists(carrosModel.Id))
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
            return View(carrosModel);
        }

        // GET: Carros/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CarrosModel == null)
            {
                return NotFound();
            }

            var carrosModel = await _context.CarrosModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carrosModel == null)
            {
                return NotFound();
            }

            return View(carrosModel);
        }

        // POST: Carros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CarrosModel == null)
            {
                return Problem("Entity set 'WebAppUserContext.CarrosModel'  is null.");
            }
            var carrosModel = await _context.CarrosModel.FindAsync(id);
            if (carrosModel != null)
            {
                _context.CarrosModel.Remove(carrosModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarrosModelExists(int id)
        {
          return (_context.CarrosModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
