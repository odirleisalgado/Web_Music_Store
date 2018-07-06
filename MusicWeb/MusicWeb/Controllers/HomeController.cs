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
                        if (usuario.Email.Equals("odirlei@gmail.com"))
                        {
                            
                            Session["Email"] = objeto.Email.ToString();
                          
                            return RedirectToAction("Index", "Albums", new { id = 1 });
                        }
                        else
                        {
                            Session["IdUsuario"] = objeto.UsuarioId;
                            Session["Email"] = objeto.Email.ToString();
                            ViewBag.IdUsuario = usuario.UsuarioId;
                            return RedirectToAction("Home", "Loja", new { id = 1 });
                        }
                      

                    }
                }
            }

            return View(usuario);
        }

    }
}