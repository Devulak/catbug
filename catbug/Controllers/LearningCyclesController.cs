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
    public class LearningCyclesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LearningCyclesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize]
        // GET: LearningCycles
        public async Task<IActionResult> Index()
        {
            return View(await _context.LearningCycles.ToListAsync());
        }

        [Authorize]
        // GET: LearningCycles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var learningCycle = await _context.LearningCycles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (learningCycle == null)
            {
                return NotFound();
            }

            return View(learningCycle);
        }

        public async Task<IActionResult> List()
        {
            return View(await _context.LearningCycles.OrderByDescending(o => o.Id).ToListAsync());
        }

        [Authorize]
        // GET: LearningCycles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LearningCycles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StartDate")] LearningCycle learningCycle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(learningCycle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(learningCycle);
        }

        // GET: LearningCycles/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var learningCycle = await _context.LearningCycles.FindAsync(id);
            if (learningCycle == null)
            {
                return NotFound();
            }
            return View(learningCycle);
        }

        // POST: LearningCycles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StartDate")] LearningCycle learningCycle)
        {
            if (id != learningCycle.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(learningCycle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LearningCycleExists(learningCycle.Id))
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
            return View(learningCycle);
        }

        // GET: LearningCycles/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var learningCycle = await _context.LearningCycles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (learningCycle == null)
            {
                return NotFound();
            }

            return View(learningCycle);
        }

        // POST: LearningCycles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var learningCycle = await _context.LearningCycles.FindAsync(id);
            _context.LearningCycles.Remove(learningCycle);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LearningCycleExists(int id)
        {
            return _context.LearningCycles.Any(e => e.Id == id);
        }
    }
}
