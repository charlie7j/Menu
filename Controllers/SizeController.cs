using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Menu.Data;
using Microsoft.EntityFrameworkCore;
using Menu.Models;

namespace Menu.Controllers
{
    [Route("[controller]")]
    public class SizeController : Controller
    {
        private readonly ILogger<SizeController> _logger;

        private readonly ApplicationDbContext _context;

        public SizeController(ApplicationDbContext context, ILogger<SizeController> logger)
        {
            _context = context;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        // عرض جميع الأحجام
        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {
            var sizes = _context.Size != null ? await _context.Size.ToListAsync() : new List<Size>();
            return View(sizes);
        }

        // عرض تفاصيل حجم معين
        [HttpGet("Details/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (_context.Size == null)
            {
                return NotFound();
            }
            var size = _context.Size != null ? await _context.Size.FirstOrDefaultAsync(m => m.SizeId == id) : null;
            if (size == null)
            {
                return NotFound();
            }

            return View(size);
        }

        // عرض نموذج إضافة حجم جديد
        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }

        // إضافة حجم جديد
        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Name")] Size size)
        {

            if (ModelState.IsValid)
            {
                _context.Add(size);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(size);
        }

        // عرض نموذج تعديل حجم معين
        [HttpGet("Edit/{id}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (_context.Size == null)
            {
                return NotFound();
            }
            var size = _context.Size != null ? await _context.Size.FindAsync(id) : null;
            if (size == null)
            {
                return NotFound();
            }
            return View(size);
        }

        // تعديل حجم معين
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name")] Size size)
        {
            if (id != size.SizeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(size);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SizeExists(size.SizeId))
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
            return View(size);
        }

        // عرض نموذج تأكيد الحذف
        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var size = _context.Size != null ? await _context.Size.FirstOrDefaultAsync(m => m.SizeId == id) : null;
            if (size == null)
            {
                return NotFound();
            }

            return View(size);
        }

        // حذف حجم معين
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var size = _context.Size != null ? await _context.Size.FindAsync(id) : null;
            if (size != null)
            {
                if (size != null)
                {
                    _context!.Size!.Remove(size);
                    await _context.SaveChangesAsync();
                }
            }
            return RedirectToAction(nameof(Index));
        }

        // التحقق من وجود حجم معين
        private bool SizeExists(int id)
        {
            return _context.Size != null && _context.Size.Any(e => e.SizeId == id);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        [HttpGet("Error")]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}