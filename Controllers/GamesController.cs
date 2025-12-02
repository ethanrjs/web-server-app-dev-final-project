using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using web_server_app_dev_final.Data;
using web_server_app_dev_final.Models;

namespace web_server_app_dev_final.Controllers;

/// <summary>
/// controller for managing game-related pages.
/// handles displaying games from the database.
/// </summary>
public class GamesController : Controller
{
    private readonly ApplicationDbContext _context;

    public GamesController(ApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// displays all games in a table format.
    /// </summary>
    public async Task<IActionResult> Index()
    {
        var games = await _context.Games
            .OrderByDescending(g => g.Rating)
            .ToListAsync();
        return View(games);
    }

    /// <summary>
    /// displays details for a specific game.
    /// for ethan g - implement detailed game view with full review.
    /// </summary>
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var game = await _context.Games.FirstOrDefaultAsync(g => g.Id == id);
        if (game == null)
        {
            return NotFound();
        }

        return View(game);
    }
}

