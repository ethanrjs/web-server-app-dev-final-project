using System.ComponentModel.DataAnnotations;

namespace web_server_app_dev_final.Models;

public class Game
{
    public int Id { get; set; }

    [Required]
    [StringLength(200)]
    public string Title { get; set; } = string.Empty;

    [StringLength(100)]
    public string? PlatformName { get; set; }

    public int? Year { get; set; }

    [StringLength(100)]
    public string? Maker { get; set; }
}
