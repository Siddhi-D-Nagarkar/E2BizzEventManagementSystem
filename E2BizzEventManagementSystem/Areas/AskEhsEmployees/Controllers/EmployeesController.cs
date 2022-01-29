using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using E2BizzEventManagementSystem.DAL;
using E2BizzEventManagementSystem.Model;
using PagedList;

namespace E2BizzEventManagementSystem.Areas.AskEhsEmployees.Controllers
{
    public class EmployeesController : Controller
    {
        // GET: AskEhsEmployees/Employees
        private readonly CommonRepository<Employee> empCommonRepo;
        public EmployeesController(CommonRepository<Employee> repository)
        {
            empCommonRepo = repository;
        }
        public ActionResult Index(int page = 1)
        {
            int pageSize = 3;
            return View(empCommonRepo.GetAll().ToPagedList(page, pageSize));
        }

        public ActionResult Details(int id)
        {
            return View(empCommonRepo.GetDetails(id))
;
        }

        public ActionResult Create()
        {

            return View();
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee emp)
        {
            if (ModelState.IsValid)
            {
                empCommonRepo.Insert(emp);
                int result = empCommonRepo.SaveChanges();
                if (result > 0)
                {
                    return RedirectToAction("Index");
                }
                //Redirect the user request to some error page!
            }
            ModelState.AddModelError("Error", "Something Went Wrong!");
            return View();
        }
        public ActionResult Delete(int id)
        {
            var employee = empCommonRepo.GetDetails(id);
            empCommonRepo.Delete(employee);
            int result = empCommonRepo.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var empEl=empCommonRepo.GetDetails(id);
            return View(empEl);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee emp)
        {
            if (ModelState.IsValid)
            {
                empCommonRepo.Update(emp.EmployeeId,emp);
                int result = empCommonRepo.SaveChanges();
                if (result > 0)
                {
                    return RedirectToAction("Index");
                }
                //Redirect the user request to some error page!
            }
            ModelState.AddModelError("Error", "Something Went Wrong!");
            return View();
        }
    }
}