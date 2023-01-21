using Microsoft.AspNetCore.Mvc;

namespace mvc_2.Controllers
{
    public class projectController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
