using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mvc_2.Models;

namespace mvc_2.Controllers
{
    public class DependentController : Controller
    {
        private MVC_DemoDbContext dbContext;
        public DependentController()
        {
            dbContext = new MVC_DemoDbContext();
        }
     
    }
}
