using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using web_server_app_dev_final.Data;
using web_server_app_dev_final.Models;

namespace web_server_app_dev_final.Controllers;

/// <summary>
/// main controller for home and information.
/// </summary>
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _context;

    public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    /// <summary>
    /// Home page - displays featured game and recent reviews.
    /// </summary>
    public async Task<IActionResult> Index()
    {
        var games = await _context.Games
            .OrderByDescending(g => g.Rating)
            .ToListAsync();

        var featuredGame = games.FirstOrDefault(g => g.IsFeatured) ?? games.FirstOrDefault();
        
        ViewBag.FeaturedGame = featuredGame;
        ViewBag.TotalGames = games.Count;
        ViewBag.TotalHours = "1,200+";
        ViewBag.ReviewerCount = games.Select(g => g.Reviewer).Distinct().Count();

        return View(games.Where(g => !g.IsFeatured).ToList());
    }

    /// <summary>
    /// why we love games
    /// </summary>
    public IActionResult About()
    {
        return View();
    }

    /// <summary>
    /// about us
    /// </summary>
    public IActionResult Team()
    {
        return View();
    }

    /// <summary>
    /// Ethan R
    /// </summary>
    public IActionResult EthanR()
    {
        return View();
    }

    /// <summary>
    /// Ella S
    /// </summary>
    public IActionResult EllaS()
    {
        return View();
    }

    /// <summary>
    /// Ethan G
    /// </summary>
    public IActionResult EthanG()
    {
        return View();
    }

    /// <summary>
    /// Collections page
    /// </summary>
    public IActionResult Collections()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
