using api.portal.jenn.DTO;
using AutoMapper.Mappers;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.portal.jenn.Contexto
{
    public class CustomContext : DbContext
    {
        public CustomContext(DbContextOptions<CustomContext> option) : base(option)
        {

        }


        public DbSet<FotoEmpresa> FotoEmpresas { get; set; }
        public DbSet<Contato> Contato { get; set; }
        public DbSet<Logon> Logon { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<PagamentoProcedimentoEmpresa> PagamentoProcedimentoEmpresa { get; set; }
        public DbSet<Domicilio> Domicilios { get; set; }
        public DbSet<PlanoProcedimentoEmpresa> PlanoProcedimentoEmpresas { get; set; }
        public DbSet<Convenio> Convenios { get; set; }
        public DbSet<Plano> Planos { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Cidade> Cidades { get; set; }
        public DbSet<DTO.Pais> Pais { get; set; }

        public DbSet<DTO.CategoriaProcedimento> CategoriaProced { get; set; }
        public DbSet<DTO.TipoProcedimento> TipoProcedimento { get; set; }
        public DbSet<DTO.Procedimento> Procedimento { get; set; }
        public DbSet<DTO.ProcedimentoEmpresa> ProcedimentoEmpresa { get; set; }
        public DbSet<DTO.FotoEmpresa> FotoEmpresa { get; set; }
        public DbSet<DTO.Grupo> Grupo { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pais>(entity =>
            {
                entity.HasKey(e => e.PaisID);
                entity.Property(e => e.Nome).IsRequired();
                entity.HasMany(a => a.Ufs);
            });

            modelBuilder.Entity<Cidade>(entity =>
            {
                entity.HasKey(e => e.CidadeID);
                entity.Property(e => e.Nome).IsRequired();
                entity.HasMany(a => a.Regiao);
                entity.HasMany(a => a.Ufs);
            });


            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.ClienteID);
                entity.HasOne(a => a.Usuario).WithOne(b => b.Cliente).HasForeignKey<Usuario>(b => b.ClienteID);
            });

            modelBuilder.Entity<Procedimento>(entity =>
            {
                entity.HasKey(e => e.ProcedimentoID);
                entity.Property(e => e.Nome).IsRequired();
                entity.Property(e => e.Descricao).IsRequired();
                entity.Property(e => e.Ativo).IsRequired();
                entity.Property(e => e.ImgProduto_Proc).IsRequired();
            });


            modelBuilder.Entity<TipoProcedimento>(entity =>
            {
                entity.HasKey(e => e.TipoProcedimentoID);
                entity.Property(e => e.Nome).IsRequired();
                entity.HasOne(a => a.Categoria);
            });



            modelBuilder.Entity<Empresa>(entity =>
            {
                entity.HasKey(e => e.EmpresaID);
                entity.Property(e => e.Nome).IsRequired();
                entity.Property(e => e.cnpj).IsRequired();
                entity.Property(e => e.Telefone1).IsRequired();
                entity.Property(e => e.Ativo).IsRequired();
                entity.Property(e => e.Responsavel).IsRequired();
                entity.Property(e => e.Logradouro).IsRequired();
                entity.HasOne(k => k.Matriz);
                entity.Property(e => e.numero).IsRequired();
                entity.Property(e => e.bairro).IsRequired();
                entity.Property(e => e.cep).IsRequired();
                entity.HasOne(a => a.Grupo);
                entity.HasOne(a => a.Cidade);
                entity.HasMany(a => a.Fotos).WithOne(b => b.Empresa);
                entity.HasMany(a => a.Avaliacoes).WithOne(b => b.Empresa);
            });



            modelBuilder.Entity<ProcedimentoEmpresa>(entity =>
            {
                entity.HasKey(sc => sc.ProcedimentoEmpresaID);
                entity.HasIndex(sc => new { sc.EmpresaID, sc.ProcedimentoID }).IsUnique(true);
                entity.Property(e => e.Nome_pers).IsRequired();
                entity.Property(e => e.PrecoProduto).IsRequired();
                entity.Property(e => e.Preco_contra).IsRequired();
                entity.Property(e => e.TaxaParcelamento).IsRequired();
                entity.Property(e => e.TaxaResultado).IsRequired();
                entity.HasOne<Procedimento>(sc => sc.Procedimento).WithMany(s => s.ProcedimentoEmpresas).HasForeignKey(sc => sc.ProcedimentoID);
                entity.HasOne<Empresa>(sc => sc.Empresa).WithMany(s => s.ProcedimentoEmpresas).HasForeignKey(sc => sc.EmpresaID);
                entity.HasMany(a => a.ProcedimentoPerguntas).WithOne(b => b.ProcedimentoEmpresa);
                entity.HasMany(a => a.PagamentoProcedimentoEmpresas).WithOne(b => b.ProcedimentoEmpresa);
            });

            modelBuilder.Entity<Convenio>(entity =>
            {
                entity.HasKey(e => e.ConvenioId);
                entity.Property(e => e.Nome).IsRequired();
                entity.Property(e => e.Ativo).IsRequired();
                entity.Property(e => e.DataInclusao).IsRequired();
                entity
                    .HasMany(e => e.Planos)
                    .WithOne(e => e.Convenio)
                    .OnDelete(DeleteBehavior.SetNull);
            });



        }
    }
}
