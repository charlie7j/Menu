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
        public IActionResult Create(
            [FromForm] int tableNumber,
            [FromForm] string customerNote,
            [FromForm] List<OrderItem> orderItems,Order order)
        {

            return RedirectToAction("Index");
        }

        // GET: Orders/Edit/5
        [HttpGet("Edit")]
        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();

            var order = _context.Order!.Find(id);
            return order == null ? NotFound() : View(order);
        }

        // POST: Orders/Edit/5
        [HttpPost("Edit")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("OrderId,TableNumber,OrderDateTime,CustomerNote")] Order order)
        {
            if (id != order.OrderId) return NotFound();

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
            }
            return RedirectToAction("Index");
        }

        // GET: Orders/Delete/5
        [HttpGet("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();

            var order = _context.Order!
                .FirstOrDefault(m => m.OrderId == id);

            return order == null ? NotFound() : View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost("Delete"), ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var order = _context.Order!.Find(id);
            _context.Order.Remove(order!);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        private bool OrderExists(int id)
        {
            return _context.Order!.Any(e => e.OrderId == id);
        }
    }
}