using HuellasAutomarkAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuellasAutomarkAPI.Infrastructure.Persistence
{
    public class HuellasAutomarkDbContext : DbContext
    {
        public HuellasAutomarkDbContext(DbContextOptions<HuellasAutomarkDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Add any custom configurations here
            modelBuilder.Entity<Dashboard>()
                .HasNoKey();
        }
        // DbSet Entities
        public DbSet<Client> Clients { get; set; }
        public DbSet<Campaign> Campaign { get; set; }
        public DbSet<Channel> Channel { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<ClientCampaign> ClientCampaign { get; set; }
        public DbSet<Gender> Gender { get; set; }
        public DbSet<State> State { get; set; }
        public DbSet<Dashboard> Dashboard { get; set; }
    }
}
