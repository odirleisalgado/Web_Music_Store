using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicWeb.Models
{
    [Bind(Exclude = "AlbumId")]
    public class Album
    {
        [ScaffoldColumn(false)]
        public int AlbumId { get; set; }

        [DisplayName("Artista")]
        public int ArtistaId { get; set; }

        [DisplayName("Gênero")]
        public int GeneroId { get; set; }

        [Required(ErrorMessage = "Por favor, insira um título")]
        [StringLength(160)]
        public string Titulo { get; set; }

        [Range(0.01, 100.00,
            ErrorMessage = "O Valor deve ser entre R$ 0.01 e R$200.00")]
        public decimal Valor { get; set; }

        [DisplayName("URL da Imagem")]
        [StringLength(1024)]
        public string AlbumArtUrl { get; set; }

        public virtual Genero Genero { get; set; }

        public virtual Artista Artista { get; set; }

       


    }
}