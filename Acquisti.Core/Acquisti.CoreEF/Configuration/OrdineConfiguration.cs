using Acquisti.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Acquisti.CoreEF
{
    public class OrdineConfiguration : IEntityTypeConfiguration<Ordine>
    {
        public void Configure(EntityTypeBuilder<Ordine> builder)
        {
            builder.HasKey(l => l.ID);
            builder.Property(l => l.DataOrdine).IsRequired();
            builder.Property(l => l.DataOrdine).IsRequired();
            builder.Property(l => l.CodiceOrdine).HasMaxLength(8).IsRequired();
            builder.Property(l => l.CodiceProdotto).HasMaxLength(12).IsRequired();
            builder.Property(l => l.Importo).IsRequired();
            builder.HasOne(l => l.Cliente).WithMany(b => b.Ordini);
        }
    }
}
