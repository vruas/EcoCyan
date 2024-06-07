using EcoCyan.Models;
using Microsoft.EntityFrameworkCore;


namespace EcoCyan.Data
{
    public class ApplicationDbContext : DbContext
    
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<EntregaLixo> EntregaLixo { get; set; }
        public DbSet<LixoColetado> LixoColetado { get; set; }
        public DbSet<PontoDeColeta> PontoDeColeta { get; set; }
        public DbSet<Reciclagem> Reciclagem { get; set; }
        public DbSet<Usuarios> Usuario { get; set; }


            

    }
}
