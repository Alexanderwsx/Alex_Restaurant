using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Alex_Restaurant.Data;
using Alex_Restaurant.Models;

namespace Alex_Restaurant.Controllers
{
    public class TypeMealsController : Controller
    {
        private readonly Alex_RestaurantContext _context;

        public TypeMealsController(Alex_RestaurantContext context)
        {
            _context = context;
        }

        // GET: TypeMeals
        public async Task<IActionResult> Index()
        {
              return _context.TypeMeal != null ? 
                          View(await _context.TypeMeal.ToListAsync()) :
                          Problem("Entity set 'Alex_RestaurantContext.TypeMeal'  is null.");
        }

        // GET: TypeMeals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TypeMeal == null)
            {
                return NotFound();
            }

            var typeMeal = await _context.TypeMeal
                .FirstOrDefaultAsync(m => m.Id == id);
            if (typeMeal == null)
            {
                return NotFound();
            }

            return View(typeMeal);
        }

        // GET: TypeMeals/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TypeMeals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description")] TypeMeal typeMeal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(typeMeal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(typeMeal);
        }

        // GET: TypeMeals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TypeMeal == null)
            {
                return NotFound();
            }

            var typeMeal = await _context.TypeMeal.FindAsync(id);
            if (typeMeal == null)
            {
                return NotFound();
            }
            return View(typeMeal);
        }

        // POST: TypeMeals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description")] TypeMeal typeMeal)
        {
            if (id != typeMeal.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(typeMeal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TypeMealExists(typeMeal.Id))
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
            return View(typeMeal);
        }

        // GET: TypeMeals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TypeMeal == null)
            {
                return NotFound();
            }

            var typeMeal = await _context.TypeMeal
                .FirstOrDefaultAsync(m => m.Id == id);
            if (typeMeal == null)
            {
                return NotFound();
            }

            return View(typeMeal);
        }

        // POST: TypeMeals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TypeMeal == null)
            {
                return Problem("Entity set 'Alex_RestaurantContext.TypeMeal'  is null.");
            }
            var typeMeal = await _context.TypeMeal.FindAsync(id);
            if (typeMeal != null)
            {
                _context.TypeMeal.Remove(typeMeal);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TypeMealExists(int id)
        {
          return (_context.TypeMeal?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
