using System.ComponentModel.DataAnnotations;

namespace mvc.Versions.v2.DTOs;

public class AuthorForCreationDto
{
    [Required]
    [MaxLength(64, ErrorMessage = "Author name must be less than 64 characters!")]
    public string Name { get; set; } = string.Empty;
    public string? Biography { get; set; }
}

public class AuthorForUpdateDto : AuthorForCreationDto
{
}

public class AuthorDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Biography { get; set; }
}