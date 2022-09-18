using System.ComponentModel.DataAnnotations;

namespace mvc.DataAccess.Entities;

public class QuoteEntity
{
    [Key]
    public int Id { get; set; }
    [Required]
    [MaxLength(128)]
    public string Text { get; set; } = string.Empty;
    [MaxLength(64)]
    public string Author { get; set; } = string.Empty;
    [Required]
    [MaxLength(32)]
    public string Language { get; set; } = string.Empty;
}