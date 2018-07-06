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

        public Decimal Total { get; set; }

        public  List<Item> ListaItem { get; set; }

        public Pedido()
        {
            ListaItem = new List<Item>();
        }

       
    }
}