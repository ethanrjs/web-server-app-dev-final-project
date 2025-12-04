using System.ComponentModel.DataAnnotations;

namespace web_server_app_dev_final.Models;

/// <summary>
/// represents a game in the library with its review information.
/// </summary>
public class Game
{
    public int Id { get; set; }

    [Required]
    [StringLength(200)]
    public string Title { get; set; } = string.Empty;

    [StringLength(100)]
    public string Developer { get; set; } = string.Empty;

    public int? ReleaseYear { get; set; }

    /// <summary>
    /// comma-separated list of platforms (e.g., "PC,PS5,NSW")
    /// NSW meaning nintendo switch btw
    /// </summary>
    [StringLength(100)]
    public string Platforms { get; set; } = string.Empty;

    /// <summary>
    /// comma-separated list of genres (e.g., "Action RPG,Open World")
    /// write whatever here
    /// </summary>
    [StringLength(200)]
    public string Genres { get; set; } = string.Empty;

    /// <summary>
    /// Rating score out of 10 (e.g., 9.5)
    /// </summary>
    public decimal Rating { get; set; }

    /// <summary>
    /// URL to the game's cover image
    /// </summary>
    [StringLength(2048)]
    public string CoverImageUrl { get; set; } = string.Empty;

    /// <summary>
    /// the review text/summary for the game
    /// </summary>
    [StringLength(1000)]
    public string ReviewText { get; set; } = string.Empty;

    /// <summary>
    /// name of the reviewer
    /// </summary>
    [StringLength(100)]
    public string Reviewer { get; set; } = string.Empty;

    /// <summary>
    /// Date when the review was published
    /// </summary>
    public DateTime? ReviewDate { get; set; }

    /// <summary>
    /// Whether this game is featured on the homepage
    /// </summary>
    public bool IsFeatured { get; set; }

    /// <summary>
    /// Longer description for featured games
    /// </summary>
    [StringLength(2000)]
    public string? Description { get; set; }

    // Helper methods for display
    public string[] GetPlatformList() => 
        string.IsNullOrEmpty(Platforms) ? Array.Empty<string>() : Platforms.Split(',', StringSplitOptions.TrimEntries);

    public string[] GetGenreList() => 
        string.IsNullOrEmpty(Genres) ? Array.Empty<string>() : Genres.Split(',', StringSplitOptions.TrimEntries);

    public string GetRatingClass() => Rating switch
    {
        >= 9.0m => "excellent",
        >= 8.0m => "good",
        _ => "average"
    };

    public string GetFormattedReviewDate() => 
        ReviewDate?.ToString("MMM yyyy") ?? string.Empty;
}
