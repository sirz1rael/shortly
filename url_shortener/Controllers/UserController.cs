using Microsoft.AspNetCore.Mvc;
using url_shortener.Database;

namespace url_shortener.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository repository)
        {
            _userRepository = repository;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
