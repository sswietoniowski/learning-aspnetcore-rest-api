using System.ComponentModel.DataAnnotations;

namespace mvc.DataAccess.Entities;

public class Author
{
    [Key]
    public int Id { get; set; }
    [Required]
    [MaxLength(64)]
    public string Name { get; set; } = string.Empty;
    public string Biography { get; set; } = string.Empty;
    public List<Quote> Quotes { get; set; } = new();
}