﻿// <auto-generated />
using System;
using ContaPagar.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ContaPagar.Infra.Data.Migrations
{
    [DbContext(typeof(ContaPagarContext))]
    [Migration("20201207021315_CreateDatabaseContaPagar")]
    partial class CreateDatabaseContaPagar
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("ContaPagar.Domain.Models.ContaPagar", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<DateTime>("DataPagamento")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataVencimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("QuantidadeDiasEmAtraso")
                        .HasColumnType("int");

                    b.Property<decimal>("ValorCorrigido")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ValorOriginal")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("ContasPagar");
                });

            modelBuilder.Entity("ContaPagar.Domain.Models.RegraContaPagarJurosMulta", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<decimal>("JurosAoDia")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Multa")
                        .HasColumnType("decimal(18,2)");

                    b.Property<byte>("TipoRegra")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.ToTable("RegrasContaPagarJurosMulta");
                });
#pragma warning restore 612, 618
        }
    }
}
