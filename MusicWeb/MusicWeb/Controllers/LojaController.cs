using MusicWeb.Banco;
using MusicWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicWeb.Controllers
{
    public class LojaController : Controller
    {

        private Contexto db = new Contexto();
        // GET: /Loja/
        public ActionResult Index()
        {
            return View(db.Generos.ToList());
        }
        //
        // GET: /Loja/Browse
        public ActionResult Browse(string genero)
        {
            var generoModel = db.Generos.Include("Albums").Single(g => g.Nome == genero);

            return View(generoModel);
        }
        //
        // GET: /Store/Details
        public ActionResult Details(int id)
        {
            var album = db.Albums.Find(id);

            return View(album);
        }
    }
}