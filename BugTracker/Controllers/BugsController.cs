using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BugTracker.Data;
using BugTracker.Models;
using Microsoft.AspNetCore.Authorization;
using BugTracker.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace BugTracker.Controllers;

[Authorize]
public class BugsController : Controller
{
    private readonly BugTrackerContext _context;
    private readonly UserManager<User> _userManager;
    private readonly ILogger<BugsController> _logger;

    public BugsController(BugTrackerContext context, UserManager<User> userManager, ILogger<BugsController> logger)
    {
        _context = context;
        _userManager = userManager;
        _logger = logger;
    }

    // GET: Bugs
    public async Task<IActionResult> Index()
    {
        return View(await _context.Bugs
            .Include(i => i.Assignee)
            .Include(i => i.Reporter)
            .ToListAsync());
    }

    // GET: Bugs/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id is null || _context.Bugs is null)
        {
            return NotFound();
        }

        var bug = await _context.Bugs.FirstOrDefaultAsync(m => m.Id == id);

        return bug is null ? NotFound() : View(bug);
    }

    // GET: Bugs/Create
    [HttpGet]
    public async Task<IActionResult> Create()
    {
        var users = await _context.Users.ToListAsync();
        var viewModel = new BugCreationViewModel { UsersToAssign = users };
        return View(viewModel);
    }

    // POST: Bugs/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([FromForm] BugCreationViewModel bugViewModel)
    {
        var selectedUser = _context.Users.FirstOrDefault(x => x.Id == bugViewModel.Bug.Assignee.Id);
        var currentUser = await _userManager.GetUserAsync(HttpContext.User);
        
        ModelState.Remove("Bug.Assignee");
        ModelState.Remove("Bug.Reporter");
        ModelState.Remove("UsersToAssign");

        if (ModelState.IsValid && currentUser is not null && selectedUser is not null)
        {
            bugViewModel.Bug.Reporter = currentUser;
            bugViewModel.Bug.Assignee = selectedUser;
            _context.Add(bugViewModel.Bug);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        bugViewModel.UsersToAssign = await _context.Users.ToListAsync();
        return View(bugViewModel);
    }

    // GET: Bugs/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id is null || _context.Bugs is null)
        {
            return NotFound();
        }

        var bug = await _context.Bugs.FindAsync(id);

        return bug is null ? NotFound() : View(bug);
    }

    // POST: Bugs/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [FromForm] Bug bug)
    {
        if (id != bug.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(bug);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BugExists(bug.Id))
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
        return View(bug);
    }

    // GET: Bugs/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id is null || _context.Bugs is null) return NotFound();

        var bug = await _context.Bugs.FirstOrDefaultAsync(m => m.Id == id);

        return bug is null ? NotFound() : View(bug);
    }

    // POST: Bugs/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        if (_context.Bugs is null) return Problem("Entity set 'BugTrackerContext.Bugs'  is null.");

        var bug = await _context.Bugs.FindAsync(id);

        if (bug is not null) _context.Bugs.Remove(bug);

        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    private bool BugExists(int id) => _context.Bugs.Any(e => e.Id == id);
}
