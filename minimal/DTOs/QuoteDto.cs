using System.ComponentModel.DataAnnotations;

namespace minimal.DTOs
{
    public class QuoteForCreationDto
    {
        [Required]
        [MaxLength(128, ErrorMessage = "Quote text must be less than 128 characters!")]
        public string Text { get; set; } = string.Empty;
        [MaxLength(64, ErrorMessage = "Quote author must be less than 64 characters!")]
        public string? Author { get; set; }
        [Required]
        [MaxLength(32, ErrorMessage = "Quote language must be less than 32 characters!")]
        public string Language { get; set; } = string.Empty;
    }

    public class QuoteForUpdateDto : QuoteForCreationDto
    {
    }

    public class QuoteDto
    {
        public int Id { get; set; }
        public string Text { get; set; } = string.Empty;
        public string? Author { get; set; }
        public string Language { get; set; } = string.Empty;
    }
}