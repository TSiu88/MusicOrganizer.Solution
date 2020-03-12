using Microsoft.AspNetCore.Mvc;

namespace musicOrganizer.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("/")]
        public ActionResult Index()
        {
            return View();
        }
    }
}
