using System.ComponentModel.DataAnnotations;

namespace mvc.DataAccess.Entities;

public class Language
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; } = string.Empty;
    [Required]
    [MaxLength(32)]
    public List<Quote> Quotes { get; set; } = new();
}