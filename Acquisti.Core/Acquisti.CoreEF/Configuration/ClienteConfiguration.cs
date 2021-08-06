using Acquisti.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Acquisti.CoreEF
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(b => b.ID);
            builder.Property(b => b.CodiceCliente).HasMaxLength(8).IsRequired();
            builder.Property(b => b.Nome).IsRequired();
            builder.Property(b => b.Cognome).IsRequired();
            builder.HasMany(b => b.Ordini).WithOne(l => l.Cliente);
        }
    }
}
