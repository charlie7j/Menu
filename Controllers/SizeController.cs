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
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (_context.Size == null)
            {
                return NotFound();
            }
            else
            {
                var size = _context.Size.Find(id);

                return View(size);
            }

        }

        // تعديل حجم معين
        [HttpPost("Edit/{id}")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("SizeId,Name")] Size size)
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
                    _context.SaveChanges();
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
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var size = _context.Size != null ?  _context.Size.FirstOrDefault(m => m.SizeId == id) : null;
            if (size == null)
            {
                return NotFound();
            }

            return View(size);
        }

        // حذف حجم معين
        [HttpPost("Delete/{id}"), ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var size = _context.Size != null ?  _context.Size.Find(id) : null;
            if (size != null)
            {
                if (size != null)
                {
                    _context!.Size!.Remove(size);
                    _context.SaveChanges();
                }
            }
            return RedirectToAction("Index");
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