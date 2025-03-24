using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Menu.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Menu.Controllers
{
	[Route("[controller]")]
	public class LiveMenuController : Controller
	{
		private readonly ILogger<LiveMenuController> _logger;
		
		private readonly ApplicationDbContext _context;

		public LiveMenuController(
			ILogger<LiveMenuController> logger,
			ApplicationDbContext context
		)
		{
			_logger = logger;
			_context = context;
		}


		[HttpGet("Index")]
		public IActionResult Index()
		{
			var t = _context.MenuItem!
				.Include(x=>x.Category)
				.Include(c=>c.MenuItemSize).ThenInclude(c=>c.Size)
				.Include(v=>v.MenuItemIngredients).ThenInclude(l=>l.Ingredient).ToList();
			return View(t);
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View("Error!");
		}
	}
}