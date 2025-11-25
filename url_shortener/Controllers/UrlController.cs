using Microsoft.AspNetCore.Mvc;
using url_shortener.Database;

namespace url_shortener.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UrlController(IUrlRepository repository) : ControllerBase
    {
        private readonly IUrlRepository _repository = repository;
    }
}
