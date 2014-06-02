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

        public ActionResult Accordian()
        {
            return PartialView();
        }

        public ActionResult Modal()
        {
            return PartialView();
        }

        public ActionResult ModalContent()
        {
            return PartialView();
        }

        public ActionResult Carousel()
        {
            return PartialView();
        }
    }
}
