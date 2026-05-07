using Microsoft.AspNetCore.Mvc;

namespace LojaVirtual.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
