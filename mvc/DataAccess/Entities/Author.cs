using System.ComponentModel.DataAnnotations;

namespace mvc.DataAccess.Entities;

public class Author
{
    [Key]
    public int Id { get; set; }
    [Required]
    [MaxLength(64)]
    public string Name { get; set; } = string.Empty;
    [MaxLength(1024)]
    public string? Biography { get; set; }
    public List<Quote> Quotes { get; set; } = new();
}