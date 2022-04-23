using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StefanStores.Data;
using StefanStores.Models;

namespace StefanStores.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            //var data = _context.ProductTypes.ToList();
            return View(_context.ProductTypes.ToList());
        }

        //GET Create Action Method

        public IActionResult Create()
        {
            return View();
        }

        //POST Create Action Method

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductTypes productTypes)
        {
            if (ModelState.IsValid)
            {
                _context.ProductTypes.Add(productTypes);
                await _context.SaveChangesAsync();
                //TempData["save"] = "Product type saved";
                return RedirectToAction(nameof(Index));
            }
            return View(productTypes);
        }

    }
}