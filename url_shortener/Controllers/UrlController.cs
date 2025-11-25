using Microsoft.AspNetCore.Mvc;
using url_shortener.Database;

namespace url_shortener.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UrlController : ControllerBase
    {
        private readonly IUrlRepository _repository;
        public UrlController(IUrlRepository repository) 
        { 
            _repository = repository;
        }
    }
}
