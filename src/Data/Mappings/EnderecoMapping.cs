using Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Mappings
{
    public class EnderecoMapping : IEntityTypeConfiguration<Endereco>
    {
        public void Configure( EntityTypeBuilder<Endereco> builder )
        {
            builder.HasKey(e => e.Id);

            builder.Property(p => p.Logradouro)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(p => p.Numero)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(p => p.Cep)
                .IsRequired()
                .HasColumnType("varchar(8)");

            builder.Property(p => p.Complemento)
                .IsRequired()
                .HasColumnType("varchar(250)");

            builder.Property(p => p.Bairro)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(p => p.Cidade)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(p => p.Estado)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.ToTable("Enderecos");
        }
    }
}
