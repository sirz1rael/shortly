using Microsoft.AspNetCore.Mvc;

using url_shortener.Database;
using url_shortener.Models;
using url_shortener.Services;

namespace url_shortener.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UrlController(IUrlService service) : ControllerBase
    {
        private readonly IUrlService _urlService = service;

        [HttpPost]
        public async Task<IActionResult> CreateShortUrl([FromBody] CreateUrlRequest request)
        {
            // TODO: Check authorization headers

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            UrlCreationResult result = await _urlService.CreateShortUrlAsync(request.OriginalUrl, request.CustomShortCode);

            if (!result.IsSuccess)
                return BadRequest(new { message = result.ErrorMessage });

            return Ok(new { shortUrl = result.ShortUrl });
        }
    }
}
