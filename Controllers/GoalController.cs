using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Momentum.Models;

public class GoalController : Controller
{
    private readonly MomentumContext _context;

    public GoalController(MomentumContext context)
    {
        _context = context;
    }

    // GET: Goal
    public async Task<IActionResult> Index()
    {
        return View(await _context.Goals.ToListAsync());
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var goal = await _context.Goals
            .FirstOrDefaultAsync(m => m.GoalId == id);

        if (goal == null)
        {
            return NotFound();
        }

        return View(goal);
    }

    // GET: Goal/Create
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(
        [Bind("GoalId,Title,Description,Category,TargetDate")] Goal goal)
    {
        if (ModelState.IsValid)
        {
            _context.Add(goal);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        return View(goal);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var goal = await _context.Goals.FindAsync(id);

        if (goal == null)
        {
            return NotFound();
        }

        return View(goal);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(
        int id,
        [Bind("GoalId,Title,Description,Category,TargetDate")] Goal goal)
    {
        if (id != goal.GoalId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(goal);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GoalExists(goal.GoalId))
                {
                    return NotFound();
                }

                throw;
            }

            return RedirectToAction(nameof(Index));
        }

        return View(goal);
    }
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var goal = await _context.Goals
            .FirstOrDefaultAsync(m => m.GoalId == id);

        if (goal == null)
        {
            return NotFound();
        }

        return View(goal);
    }


    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var goal = await _context.Goals.FindAsync(id);

        if (goal != null)
        {
            _context.Goals.Remove(goal);
        }

        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    private bool GoalExists(int id)
    {
        return _context.Goals.Any(e => e.GoalId == id);
    }
}