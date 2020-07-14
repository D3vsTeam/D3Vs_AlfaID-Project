using AlphaId.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlphaId.Infra.Data.InMemory
{
    public class Contexto : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Epi> Epis { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseInMemoryDatabase("AlphaId");
            base.OnConfiguring(builder);
        }
    }
}
