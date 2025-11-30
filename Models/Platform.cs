using System.ComponentModel.DataAnnotations;

namespace web_server_app_dev_final.Models;

public class Platform
{
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;

    [StringLength(500)]
    public string? Description { get; set; }

    public int? ReleaseYear { get; set; }

    [StringLength(100)]
    public string? Creator { get; set; }
}
