using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E2BizzEventManagementSystem.DAL;
using E2BizzEventManagementSystem.Model;
using PagedList;

namespace E2BizzEventManagementSystem.Areas.AshEhsEvents.Controllers
{
    public class EventsController : Controller
    {
        // GET: AshEhsEvents/Events
        private readonly CommonRepository<Event> eventCommonRepo;
        public EventsController(CommonRepository<Event> repository)
        {
            eventCommonRepo = repository;
        }
        public ActionResult Index(int page=1)
        {
            int pageSize = 3;
            return View(eventCommonRepo.GetAll().ToPagedList(page,pageSize));
        }

        public ActionResult Details(int id)
        {
            return View(eventCommonRepo.GetDetails(id));
        }

        public ActionResult Create()
        {
            return View();
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Event @event)
        {
            if (ModelState.IsValid)
            {
                @event.Logo = "~/images/noimage.png";
                eventCommonRepo.Insert(@event);
                int result = eventCommonRepo.SaveChanges();
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
            var eventEl = eventCommonRepo.GetDetails(id);
            eventCommonRepo.Delete(eventEl);
            int result = eventCommonRepo.SaveChanges();
            return RedirectToAction("Index");
        }
         
    }
}