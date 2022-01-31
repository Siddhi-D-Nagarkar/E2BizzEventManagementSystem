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
        public ActionResult Index(string sortOrder,string searchString, int page=1)
        {
            ViewBag.EventCode= String.IsNullOrEmpty(sortOrder) ? "eventCode_desc" : "";
            ViewBag.EventName = sortOrder == "eventName_asc" ? "eventName_desc" : "eventName_asc";
            ViewBag.StartDate = sortOrder == "startDate_asc" ? "startDate_desc" : "startDate_asc";
            ViewBag.Fees = sortOrder == "fees_asc" ? "fees_desc" : "fees_asc";
            ViewBag.CurrentFilter = searchString;
            var events = eventCommonRepo.GetAll();
            if (!String.IsNullOrEmpty(searchString))
            {
                events = events.Where(e => e.EventCode.Contains(searchString)).ToList();
                events.Count();
            }
            if (events.Count == 0)
            {
                events = eventCommonRepo.GetAll();
            }
            switch (sortOrder)
            {
                case "eventCode_desc":
                    events = events.OrderByDescending(s => s.EventCode).ToList();
                    break;
                case "eventName_desc":
                    events = events.OrderByDescending(s => s.EventName).ToList();
                    break;
                case "eventName_asc":
                    events = events.OrderBy(s => s.EventName).ToList();
                    break;
                case "startDate_asc":
                    events = events.OrderBy(s => s.StartDate).ToList();
                    break;
                case "startDate_desc":
                    events = events.OrderByDescending(s => s.StartDate).ToList();
                    break;
                case "fees_asc":
                    events = events.OrderBy(s => s.Fees).ToList();
                    break;
                case "fees_desc":
                    events = events.OrderByDescending(s => s.Fees).ToList();
                    break;
                default:
                    events = events.OrderBy(s => s.EventCode).ToList();
                    break;
            }

            int pageSize = 3;
            return View(events.ToPagedList(page,pageSize));
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