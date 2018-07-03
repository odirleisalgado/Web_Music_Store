using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicWeb.Models
{
    public class Pedido
    {

        public int PedidoID { get; set; }

        public System.DateTime DataPedido { get; set; }

        public int UsuarioId { get; set; }

        public virtual Usuario User { get; set; }

        public double Total { get; set; }

        public int AlbumId { get; set; }

        public virtual List<Album> ListaAlbum { get; set; }

        public Pedido()
        {
            ListaAlbum = new List<Album>();
        }
    }
}