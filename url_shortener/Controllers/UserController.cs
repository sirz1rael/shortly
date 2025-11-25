using Microsoft.AspNetCore.Mvc;
using url_shortener.Database;

namespace url_shortener.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController(IUserRepository repository) : Controller
    {
        private readonly IUserRepository _userRepository = repository;

        
    }
}
