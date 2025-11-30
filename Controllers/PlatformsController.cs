using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using web_server_app_dev_final.Data;
using web_server_app_dev_final.Models;

namespace web_server_app_dev_final.Controllers;

public class PlatformsController : Controller
{
    private readonly ApplicationDbContext _context;

    public PlatformsController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        // Better to use async here when fetching data from the database
        var platforms = await _context.Platforms.ToListAsync();
        return View(platforms);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Name,Description,ReleaseYear,Creator")] Platform platform)
    {
        if (ModelState.IsValid)
        {
            _context.Platforms.Add(platform);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(platform);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
            return NotFound();

        var platform = await _context.Platforms.FindAsync(id);
        if (platform == null)
            return NotFound();

        return View(platform);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,ReleaseYear,Creator")] Platform platform)
    {
        if (id != platform.Id)
            return NotFound();

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(platform);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlatformExists(platform.Id))
                    return NotFound();
                throw;
            }
            return RedirectToAction(nameof(Index));
        }
        return View(platform);
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
            return NotFound();

        var platform = await _context.Platforms.FirstOrDefaultAsync(m => m.Id == id);
        if (platform == null)
            return NotFound();

        return View(platform);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var platform = await _context.Platforms.FindAsync(id);
        if (platform != null)
        {
            _context.Platforms.Remove(platform);
            await _context.SaveChangesAsync();
        }
        return RedirectToAction(nameof(Index));
    }

    private bool PlatformExists(int id)
    {
        return _context.Platforms.Any(e => e.Id == id);
    }
}
