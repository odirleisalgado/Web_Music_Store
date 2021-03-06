﻿using MusicWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MusicWeb.Banco
{
    public class Contexto : DbContext
    {
        public Contexto() : base("stringDeConeccao")
        {
            Database.SetInitializer<Contexto>(new DropCreateDatabaseIfModelChanges<Contexto>());
        }

        public DbSet<Album> Albums { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Artista> Artistas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Item> itens { get; set; }

    }

}