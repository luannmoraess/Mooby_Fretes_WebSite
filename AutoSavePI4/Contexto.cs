using Microsoft.EntityFrameworkCore;
using AutoSavePI4.Entidades;

namespace AutoSavePI4
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }
        public DbSet<Empresa> EMPRESA { get; set; }
        public DbSet<Caminhao> CAMINHAO { get; set; }
        public DbSet<Fretes> FRETES { get; set; }
        public DbSet<Usuario> USUARIO { get; set; }
    }
}

