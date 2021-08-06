using Acquisti.Core;
using Microsoft.EntityFrameworkCore;
using System;

namespace Acquisti.CoreEF
{
    public class AcquistiContext : DbContext
    {
        public DbSet<Cliente> Clienti { get; set; }
        public DbSet<Ordine> Ordini { get; set; }

        public AcquistiContext() : base()
        {

        }

        public AcquistiContext(DbContextOptions<AcquistiContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                string connectionString = "Server=.;Database=Acquisti;Trusted_Connection=True;";
                options.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Cliente>(new ClienteConfiguration());
            modelBuilder.ApplyConfiguration<Ordine>(new OrdineConfiguration());
        }
    }
}
