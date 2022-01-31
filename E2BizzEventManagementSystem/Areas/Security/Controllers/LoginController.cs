using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E2BizzEventManagementSystem.Model;
using E2BizzEventManagementSystem.DAL;

namespace E2BizzEventManagementSystem.Areas.Security.Controllers
{
    public class LoginController : Controller
    {
        private readonly CommonRepository<User> loginCommonRepo;
        public LoginController(CommonRepository<User> repository)
        {
            loginCommonRepo = repository;
        }
        
        // GET: Security/Login
        public ActionResult Index()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(User user)
        {
            if (ModelState.IsValid)
            {
                var sdf = loginCommonRepo.authenticateUser(user);
                int result = loginCommonRepo.SaveChanges();
                if (loginCommonRepo.authenticateUser(user) != null)
                {

                    HttpCookie userCookie = new HttpCookie("userProfileCookie");
                    userCookie.Values.Add("uEmail",user.Email);
                    userCookie.Expires = DateTime.Now.AddSeconds(60);
                    Response.AppendCookie(userCookie);
                    return RedirectToAction("Index","Home",new {area=""});
                }
                //Redirect the user request to some error page!
            }
            ModelState.AddModelError("Error", "Something Went Wrong!");
            return View();
        }
    }
}