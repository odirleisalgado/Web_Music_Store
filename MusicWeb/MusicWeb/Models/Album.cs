using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicWeb.Models
{
    public class Album
    {
        public int AlbumId { get; set; }
        public int GeneroId { get; set; }
        public int ArtistaId { get; set; }
        public string Titulo { get; set; }
        public decimal Valor { get; set; }
        public string AlbumArtUrl { get; set; }
        public Genero Genero { get; set; }
        public Artista Artista { get; set; }

    }
}