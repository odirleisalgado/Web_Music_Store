using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MusicWeb.Models
{
    public class Artista
    {
        [Display(Name = "Artista")]
        public int ArtistaId { get; set; }
        public string Nome { get; set; }
        


    }
}