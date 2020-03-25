using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Template.API.Data.Entities;
using System;

namespace Template.API.Data.Contexts
{
    public class Context : DbContext
    {
        public Context()
        {

        }

        public Context(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Example> Example { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
               .SetBasePath(AppContext.BaseDirectory)
               .AddJsonFile("appsettings.json", optional: true)
               .Build();

            optionsBuilder.UseSqlServer(config["ConnectionString:Template.API"]);

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.Entity<Example>()
            //    .HasIndex(u => u.SerialNumber)
            //    .IsUnique();
        }
    }
}