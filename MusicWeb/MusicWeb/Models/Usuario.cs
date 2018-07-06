using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MusicWeb.Models
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string Nome { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Senha { get; set; }
        public string Endereco { get; set; }
        public string Bairo { get; set; }
        public int Numero { get; set; }
        public virtual List<Pedido> ListaPedidos { get; set; }



    }
}