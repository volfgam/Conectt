using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Conectt.Models
{
    public class Cliente: Conectt.Data.Entities.Cliente
    {
        public static void Setup(ModelBuilder builder)
        {
            builder.Entity<Cliente>().ToTable("Cliente");
            builder.Entity<Cliente>().HasKey(x => x.Id);
            builder.Entity<Cliente>().HasIndex(x => x.Id);
            builder.Entity<Cliente>().Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Entity<Cliente>()
                .Property(x => x.Nome)
                .IsRequired(true)
                .HasMaxLength(250);

            builder.Entity<Cliente>()
                .Property(x => x.Cpf)
                .IsRequired(true)
                .HasMaxLength(11);

            builder.Entity<Cliente>()
                .Property(x => x.DataNascimento)
                .IsRequired(true);

            builder.Entity<Cliente>()
                .Property(x => x.Email)
                .IsRequired(true)
                .HasMaxLength(150);

            builder.Entity<Cliente>()
                .Property(x => x.Empresa)
                .IsRequired(true)
                .HasMaxLength(50);

            builder.Entity<Cliente>()
                .Property(x => x.TelefoneComercialDdd)
                .IsRequired(false)
                .HasMaxLength(2);

            builder.Entity<Cliente>()
                .Property(x => x.TelefoneComercial)
                .IsRequired(false)
                .HasMaxLength(9);

            builder.Entity<Cliente>()
                .Property(x => x.CelularDdd)
                .IsRequired(false)
                .HasMaxLength(2);

            builder.Entity<Cliente>()
                .Property(x => x.Celular)
                .IsRequired(false)
                .HasMaxLength(9);
        }
    }
}
