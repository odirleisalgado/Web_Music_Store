using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicWeb.Models
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string Nome { get; set; }
        public string Email {get; set;}
        public string Senha { get; set; }
        public string Endereco { get; set; }
        public string Bairo { get; set; }
        public int Numero { get; set; }
    }
}