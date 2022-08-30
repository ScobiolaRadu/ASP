using Microsoft.EntityFrameworkCore;
using ProiectOpt.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ProiectOpt.Data
{
    public class DataContext : IdentityDbContext<IdentityUser>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
             
        }

        public DbSet<Categorie> categories { get; set; }
        public DbSet<Client> clients { get; set; }
        public DbSet<ComandaClient> comandaClients { get; set; }
        public DbSet<Fabricant> fabricants { get; set; }    
        public DbSet<Instrument> instruments { get; set; } 
        public DbSet<Item> items { get; set; }
        public DbSet<ItemComanda> itemComandas { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
