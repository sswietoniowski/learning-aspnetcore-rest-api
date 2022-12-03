using System.ComponentModel.DataAnnotations;

namespace mvc.Versions.v2.DTOs;

public class QuoteForCreationDto
{
    [Required]
    [MaxLength(128, ErrorMessage = "Quote text must be less than 128 characters!")]
    public string Text { get; set; } = string.Empty;
    public int? AuthorId { get; set; }
    [Required]
    public int LanguageId { get; set; }
}

public class QuoteForUpdateDto : QuoteForCreationDto
{
}

public class QuoteDto
{
    public int Id { get; set; }
    public string Text { get; set; } = string.Empty;
    public int? AuthorId { get; set; }
    public int LanguageId { get; set; }
}

public class QuoteDetailsDto : QuoteDto
{
    public AuthorDto? Author { get; set; }
    public LanguageDto Language { get; set; } = default!;
}