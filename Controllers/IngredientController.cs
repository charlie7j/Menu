using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Menu.Data;
using Menu.Models;
using Microsoft.EntityFrameworkCore;


namespace Menu.Controllers
{
    [Route("[controller]")]
    public class IngredientController : Controller
    {
        private readonly ILogger<IngredientController> _logger;


        private readonly ApplicationDbContext _context;

        public IngredientController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Ingredient
        public IActionResult Index(string searchString)
        {
            var Ingredient = from i in _context.Ingredient select i;

            if (!string.IsNullOrEmpty(searchString))
            {
                Ingredient = Ingredient.Where(i => i.Name.Contains(searchString));
            }

            return View( Ingredient.ToList());
        }

        // GET: Ingredient/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ingredient/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("IngredientId,Name,ExtraPrice,PrimaryStatus,SubStatus,AdditionalStatus")] Ingredient ingredient)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ingredient);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ingredient);
        }

        // GET: Ingredient/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var ingredient = await _context.Ingredient.FindAsync(id);
            if (ingredient == null) return NotFound();

            return View(ingredient);
        }

        // POST: Ingredient/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IngredientId,Name,ExtraPrice,PrimaryStatus,SubStatus,AdditionalStatus")] Ingredient ingredient)
        {
            if (id != ingredient.IngredientId) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ingredient);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IngredientExists(ingredient.IngredientId)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(ingredient);
        }

        // GET: Ingredient/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();

            var ingredient =  _context.Ingredient
                .FirstOrDefault(m => m.IngredientId == id);
            if (ingredient == null) return NotFound();

            return View(ingredient);
        }

        // POST: Ingredient/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ingredient = await _context.Ingredient.FindAsync(id);
            _context.Ingredient.Remove(ingredient);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IngredientExists(int id)
        {
            return _context.Ingredient.Any(e => e.IngredientId == id);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}