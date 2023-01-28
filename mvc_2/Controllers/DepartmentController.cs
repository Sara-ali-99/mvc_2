using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using mvc_2.Models;

namespace mvc_2.Controllers
{
    public class DepartmentController : Controller
    {

        MVC_DemoDbContext db;
        public DepartmentController()
        {
            db = new MVC_DemoDbContext();
        }
        public IActionResult Index()
        {
           
            return View();
        }
        public IActionResult showDepartment(int id)
        {

            //Department? department = db.departments.SingleOrDefault(e => e.Number == HttpContext.Session.GetInt32("Number"));

            //return View(department);
            Department department = db.departments.Include(d => d.locations).Include(d => d.Projects).SingleOrDefault(d => d.emp_m == id);
            
            if (department == null)
                return View("Error");
            else
                return View("GetDepartmentByMgrId", department);


        }
        public IActionResult displayDeptProjects()
        {
            var id = HttpContext.Session.GetInt32("id");

            var deptProjects = db.projects.Where(p => p.DeptNum ==p.Departments.Number && p.Departments.emp_m == id);


            return View(deptProjects);
        }
        public IActionResult addToDeptProjectForm()
        {
            var id = HttpContext.Session.GetInt32("id");
            var emps = db.employees.ToList();
            var deptProjects = db.projects.Where(p => p.DeptNum == p.Departments.Number && p.Departments.emp_m == id);
            ViewBag.dps = deptProjects;
            return View(emps);
        }
        public IActionResult addToProject(int emp, List<int> projs)
        {
            foreach (var proj in projs)
            {
                workOn newobj = new workOn()
                {
                    ESSN = emp,
                    projectNum = proj
                };
                db.workOns.Add(newobj);
                db.SaveChanges();
            }

            return RedirectToAction("showDepartment");
        }
        public IActionResult displayDepartments()
        {
            var depts = db.departments.ToList();
            return View(depts);
        }
        public IActionResult addDepartmentForm()
        {

            var empsList = new SelectList(db.employees.ToList(), "id", "fname");

            return View(empsList);
        }
        public IActionResult addDepartment(Department dept)
        {
            db.departments.Add(dept);
            db.SaveChanges();
            return RedirectToAction("displayDepartments");
        }
        public IActionResult updateForm(int id)
        {
            var dept = db.departments.SingleOrDefault(d => d.Number== id);
            var empsList = new SelectList(db.employees.ToList(), "id", "fname");
            ViewBag.list = empsList;
            return View(dept);
        }
        public IActionResult updateDepartment(Department dept)
        {
            var oldDept = db.departments.SingleOrDefault(d => d.Number == dept.Number);
            oldDept.Name = dept.Name;
            oldDept.DepartmentLocations= dept.DepartmentLocations;
           
            oldDept.emp_m = dept.emp_m;
            db.SaveChanges();
            return RedirectToAction("displayDepartments");
        }
        public IActionResult deleteDepartment(int id)
        {
            var dept = db.departments.SingleOrDefault(d => d.Number == id);
            db.departments.Remove(dept);
            db.SaveChanges();
            return RedirectToAction("displayDepartments");
        }
    }
}

