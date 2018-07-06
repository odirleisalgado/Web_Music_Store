using MusicWeb.Banco;
using MusicWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicWeb.Controllers

{
    public class LojaController : Controller
    {

        private Contexto db = new Contexto();
        static public List<Album> albuns = new List<Album>();
        public Decimal total = 0;

        // GET: /Loja/


        public ActionResult Home()
        {
            if (Session["IdUsuario"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Home", new { id = 1 });
            }
        }

        public ActionResult Index()
        {
            var generos = db.Generos.ToList();
            return View(generos);
        }

        public ActionResult CarrinhoDetails()
        {
            return View(albuns.ToList());
        }
        
        public ActionResult Browse(string genero)
        {
            var generoModel = db.Generos.Include("Albums").Single(g => g.Nome == genero);

            return View(generoModel);
        }
    
        public ActionResult Details(int id)
        {
            var album = db.Albums.Find(id);

            return View(album);
        }

        public ActionResult AdicionarAlbum(int id)
        {

            var album = db.Albums.Find(id);
            if (album != null)
            {

                albuns.Add(album);
                total += decimal.Parse(album.Valor.ToString());
            }

            ViewBag.Total = total;

            return RedirectToAction("CarrinhoDetails");


        }

        public ActionResult delete(int id)
        {
            foreach (var item in new List<Album>(albuns))
            {
                if (item.AlbumId == id)
                {
                    albuns.Remove(item);
                    break;
                }

            }


            return RedirectToAction("CarrinhoDetails");

        }

        public ActionResult Logout()
        {

            if (Session["Email"].Equals("odirlei@gmail.com"))
            {
                return RedirectToAction("Login");
            }
            else
            {
                foreach (var item in new List<Album>(albuns))
                {
                    albuns.Remove(item);
                }
                return RedirectToAction("Login", "Home", new { id = 1 });
            }
        }


        public ActionResult Finalizar()
        {

            Pedido novopedido = new Pedido();


            foreach (var album in albuns)
            {
              
                novopedido.ListaItem.Add(new Item { AlbumId=album.AlbumId});
                novopedido.Total += album.Valor;
            }               
            novopedido.DataPedido = System.DateTime.Now;           
            novopedido.UsuarioId = int.Parse(Session["IdUsuario"].ToString());
            db.Usuarios.Find(Convert.ToInt32(Session["IdUsuario"])).ListaPedidos.Add(novopedido);
            //db.Pedidos.Add(novopedido);
            db.SaveChanges();
           
            return RedirectToAction("index");
        }
       
        public ActionResult Historico()
        {
            List<Item> itens = new List<Item>();
            int id = Convert.ToInt32(Session["IdUsuario"]);

            List<Pedido> p= db.Pedidos.Where(i => i.UsuarioId == id).Include(f=> f.ListaItem.Select(d=>d.Album)).ToList();



            List<Album> albunsHistorico= new List<Album>();

            foreach (var pedido in p)
            {
                for (int i = 0; i < pedido.ListaItem.Count; i++)
                {
                    albunsHistorico.Add(pedido.ListaItem[i].Album);
                  
                }
            }

          
            return View(albunsHistorico);
          
        }

    }
}