using Microsoft.AspNetCore.Mvc;

namespace mvc_2.Controllers
{
    public class locationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
