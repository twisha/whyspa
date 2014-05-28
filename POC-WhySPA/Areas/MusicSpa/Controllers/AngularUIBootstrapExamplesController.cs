using System.Web.Mvc;

namespace POC_WhySPA.Areas.MusicSpa.Controllers
{
    public class AngularUIBootstrapExamplesController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            return PartialView();
        }
    }
}
