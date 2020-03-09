using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using catbug.Data;
using catbug.Models;
using Microsoft.AspNetCore.Authorization;

namespace catbug.Controllers
{
    public class EntriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EntriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Entries
        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Entries.OrderByDescending(o => o.Id).ToListAsync());
        }

        // GET: Entries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entry = await _context.Entries
                .FirstOrDefaultAsync(m => m.Id == id);
            if (entry == null)
            {
                return NotFound();
            }

            return View(entry);
        }

        // GET: Entries/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Entries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("Title,Context")] Entry entry, int[] categoriesId)
        {
            categoriesId = categoriesId.Distinct().ToArray();

            foreach (int categoryId in categoriesId)
            {
                Category category = _context.Categories.FirstOrDefault(o => o.Id == categoryId);
                if (category != null)
                {
                    _context.Add(new EntryCategory
                    {
                        Category = category,
                        Entry = entry
                    });
                }
            }

            if (ModelState.IsValid)
            {
                _context.Add(entry);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(entry);
        }

        // GET: Entries/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int id)
        {
            Entry entry = await _context.Entries.FindAsync(id);
            if (entry == null)
            {
                return NotFound();
            }
            return View(entry);
        }

        // POST: Entries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Context")] Entry entry, int[] categoriesId)
        {
            if (id != entry.Id)
            {
                return NotFound();
            }

            Entry dbEntry = _context.Entries.AsNoTracking().FirstOrDefault(o => o.Id == id);
            entry.Created = dbEntry.Created;

            List<Category> categories = await _context.Categories.ToListAsync();
            categoriesId = categoriesId.Distinct().ToArray();

            foreach (Category category in categories)
            {
                EntryCategory entryCategory = _context.EntryCategories.FirstOrDefault(o => o.CategoryId == category.Id && o.EntryId == entry.Id);
                if (categoriesId.Any(o => o == category.Id)) // Relation should be kept / created
                {
                    if (entryCategory == null) // If the relation doesn't exists, create it
                    {
                        _context.Add(new EntryCategory
                        {
                            Category = category,
                            Entry = entry
                        });
                    }
                }
                else // Relation should be removed
                {
                    if (entryCategory != null) // If the relation exists, remove it
                    {
                        _context.Remove(entryCategory);
                    }
                }
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(entry);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EntryExists(entry.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(entry);
        }

        // GET: Entries/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entry = await _context.Entries
                .FirstOrDefaultAsync(m => m.Id == id);
            if (entry == null)
            {
                return NotFound();
            }

            return View(entry);
        }

        // POST: Entries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var entry = await _context.Entries.FindAsync(id);
            _context.Entries.Remove(entry);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EntryExists(int id)
        {
            return _context.Entries.Any(e => e.Id == id);
        }
    }
}
