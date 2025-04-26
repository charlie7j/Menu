using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Menu.Data;
using Menu.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;

namespace Menu.Controllers
{
	[Route("[controller]")]
	public class MenuItemController : Controller
	{
		private readonly ILogger<MenuItemController> _logger;
		private readonly ApplicationDbContext _context;

		public MenuItemController
		(
			ILogger<MenuItemController> logger,
			ApplicationDbContext context
		)
		{
			_logger = logger;
			_context = context;
		}
		[HttpGet("Index")]
		public IActionResult Index()
		{

			return View();
		}

		// GET: MenuItem/Create
		[HttpGet]
		public IActionResult Create()
		{
			ViewBag.Category = new SelectList(_context.Category, "CategoryId", "Name");

			ViewBag.sizes = _context.Size!.ToList();

			ViewBag.Ingredient = _context.Ingredient!.ToList();

			return View();
		}

		// استقبال البيانات من الفورم وإضافتها إلى قاعدة البيانات
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(MenuItem menuItem, IFormFile imageFile)
		{
			// إعادة تحميل القوائم في حالة وجود أخطاء في النموذج
			ViewBag.Category = new SelectList(_context.Category, "CategoryId", "Name");
			ViewBag.sizes = _context.Size!.ToList();
			ViewBag.Ingredient = _context.Ingredient!.ToList();

			// رفع الصورة إذا تم اختيار ملف
			if (imageFile != null && imageFile.Length > 0)
			{
				// إنشاء مسار لحفظ الصورة
				var uploadsFolder = Path.Combine("wwwroot", "images", "menuItems");
				if (!Directory.Exists(uploadsFolder))
				{
					Directory.CreateDirectory(uploadsFolder);
				}

				// إنشاء اسم فريد للملف
				var uniqueFileName = Guid.NewGuid().ToString() + "_" + imageFile.FileName;
				var filePath = Path.Combine(uploadsFolder, uniqueFileName);

				// حفظ الملف
				using (var fileStream = new FileStream(filePath, FileMode.Create))
				{
					imageFile.CopyTo(fileStream);
				}

				// تعيين رابط الصورة في النموذج
				menuItem.ImageUrl = "/images/menuItems/" + uniqueFileName;
			}

			/*menuItem.SelectedSize.ToList().ForEach(e =>
			{
				if (e.SizeId > 0)
				{
					menuItem.MenuItemSize.Add(
						new MenuItemSize
						{
							PriceAdjustment = e.ExtraPrice,
							SizeId = e.SizeId
						});
				}
			});*/

			List<MenuItemSize> tempMIS = new  List<MenuItemSize>();

			foreach (var e in menuItem.SelectedSize)
			{
				if (e.SizeId != null)
				{
					tempMIS.Add(
						new MenuItemSize
						{
							PriceAdjustment = e.ExtraPrice,
							SizeId = e.SizeId,
						});
				}
				else
				{
					Console.WriteLine("Warning: Encountered a null Size object.");
				}
			}

			menuItem.MenuItemSize  = tempMIS;



			menuItem.SelectedIngredients.ToList().ForEach(e =>
			{
				if (e.IngredientId > 0)
				{
					menuItem.MenuItemIngredients.Add(
						new MenuItemIngredient
						{
							IngredientId = e.IngredientId,
							ExtraPrice = e.ExtraPrice,
							AdditionalStatus = e.AdditionalStatus,
							PrimaryStatus = e.PrimaryStatus,
							SubStatus = e.SubStatus,

						}
					);
				}
			});



			_context!.MenuItem!.Add(menuItem);
			_context.SaveChanges();

			return View();

		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View("Error!");
		}
	}
}