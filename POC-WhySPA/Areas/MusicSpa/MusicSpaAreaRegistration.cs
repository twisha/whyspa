using System.Web.Mvc;

namespace POC_WhySPA.Areas.MusicSpa
{
    public class MusicSpaAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "MusicSpa";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "MusicSpa_default",
                "MusicSpa/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
