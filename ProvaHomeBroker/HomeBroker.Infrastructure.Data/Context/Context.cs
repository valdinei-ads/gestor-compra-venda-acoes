using HomeBroker.Domain.Model;
using HomeBroker.Infrastructure.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace HomeBroker.Infrastructure.Data.Context
{
    public class DataContext : DbContext
    {
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Ordem> Ordem { get; set; }
        public DbSet<CotacaoAcao> CotacaoAcao { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClienteMap());
            modelBuilder.ApplyConfiguration(new CotacaoAcaoMap());
            modelBuilder.ApplyConfiguration(new OrdemMap());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // get the configuration from the app settings
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseSqlite(config.GetConnectionString("DefaultConnection"));
        }

        public override int SaveChanges()
        {
            //foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("Cadastro") != null))
            //{
            //    if (entry.State == EntityState.Added)
            //        entry.Property("Cadastro").CurrentValue = DateTime.Now;
            //
            //    if (entry.State == EntityState.Modified)
            //    {
            //        entry.Property("Cadastro").IsModified = false;
            //        entry.Property("Alteracao").CurrentValue = DateTime.Now;
            //    }
            //}

            return base.SaveChanges();
        }
    }
}