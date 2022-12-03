using System.ComponentModel.DataAnnotations;

namespace mvc.Versions.v2.DTOs;

public class LanguageForCreationDto
{
    [Required]
    [MaxLength(32, ErrorMessage = "Language name must be less than 32 characters!")]
    public string Name { get; set; } = string.Empty;
}

public class LanguageForUpdateDto : LanguageForCreationDto
{
}

public class LanguageDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}