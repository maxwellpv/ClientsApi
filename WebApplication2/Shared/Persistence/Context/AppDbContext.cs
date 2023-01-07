using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebApplication2.DomainClients.Domain.Models;

namespace WebApplication2.Shared.Persistence.Context
{
    public class AppDbContext : DbContext
    {
        protected readonly IConfiguration _configuration;

        public AppDbContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }
        
        public DbSet<Client> Clients { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            //Clients
            builder.Entity<Client>().ToTable("Clients");
            builder.Entity<Client>().HasKey(c=>c.Id);
            builder.Entity<Client>().Property(c=>c.Id).ValueGeneratedOnAdd();
            builder.Entity<Client>().Property(c => c.Dni).IsRequired();
            builder.Entity<Client>().Property(c => c.FirstName).IsRequired();
            builder.Entity<Client>().Property(c => c.LastName).IsRequired();
            builder.Entity<Client>().Property(c => c.Address).IsRequired();

            builder.Entity<Client>().HasData(
                new Client
                {
                    Id= 1,
                    Dni = "12345678",
                    FirstName = "Manuel",
                    LastName = "Prado",
                    Address = "St. 10"
                },
                new Client
                {
                    Id= 2,
                    Dni = "12345678",
                    FirstName = "Manuela",
                    LastName = "Smith",
                    Address = "St. 10"
                }
                );

        }
        
    }
}