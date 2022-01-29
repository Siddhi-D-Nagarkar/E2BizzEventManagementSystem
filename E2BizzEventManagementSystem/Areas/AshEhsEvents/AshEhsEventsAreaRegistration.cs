using System.Web.Mvc;

namespace E2BizzEventManagementSystem.Areas.AshEhsEvents
{
    public class AshEhsEventsAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "AshEhsEvents";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "AshEhsEvents_default",
                "AshEhsEvents/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}