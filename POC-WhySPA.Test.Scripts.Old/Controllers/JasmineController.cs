using System.Web.Mvc;

namespace POC_WhySPA.Test.Scripts.Controllers
{
    public class JasmineController : Controller
    {
        public ViewResult Run()
        {
            return View("SpecRunner");
        }
    }
}
