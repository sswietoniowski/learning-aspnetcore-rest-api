using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mvc.DataAccess.Entities;

public class Quote
{
    [Key]
    public int Id { get; set; }
    [Required]
    [MaxLength(128)]
    public string Text { get; set; } = string.Empty;
    [MaxLength(64)]
    public Author? Author { get; set; }
    [ForeignKey(nameof(Author))]
    public int? AuthorId { get; set; }
    public Language? Language { get; set; }
    [ForeignKey(nameof(Language))]
    public int? LanguageId { get; set; }
}