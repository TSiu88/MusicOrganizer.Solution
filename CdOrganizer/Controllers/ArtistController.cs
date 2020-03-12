using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using musicOrganizer.Models;

namespace musicOrganizer.Controllers
{
    public class ArtistController : Controller
    {
        [HttpGet("/artists")]
        public ActionResult Index()
        {
            List<Artist> allArtists = Artist.GetAll();
            return View(allArtists);
        }

        [HttpGet("/artists/new")]
        public ActionResult New()
        {
            return View();
        }
        
        [HttpPost("/artists")]
        public ActionResult Create(string name)
        {
            Artist newArtist = new Artist(name);
            return RedirectToAction("Index");
        }

        [HttpGet("/artists/{id}")]
        public ActionResult Show(int id)
        {
            Dictionary<string, object> model = new Dictionary<string, object> ();
            Artist selectedArtist = Artist.Find(id);
            List<Cd> artistCds = selectedArtist.Cds;
            model.Add("artist", selectedArtist);
            model.Add("cds", artistCds);
            return View(model);
        }

        [HttpPost("/artist/{artistId}/cds")]
        public ActionResult Create(int artistId, string cdTitle)
        {
            Dictionary<string, object> model = new Dictionary<string, object> ();
            Artist foundArtist = Artist.Find(artistId);
            Cd newCd = new Cd(cdTitle);
            foundArtist.AddCd(newCd);
            List<Cd> artistCds = foundArtist.Cds;
            model.Add("cds", artistCds);
            model.Add("artist", foundArtist);
            return View("Show", model);
        }
    }
}