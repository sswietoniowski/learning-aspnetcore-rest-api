using Microsoft.AspNetCore.Mvc;
using mvc.Versions.v2.DTOs;
using mvc.Versions.v2.Services;

namespace mvc.Versions.v2.Controllers;

[ApiController]
[Route("api/languages")]
[Route("api/v{version:apiVersion}/languages")]
[ApiVersion("2.0")]
public class LanguageController : ControllerBase
{
    private readonly ILogger<LanguageController> _logger;
    private readonly ILanguageService _languageService;

    public LanguageController(ILogger<LanguageController> logger, ILanguageService languageService)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _languageService = languageService ?? throw new ArgumentNullException(nameof(languageService));
    }

    // GET: api/languages
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<LanguageDto>>> GetLanguages()
    {
        _logger.LogInformation($"Calling: {nameof(GetLanguages)}");

        var languageDtos = await _languageService.GetAllAsync();

        return Ok(languageDtos);
    }

    // GET: api/languages/id
    [HttpGet("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<LanguageDto>> GetLanguage(int id)
    {
        _logger.LogInformation($"Calling: {nameof(GetLanguage)}");

        var languageDto = await _languageService.GetByIdAsync(id);

        return Ok(languageDto);
    }

    // POST: api/languages
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<LanguageDto>> CreateLanguage([FromBody] LanguageForCreationDto languageDto)
    {
        _logger.LogInformation($"Calling: {nameof(CreateLanguage)}");

        var createdLanguageDto = await _languageService.CreateAsync(languageDto);

        return Created(new Uri($"{Request.Path}/{createdLanguageDto.Id}", UriKind.Relative), createdLanguageDto);
    }

    // PUT: api/languages/id
    [HttpPut("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdateLanguage(int id, [FromBody] LanguageForUpdateDto languageDto)
    {
        _logger.LogInformation($"Calling: {nameof(UpdateLanguage)}");

        await _languageService.UpdateAsync(id, languageDto);

        return NoContent();
    }

    // DELETE: api/languages/id
    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeleteLanguage(int id)
    {
        _logger.LogInformation($"Calling: {nameof(DeleteLanguage)}");

        await _languageService.DeleteAsync(id);

        return NoContent();
    }
}