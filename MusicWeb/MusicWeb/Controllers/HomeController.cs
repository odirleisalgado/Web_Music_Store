using MusicWeb.Banco;
using MusicWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicWeb.Controllers
{
    public class HomeController : Controller
    {
        Contexto db = new Contexto();

        // GET: Home
        public ActionResult Index()
        {
            if (Session["IdUsuario"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
           
        }

        public ActionResult Login()
        {
            Session["Email"] = null;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                using (db)
                {
                    var objeto = db.Usuarios.Where(a => a.Email.Equals(usuario.Email) && a.Senha.Equals(usuario.Senha)).FirstOrDefault();
                    if (objeto != null)
                    {

                        Session["IdUsuario"] = objeto.UsuarioId.ToString();
                        Session["Email"] = objeto.Email.ToString();
                        return RedirectToAction("Index");

                    }
                }
            }

            return View(usuario);
        }



        //public ActionResult UserDashBoard()
        //{
        //    if (Session["IdUsuario"] != null)
        //    {
        //        return View();
        //    }
        //    else
        //    {
        //        return RedirectToAction("Login");
        //    }
        //}
    }
}