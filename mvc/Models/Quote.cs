using System.ComponentModel.DataAnnotations;

namespace mvc.Models
{
    public class Quote
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(128)]
        public string Text { get; set; }
        [MaxLength(64)]
        public string Author { get; set; }
        [Required]
        [MaxLength(32)]
        public string Language { get; set; }
    }
}