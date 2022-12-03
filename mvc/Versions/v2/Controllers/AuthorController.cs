using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using mvc.Versions.v2.DTOs;
using mvc.Versions.v2.Services;

namespace mvc.Versions.v2.Controllers;

[ApiController]
[Route("api/authors")]
[Route("api/v{version:apiVersion}/authors")]
[ApiVersion("2.0")]
public class AuthorController : ControllerBase
{
    private readonly ILogger<AuthorController> _logger;
    private readonly IAuthorService _authorService;

    public AuthorController(ILogger<AuthorController> logger, IAuthorService authorService)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _authorService = authorService ?? throw new ArgumentNullException(nameof(authorService));
    }

    // GET: api/authors
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<AuthorDto>>> GetAuthors()
    {
        _logger.LogInformation($"Calling: {nameof(GetAuthors)}");

        var authorsDto = await _authorService.GetAllAsync();

        return Ok(authorsDto);
    }

    // GET: api/authors/id
    [HttpGet("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<AuthorDto>> GetAuthor(int id)
    {
        _logger.LogInformation($"Calling: {nameof(GetAuthor)}");

        var authorDto = await _authorService.GetByIdAsync(id);

        return Ok(authorDto);
    }

    // POST: api/authors
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<AuthorDto>> CreateAuthor([FromBody] AuthorForCreationDto authorDto)
    {
        _logger.LogInformation($"Calling: {nameof(CreateAuthor)}");

        var createdAuthorDto = await _authorService.CreateAsync(authorDto);

        // I'm using Created instead of CreatedAtAction or CreatedAtRoute because I'm using
        // multiple versioning strategies

        return Created(new Uri($"{Request.Path}/{createdAuthorDto.Id}", UriKind.Relative), createdAuthorDto);
    }

    // PUT: api/authors/id
    [HttpPut("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdateAuthor(int id, [FromBody] AuthorForUpdateDto authorDto)
    {
        _logger.LogInformation($"Calling: {nameof(UpdateAuthor)}");

        await _authorService.UpdateAsync(id, authorDto);

        return NoContent();
    }

    // DELETE: api/authors/id
    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeleteAuthor(int id)
    {
        _logger.LogInformation($"Calling: {nameof(DeleteAuthor)}");

        await _authorService.DeleteAsync(id);

        return NoContent();
    }
}