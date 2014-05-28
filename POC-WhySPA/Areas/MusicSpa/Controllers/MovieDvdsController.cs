using System.Web.Mvc;

namespace POC_WhySPA.Areas.MusicSpa.Controllers
{
    public class MovieDvdsController : Controller
    {
        //
        // GET: /MusicSpa/MovieDvds/

        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult List()
        {
            return PartialView();
        }

        public PartialViewResult Edit()
        {
            return PartialView();
        }

        public PartialViewResult ModalView()
        {
            return PartialView();
        }
    }
}
