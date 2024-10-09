using Microsoft.AspNetCore.Mvc;

namespace Desafio_CodgoX_2_API.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
