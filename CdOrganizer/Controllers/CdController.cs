using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using musicOrganizer.Models;


namespace musicOrganizer.Controllers
{
    public class CdController : Controller
    {
      [HttpGet("/artists/{artistId}/cds/new")]
      public ActionResult New(int artistId)
      {
          Artist artist = Artist.Find(artistId);
          return View(artist);
      }

      [HttpGet("/artists/{artistId}/cds/{cdId}")]
      public ActionResult Show(int artistId, int cdId)
      {
          Cd cd = Cd.Find(cdId);
          Artist artist = Artist.Find(artistId);
          Dictionary<string, object> model = new Dictionary<string, object>();
          model.Add("cd", cd);
          model.Add("artist", artist);
          return View(model);
      }

      [HttpPost("/cds/delete")]
      public ActionResult DeleteAll()
      {
          Cd.ClearAll();
          return View("DeleteAll");
      }

    }
}
