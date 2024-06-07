﻿// <auto-generated />
using EcoCyan.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;

#nullable disable

namespace EcoCyan.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EcoCyan.Models.EntregaLixo", b =>
                {
                    b.Property<int>("IdEntregaLixo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("id_entrega_lixo");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdEntregaLixo"));

                    b.Property<string>("DataEntrega")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("NVARCHAR2(10)")
                        .HasColumnName("dt_entrega");

                    b.Property<int>("IdLixoColetado")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("lixo_coletado_id_lixo_coletado");

                    b.Property<int>("IdUser")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("lixo_coletado_id_user");

                    b.HasKey("IdEntregaLixo");

                    b.HasIndex("IdLixoColetado");

                    b.HasIndex("IdUser");

                    b.ToTable("entrega_lixo");
                });

            modelBuilder.Entity("EcoCyan.Models.LixoColetado", b =>
                {
                    b.Property<int>("IdLixoColetado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("id_lixo_coletado");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdLixoColetado"));

                    b.Property<int>("IdUser")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("usuarios_id_user");

                    b.Property<string>("LocalColeta")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("NVARCHAR2(150)")
                        .HasColumnName("local_coleta");

                    b.Property<string>("QuantidadeLixo")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("NVARCHAR2(10)")
                        .HasColumnName("quantidade_lixo");

                    b.Property<string>("TipoLixo")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("NVARCHAR2(15)")
                        .HasColumnName("tp_lixo");

                    b.HasKey("IdLixoColetado");

                    b.HasIndex("IdUser");

                    b.ToTable("lixo_coletado");
                });

            modelBuilder.Entity("EcoCyan.Models.PontoDeColeta", b =>
                {
                    b.Property<int>("IdPontoColeta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("id_ponto_coleta");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPontoColeta"));

                    b.Property<string>("ContatoPontoColeta")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("NVARCHAR2(150)")
                        .HasColumnName("contato_ponto_col");

                    b.Property<string>("EnderecoPontoColeta")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("NVARCHAR2(150)")
                        .HasColumnName("endereco_ponto_coleta");

                    b.Property<int>("EntregaLixoIdEntregaLixo")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("IdEntregaLixo")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("NomePontoColeta")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("NVARCHAR2(30)")
                        .HasColumnName("nm_ponto_coleta");

                    b.HasKey("IdPontoColeta");

                    b.HasIndex("EntregaLixoIdEntregaLixo");

                    b.ToTable("ponto_de_coleta");
                });

            modelBuilder.Entity("EcoCyan.Models.Reciclagem", b =>
                {
                    b.Property<int>("IdReciclagem")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("id_reciclagem");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdReciclagem"));

                    b.Property<string>("DataReciclagem")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("NVARCHAR2(10)")
                        .HasColumnName("dt_reciclagem");

                    b.Property<int>("IdUser")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("usuarios_id_user");

                    b.Property<string>("QuantidadeReciclada")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("NVARCHAR2(10)")
                        .HasColumnName("quantidade_reciclada");

                    b.HasKey("IdReciclagem");

                    b.HasIndex("IdUser");

                    b.ToTable("reciclagem");
                });

            modelBuilder.Entity("EcoCyan.Models.Usuarios", b =>
                {
                    b.Property<int>("IdUser")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("id_user");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUser"));

                    b.Property<string>("EmailUser")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("NVARCHAR2(150)")
                        .HasColumnName("email_user");

                    b.Property<string>("NomeUser")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR2(50)")
                        .HasColumnName("nm_user");

                    b.Property<string>("SenhaUser")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("NVARCHAR2(30)")
                        .HasColumnName("senha_user");

                    b.Property<string>("TipoUser")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("NVARCHAR2(10)")
                        .HasColumnName("tipo_user");

                    b.HasKey("IdUser");

                    b.ToTable("usuarios");
                });

            modelBuilder.Entity("EcoCyan.Models.EntregaLixo", b =>
                {
                    b.HasOne("EcoCyan.Models.LixoColetado", "lixoColetado")
                        .WithMany("EntregaLixo")
                        .HasForeignKey("IdLixoColetado")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EcoCyan.Models.Usuarios", "User")
                        .WithMany("EntregaLixo")
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");

                    b.Navigation("lixoColetado");
                });

            modelBuilder.Entity("EcoCyan.Models.LixoColetado", b =>
                {
                    b.HasOne("EcoCyan.Models.Usuarios", "User")
                        .WithMany("LixoColetado")
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("EcoCyan.Models.PontoDeColeta", b =>
                {
                    b.HasOne("EcoCyan.Models.EntregaLixo", "EntregaLixo")
                        .WithMany("PontoDeColeta")
                        .HasForeignKey("EntregaLixoIdEntregaLixo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EntregaLixo");
                });

            modelBuilder.Entity("EcoCyan.Models.Reciclagem", b =>
                {
                    b.HasOne("EcoCyan.Models.Usuarios", "User")
                        .WithMany("Reciclagems")
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("EcoCyan.Models.EntregaLixo", b =>
                {
                    b.Navigation("PontoDeColeta");
                });

            modelBuilder.Entity("EcoCyan.Models.LixoColetado", b =>
                {
                    b.Navigation("EntregaLixo");
                });

            modelBuilder.Entity("EcoCyan.Models.Usuarios", b =>
                {
                    b.Navigation("EntregaLixo");

                    b.Navigation("LixoColetado");

                    b.Navigation("Reciclagems");
                });
#pragma warning restore 612, 618
        }
    }
}
