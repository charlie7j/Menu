using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Menu.Data;
using Menu.Models;

namespace Menu.Controllers
{
    [Route("[controller]")]
    public class CategoryController : Controller
    {
        private readonly ILogger<CategoryController> _logger;

        private readonly ApplicationDbContext _context;

        public CategoryController(ILogger<CategoryController> logger,ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        // عرض جميع الفئات (Index)
        [HttpGet("Index")]
        public IActionResult Index()
        {
            var Category = _context.Category!.ToList();
            return View(Category);
        }

        // عرض نموذج الإضافة (Create - GET)
        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }

        // معالجة الإضافة (Create - POST)
        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name")] Category category)
        {
            if (ModelState.IsValid)
            {
                _context.Add(category);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        // عرض نموذج التعديل (Edit - GET)
        [HttpGet("Edit")]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = _context!.Category!.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // معالجة التعديل (Edit - POST)
        [HttpPost("Edit")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("CategoryId,Name")] Category category)
        {
            if (id != category.CategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(category);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryExists(category.CategoryId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(category);
        }

        // عرض نموذج الحذف (Delete - GET)
        [HttpGet("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = _context.Category!
                .FirstOrDefault(m => m.CategoryId == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // معالجة الحذف (Delete - POST)
        [HttpPost("Delete"), ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var category =  _context!.Category!.Find(id);
            _context.Category.Remove(category);
            _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool CategoryExists(int id)
        {
            return _context.Category!.Any(e => e.CategoryId == id);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}