using System.ComponentModel.DataAnnotations;

namespace mvc.DTOs
{
    public class CreateQuoteDto
    {
        [Required]
        [MaxLength(128, ErrorMessage = "Quote text must be less than 128 characters!")]
        public string Text { get; set; }
        [MaxLength(64, ErrorMessage = "Quote author must be less than 64 characters!")]
        public string Author { get; set; }
        [Required]
        [MaxLength(32, ErrorMessage = "Quote language must be less than 32 characters!")]
        public string Language { get; set; }
    }

    public class UpdateQuoteDto : CreateQuoteDto
    {
        [Required]
        public int Id { get; set; }
    }

    public class QuoteDto : UpdateQuoteDto
    {
    }
}