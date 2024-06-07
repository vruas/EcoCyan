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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseOracle("Data Source=oracle.fiap.com.br:1521/orcl;User ID=rm550871;Password=310303;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<EntregaLixo>(entity =>
            {
                entity.HasKey(e => e.IdEntregaLixo);
                entity.Property(e => e.IdEntregaLixo).HasColumnName("id_entrega_lixo");
                entity.Property(e => e.DataEntrega).HasColumnName("dt_entrega");
                entity.Property(e => e.IdLixoColetado).HasColumnName("lixo_coletado_id_lixo_coletado");
                entity.Property(e => e.IdUser).HasColumnName("lixo_coletado_id_user");
                entity.HasOne(d => d.lixoColetado)
                    .WithMany(p => p.EntregaLixo)
                    .HasForeignKey(d => d.IdLixoColetado);
                entity.HasOne(d => d.User)
                    .WithMany(p => p.EntregaLixo)
                    .HasForeignKey(d => d.IdUser);
            });

            modelBuilder.Entity<LixoColetado>(entity =>
            {
                entity.HasKey(e => e.IdLixoColetado);
                entity.Property(e => e.IdLixoColetado).HasColumnName("id_lixo_coletado");
                entity.Property(e => e.TipoLixo).HasColumnName("tp_lixo");
                entity.Property(e => e.QuantidadeLixo).HasColumnName("quantidade_lixo");
                entity.Property(e => e.LocalColeta).HasColumnName("local_coleta");
                entity.Property(e => e.IdUser).HasColumnName("usuarios_id_user");
                entity.HasOne(d => d.User)
                    .WithMany(p => p.LixoColetado)
                    .HasForeignKey(d => d.IdUser);
            });

            modelBuilder.Entity<PontoDeColeta>(entity =>
            {
                entity.HasKey(e => e.IdPontoColeta);
                entity.Property(e => e.IdPontoColeta).HasColumnName("id_ponto_coleta");
                entity.Property(e => e.NomePontoColeta).HasColumnName("nm_ponto_coleta");
                entity.Property(e => e.EnderecoPontoColeta).HasColumnName("endereco_ponto_coleta");
            });

            modelBuilder.Entity<Reciclagem>(entity =>
            {
                entity.HasKey(e => e.IdReciclagem);
                entity.Property(e => e.IdReciclagem).HasColumnName("id_reciclagem");
                entity.Property(e => e.DataReciclagem).HasColumnName("dt_reciclagem");
                entity.Property(e => e.QuantidadeReciclada).HasColumnName("quantidade_reciclada");
                entity.Property(e => e.IdUser).HasColumnName("usuarios_id_user");
                entity.HasOne(d => d.User)
                    .WithMany(p => p.Reciclagems)
                    .HasForeignKey(d => d.IdUser);
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.IdUser);
                entity.Property(e => e.IdUser).HasColumnName("id_user");
                entity.Property(e => e.NomeUser).HasColumnName("nm_user");
                entity.Property(e => e.EmailUser).HasColumnName("email_user");
                entity.Property(e => e.SenhaUser).HasColumnName("senha_user");
                entity.Property(e => e.TipoUser).HasColumnName("tipo_user");
            });
        }
    }
}
