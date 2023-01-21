using Microsoft.AspNetCore.Mvc;

namespace mvc_2.Controllers
{
    public class workOnController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
