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
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Menu.Controllers
{
    [Route("[controller]")]
    public class OrdersController : Controller
    {
        private readonly ILogger<OrdersController> _logger;

        private readonly ApplicationDbContext _context;

        public OrdersController(ILogger<OrdersController> logger, ApplicationDbContext context)
        {
            _context = context;
            _logger = logger;
        }

        // GET: Orders
        [HttpGet("Index")]
        public IActionResult Index()
        {
            return View(_context.Order!
                .Include(o => o.OrderItems)
                .ToList());
        }

        // GET: Orders/Details/5
        [HttpGet("Details")]
        public IActionResult Details(int? id)
        {
            if (id == null) return NotFound();

            var order = _context.Order!
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.MenuItem)
                .FirstOrDefault(m => m.OrderId == id);

            return order == null ? NotFound() : View(order);
        }

        // GET: Orders/Create
        [HttpGet("Create")]
        public IActionResult Create()
        {
            var menu = _context.MenuItem!
                .Include(x => x.Category)
                .Include(c => c.MenuItemSize).ThenInclude(c => c.Size)
                .Include(v => v.MenuItemIngredients).ThenInclude(l => l.Ingredient).ToList();

            ViewBag.MenuItems = menu;

            return View(menu);
        }

        // POST: Orders/Create
        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Order order)
        {

            if (ModelState.IsValid)
            {

                // 1. اجمع كل الـ AddOnIngredientId المطلوبة
                var addOnIds = order.OrderItems
                    .SelectMany(x => x.AddedAddOns!)
                    .Select(xx => xx.AddOnIngredientId)
                    .ToList();

                var ingredients = _context.MenuItemIngredient!
                    .Where(a => addOnIds.Contains(a.IngredientId))
                    .ToDictionary(a => a.IngredientId, a => a.ExtraPrice);

                var sizeIds = order.OrderItems
                    .Select(x => x.SelectedSize!.SizeId)
                    .ToList();

                var sizes = _context.MenuItemSize!
                    .Where(s => sizeIds.Contains(s.SizeId))
                    .ToList() // ⭐ ننفذ الاستعلام أولاً
                    .GroupBy(s => s.SizeId)
                    .ToDictionary(g => g.Key, g => g.First().PriceAdjustment);

                // 3. حساب السعر الإجمالي
                decimal tempPrice = 0;
                foreach (var item in order.OrderItems)
                {
                    decimal itemTotal = 0; 

                    foreach (var addOn in item.AddedAddOns!)
                    {
                        if (ingredients.TryGetValue(addOn.AddOnIngredientId, out var price))
                        {
                            itemTotal += price;
                        }
                    }

                    if (sizes.TryGetValue(item.SelectedSize!.SizeId, out var adjustment))
                    {
                        itemTotal += adjustment;
                    }

                    // ضرب الكل في كمية الطلب
                    tempPrice += itemTotal * item.Quantity;
                }

     
                order.FullPrice = (double)tempPrice;

                _context.Add(order);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        // GET: Orders/Edit/5
        [HttpGet("Edit/{id}")]
        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();

            var order = _context.Order!
                .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.AddedAddOns)!
                        .ThenInclude(oi => oi.AddOnIngredient)
                .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.MenuItem)
                        .ThenInclude(oi => oi!.Category)
                .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.RemovedAddOns)
                .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.SelectedSize)
                        .ThenInclude(oi=>oi!.Size)      
                .SingleOrDefault(o => o.OrderId == id);

            
            
            ViewBag.Ingredient = _context.MenuItemIngredient!
                .Include(mi=>mi.Ingredient);

           /* ViewBag.Sizes = _context.MenuItemSize!
                .Include(ms=>ms.Size).ToList();*/

            ViewBag.Sizes = _context.MenuItemSize!
            .Include(ms => ms.Size)
            .Select(ms => ms.Size) // إذا كنت تريد الخصائص من جدول Size فقط
            .ToList();
            
  
            return View(order);
        } 

        // POST: Orders/Edit/5
        [HttpPost("Edit/{id}")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id,  Order order)
        {
            /*if (id != order.OrderId) return NotFound();

            if (!ModelState.IsValid) return View(order);

            try
            {
                _context.Update(order);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(order.OrderId)) return NotFound();
                throw;
            }*/
            return RedirectToAction("Index");
        }

        // GET: Orders/Delete/5
        [HttpGet("Delete/{id}")]
        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();

            var order = _context.Order!
                .FirstOrDefault(m => m.OrderId == id);

            return order == null ? NotFound() : View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost("Delete/{id}"), ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var order = _context.Order!
            .Include(o => o.OrderItems)
                .SingleOrDefault(o => o.OrderId == id);

            _context.Order!.Remove(order!);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        private bool OrderExists(int id)
        {
            return _context.Order!.Any(e => e.OrderId == id);
        }
    }
}