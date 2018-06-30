using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MusicWeb.Models
{
    public class Genero
    {
        public int GeneroId { get; set; }
        [Display (Name ="Gênero")]
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public List<Album> Albums { get; set; }

    }
}