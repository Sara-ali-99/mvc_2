using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mvc_2.Models;


namespace mvc_2.Controllers
{
    public class workOnController : Controller
    {
        private MVC_DemoDbContext db;
        public workOnController()
        {
            db = new MVC_DemoDbContext();
        }

        public IActionResult AddEmployeesToProjects(int id)
        {
            List<project> projects = db.projects.Where(p => p.DeptNum == id).ToList();
            List<employee> employees = db.employees.Where(p => p.deptId_w == id).ToList();

            ViewBag.emps = employees;

            return View(projects);
        }

        workOn worksOnProject1;
        public IActionResult AddEmployeesToProjectsToDB(List<int> Projects, List<int> Employees)
        {

            foreach (var Project in Projects)
            {
                foreach (var employee in Employees)
                {
                    workOn worksOnProject = new workOn()
                    {
                        ESSN = employee,
                        projectNum = Project
                    };
                    worksOnProject1 = db.workOns.Include(wop => wop.Project).SingleOrDefault(wop => wop.ESSN == worksOnProject.ESSN);
                    db.workOns.Add(worksOnProject);
                    db.SaveChanges();
                }

            }

            ViewBag.emps = Employees;
            ViewBag.mgrSSN = (int)HttpContext.Session.GetInt32("SSN");

            return View(worksOnProject1);
        }

    }

}

