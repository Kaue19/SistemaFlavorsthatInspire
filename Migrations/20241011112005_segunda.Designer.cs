﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SistemaFlavorsThatInspire.Models;

#nullable disable

namespace SistemaFlavorsThatInspire.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20241011112005_segunda")]
    partial class segunda
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SistemaFlavorsThatInspire.Models.Categoria", b =>
                {
                    b.Property<int>("CategoriaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CategoriaId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoriaId"));

                    b.Property<string>("CategoriaNome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("CategoriaNome");

                    b.HasKey("CategoriaId");

                    b.ToTable("Categoria");
                });

            modelBuilder.Entity("SistemaFlavorsThatInspire.Models.Pedido", b =>
                {
                    b.Property<int>("PedidoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PedidoId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PedidoId"));

                    b.Property<double>("PrecoPedido")
                        .HasColumnType("float")
                        .HasColumnName("PrecoPedido");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("PedidoId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Pedido");
                });

            modelBuilder.Entity("SistemaFlavorsThatInspire.Models.PedidoProduto", b =>
                {
                    b.Property<int>("PedidoProdutoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PedidoProdutoId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PedidoProdutoId"));

                    b.Property<int>("PedidoId")
                        .HasColumnType("int");

                    b.Property<int>("ProdutoId")
                        .HasColumnType("int");

                    b.HasKey("PedidoProdutoId");

                    b.HasIndex("PedidoId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("PedidoProduto");
                });

            modelBuilder.Entity("SistemaFlavorsThatInspire.Models.Produto", b =>
                {
                    b.Property<int>("ProdutoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ProdutoId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProdutoId"));

                    b.Property<int>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<double>("ProdutoDesconto")
                        .HasColumnType("float")
                        .HasColumnName("ProdutoDesconto");

                    b.Property<string>("ProdutoDescricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ProdutoDescricao");

                    b.Property<string>("ProdutoNome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ProdutoNome");

                    b.Property<double>("ProdutoPreco")
                        .HasColumnType("float")
                        .HasColumnName("ProdutoPreco");

                    b.HasKey("ProdutoId");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Produto");
                });

            modelBuilder.Entity("SistemaFlavorsThatInspire.Models.StatusDaEntrega", b =>
                {
                    b.Property<int>("StatusDaEntregaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("StatusDaEntregaId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StatusDaEntregaId"));

                    b.Property<DateTime>("DataEntrega")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataEntrega");

                    b.Property<DateTime>("DataSaida")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataSaida");

                    b.Property<int>("PedidoId")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("StatusDaEntregaId");

                    b.HasIndex("PedidoId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("StatusDaEntrega");
                });

            modelBuilder.Entity("SistemaFlavorsThatInspire.Models.Usuario", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("UsuarioId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UsuarioId"));

                    b.Property<string>("ConfirmarSenha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ConfirmarSenha");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Email");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Endereco");

                    b.Property<string>("NomeUsuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("NomeUsuario");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Senha");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Telefone");

                    b.HasKey("UsuarioId");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("SistemaFlavorsThatInspire.Models.Pedido", b =>
                {
                    b.HasOne("SistemaFlavorsThatInspire.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("SistemaFlavorsThatInspire.Models.PedidoProduto", b =>
                {
                    b.HasOne("SistemaFlavorsThatInspire.Models.Pedido", "Pedido")
                        .WithMany()
                        .HasForeignKey("PedidoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SistemaFlavorsThatInspire.Models.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pedido");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("SistemaFlavorsThatInspire.Models.Produto", b =>
                {
                    b.HasOne("SistemaFlavorsThatInspire.Models.Categoria", "Categoria")
                        .WithMany()
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("SistemaFlavorsThatInspire.Models.StatusDaEntrega", b =>
                {
                    b.HasOne("SistemaFlavorsThatInspire.Models.Pedido", "Pedido")
                        .WithMany()
                        .HasForeignKey("PedidoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SistemaFlavorsThatInspire.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pedido");

                    b.Navigation("Usuario");
                });
#pragma warning restore 612, 618
        }
    }
}
