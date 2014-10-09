using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using FindSimilarMusic.Models;
using FindSimilarMusic.Models.LastFM;
using WebGrease.Css.Extensions;

namespace FindSimilarMusic.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetSimilarArtists(string[] artistName)
        {
            if (artistName == null || artistName.Length == 0)
            {
                return Json(new { error = "Please add artists" }, JsonRequestBehavior.AllowGet);
            }
            LastFMApi lastfm = new LastFMApi();
            var result = lastfm.GetSimilarArtists(artistName.Select(qq => new Artist { Name = qq }).ToArray());
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}