using System.Web.Mvc;

namespace E2BizzEventManagementSystem.Areas.AskEhsEmployees
{
    public class AskEhsEmployeesAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "AskEhsEmployees";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "AskEhsEmployees_default",
                "AskEhsEmployees/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}