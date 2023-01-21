using Microsoft.AspNetCore.Mvc;

namespace mvc_2.Controllers
{
    public class DepartmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
