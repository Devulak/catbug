using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using catbug.Data;
using catbug.Models;

namespace catbug.Controllers
{
    public class LearningObjectivesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LearningObjectivesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: LearningObjectives
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.LearningObjectives.Include(l => l.LearningCycle);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: LearningObjectives/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var learningObjective = await _context.LearningObjectives
                .Include(l => l.LearningCycle)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (learningObjective == null)
            {
                return NotFound();
            }

            return View(learningObjective);
        }

        // GET: LearningObjectives/Create
        public IActionResult Create()
        {
            ViewData["LearningCycleId"] = new SelectList(_context.LearningCycles, "Id", "Id");
            return View();
        }

        // POST: LearningObjectives/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Goal,Techniques,Criteria,Completed,Evaulation,LearningCycleId")] LearningObjective learningObjective)
        {
            if (ModelState.IsValid)
            {
                _context.Add(learningObjective);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LearningCycleId"] = new SelectList(_context.LearningCycles, "Id", "Id", learningObjective.LearningCycleId);
            return View(learningObjective);
        }

        // GET: LearningObjectives/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var learningObjective = await _context.LearningObjectives.FindAsync(id);
            if (learningObjective == null)
            {
                return NotFound();
            }
            ViewData["LearningCycleId"] = new SelectList(_context.LearningCycles, "Id", "Id", learningObjective.LearningCycleId);
            return View(learningObjective);
        }

        // POST: LearningObjectives/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Goal,Techniques,Criteria,Completed,Evaulation,LearningCycleId")] LearningObjective learningObjective)
        {
            if (id != learningObjective.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(learningObjective);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LearningObjectiveExists(learningObjective.Id))
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
            ViewData["LearningCycleId"] = new SelectList(_context.LearningCycles, "Id", "Id", learningObjective.LearningCycleId);
            return View(learningObjective);
        }

        // GET: LearningObjectives/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var learningObjective = await _context.LearningObjectives
                .Include(l => l.LearningCycle)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (learningObjective == null)
            {
                return NotFound();
            }

            return View(learningObjective);
        }

        // POST: LearningObjectives/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var learningObjective = await _context.LearningObjectives.FindAsync(id);
            _context.LearningObjectives.Remove(learningObjective);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LearningObjectiveExists(int id)
        {
            return _context.LearningObjectives.Any(e => e.Id == id);
        }
    }
}
