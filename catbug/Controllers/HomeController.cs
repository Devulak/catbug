using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using catbug.Models;
using catbug.Data;
using Microsoft.EntityFrameworkCore;

namespace catbug.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> IndexAsync(List<int> categoryIds)
        {
            categoryIds = categoryIds.Distinct().ToList();

            IQueryable<Entry> entries = _context.Entries;

            foreach (Category category in await _context.Categories.ToListAsync())
            {
                if (!categoryIds.Any(o => o == category.Id)) // Does the list have any actual categories?
                {
                    categoryIds.RemoveAll(o => o == category.Id);
                }
            }

            if (categoryIds.Count() != 0)
            {
                entries = entries.Where(o => o.EntryCategories.Any(p => categoryIds.Contains(p.CategoryId)));
            }

            entries = entries.OrderByDescending(o => o.Id);

            ViewBag.categoryIds = categoryIds;

            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                return PartialView("_portfolioPartialView", await entries.ToListAsync());
            }

            return View(await entries.ToListAsync());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
