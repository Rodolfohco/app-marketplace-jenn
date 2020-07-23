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
    public class CustomContext : IdentityDbContext<Logon>
    {
        public CustomContext(DbContextOptions<CustomContext> option) : base(option)
        {

        }



        public DbSet<Convenio> Convenios { get; set; }
        public DbSet<Plano> Planos { get; set; }
        public DbSet<Empresa> Empresas { get; set; }

        public DbSet<Cidade> Cidades { get; set; }
        public DbSet<DTO.Logon> logons { get; set; }

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
                entity.HasMany(a => a.Ufs).WithOne(b => b.Pais);
            });

            modelBuilder.Entity<Cidade>(entity =>
            {
                entity.HasKey(e => e.CidadeID);
                entity.Property(e => e.Nome).IsRequired();
                entity.HasMany(a => a.Regiao).WithOne(b => b.cidade);
                entity.HasMany(a => a.Ufs).WithOne(b => b.cidade);

            });


            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.ClienteID);
                entity.HasOne(a => a.Usuario).WithOne(b => b.Cliente).HasForeignKey<Usuario>(b => b.ClienteID);

            });

            modelBuilder.Entity<Procedimento>(entity =>
            {
                entity.HasKey(e => e.ProcedimentiID);
                entity.Property(e => e.Nome).IsRequired();
                entity.Property(e => e.Descricao).IsRequired();
                entity.Property(e => e.Ativo).IsRequired();
                entity.Property(e => e.ImgProduto_Proc).IsRequired();
                entity.HasOne(a => a.TipoProcedimento)
                .WithOne(b => b.Procedimento)
                .HasForeignKey<TipoProcedimento>(b => b.ProcedimentoID);
            });


            modelBuilder.Entity<TipoProcedimento>(entity =>
            {
                entity.HasKey(e => e.TipoProcedimentoID);
                entity.Property(e => e.Nome).IsRequired();

                entity.HasOne(a => a.Categoria)
                .WithOne(b => b.TipoCategoria)
                .HasForeignKey<CategoriaProcedimento>(b => b.CategoriaID);
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
            
            entity.HasMany(k => k.Filiais)
              .WithOne()
              .HasForeignKey(k => k.MatrizID)
              .HasPrincipalKey(k => k.EmpresaID);


            entity.Property(e => e.numero).IsRequired();
            entity.Property(e => e.bairro).IsRequired();
            entity.Property(e => e.cep).IsRequired();

  
            entity.HasOne(a => a.Grupo).WithOne(b => b.Empresa).HasForeignKey<Grupo>(b => b.EmpresaID);
            entity.HasMany(a => a.Cidades).WithOne(b => b.Empresa);
            entity.HasMany(a => a.Fotos).WithOne(b => b.Empresa);
            entity.HasMany(a => a.Avaliacoes).WithOne(b => b.Empresa);
        });



            modelBuilder.Entity<ProcedimentoEmpresa>(entity =>
            {
            entity.HasKey(e => e.ProcedimentoEmpresaID);
            entity.HasKey(sc => new { sc.EmpresaID, sc.ProcedimentoID });

            entity.Property(e => e.Nome_pers).IsRequired();
            entity.Property(e => e.PrecoProduto).IsRequired();
            entity.Property(e => e.Preco_contra).IsRequired();
            entity.Property(e => e.TaxaParcelamento).IsRequired();
            entity.Property(e => e.TaxaResultado).IsRequired();



                entity.HasOne<Procedimento>(sc => sc.Procedimento)
                .WithMany(s => s.ProcedimentoEmpresas)
                .HasForeignKey(sc => sc.ProcedimentoID);


                entity.HasOne<Empresa>(sc => sc.Empresa)
                .WithMany(s => s.ProcedimentoEmpresas)
                .HasForeignKey(sc => sc.EmpresaID);



                entity.HasMany(a => a.ProcedimentoPerguntas).WithOne(b => b.ProcedimentoEmpresa);
                entity.HasMany(a => a.PagamentoProcedimentoEmpresas).WithOne(b => b.ProcedimentoEmpresa);

                //entity.HasOne(a => a.PlanoProcedimentoEmpresas).WithOne(b => b.ProcedimentoEmpresa)
                //    .HasForeignKey<PlanoProcedimentoEmpresa>(b => b.ProcedimentoEmpresaID);



            });










            modelBuilder.Entity<Convenio>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Nome).IsRequired();
                entity.Property(e => e.Ativo).IsRequired();
                entity.Property(e => e.DataInclusao).IsRequired();
                entity
                    .HasMany(e => e.Planos)
                    .WithOne(e => e.Convenio)
                    .OnDelete(DeleteBehavior.SetNull);
            });





            //modelBuilder.Entity<Empresa>(entity =>
            //{
            //    entity.HasKey(e => e.EmpresaID);
            //    entity.Property(e => e.Nome).IsRequired();
            //    entity
            //        .HasMany(e => e.Unidade)
            //        .WithOne(e => e.Empresa)
            //        .OnDelete(DeleteBehavior.SetNull);
            //});

            //modelBuilder.Entity<Unidade>(entity =>
            //{
            //    entity.HasKey(e => e.UnidadeID);
            //    entity.Property(e => e.Nome).IsRequired();
            //    entity
            //        .HasOne(e => e.Empresa)
            //        .WithMany(c => c.Unidade);

            //    entity
            //        .HasMany(e => e.Cidades)
            //        .WithOne(e => e.Unidade)
            //        .OnDelete(DeleteBehavior.SetNull);
            //});


            //modelBuilder.Entity<Cidade>(entity =>
            //{
            //    entity.HasKey(e => e.CidadeID);
            //    entity.Property(e => e.Nome).IsRequired();
            //    entity.Property(e => e.UF).IsRequired();
            //    entity
            //        .HasOne(e => e.Unidade)
            //        .WithMany(c => c.Cidades);
            //});



            //modelBuilder.Entity<Produto>(entity =>
            //{
            //    entity.HasKey(e => e.ProdutoID);

            //    entity.HasOne(u => u.Unidade)
            //    .WithMany(u => u.Produtos)
            //    .OnDelete(DeleteBehavior.SetNull);
            //    entity.HasOne(u => u.Cidade)
            //    .WithMany(u => u.Produtos)
            //    .OnDelete(DeleteBehavior.SetNull);
            //});





            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.UsuarioID);

                entity.HasOne(a => a.logon)
                .WithOne(b => b.Usuario)
                .HasForeignKey<Logon>(b => b.UsuarioID);
            });




            base.OnModelCreating(modelBuilder);
        }


    }
}
