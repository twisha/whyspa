using System.Web.Mvc;

namespace POC_WhySPA.Areas.MusicSpa.Controllers
{
    public class AlbumsController : Controller
    {
        //
        // GET: /MusicSpa/Albums/

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
    }
}
