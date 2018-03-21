﻿// <auto-generated />
using EFGetStarted.AspNetCore.NewDb.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Conectt.Migrations
{
    [DbContext(typeof(ConecttContext))]
    [Migration("20180321124610_ClienteDefinicoes")]
    partial class ClienteDefinicoes
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Conectt.Models.Cliente", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Celular")
                        .HasMaxLength(9);

                    b.Property<string>("CelularDdd")
                        .HasMaxLength(2);

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(11);

                    b.Property<DateTime>("DataNascimento");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<string>("Empresa")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("Idade");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<string>("TelefoneComercial")
                        .HasMaxLength(9);

                    b.Property<string>("TelefoneComercialDdd")
                        .HasMaxLength(2);

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.ToTable("Cliente");
                });
#pragma warning restore 612, 618
        }
    }
}
