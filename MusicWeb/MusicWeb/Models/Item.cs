using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicWeb.Models
{
    public class Item
    {
        public int ItemID { get; set; }
        public int AlbumId { get; set; }
        public int PedidoID { get; set; }
        public virtual Album Album { get; set; }

    }
}