using GBCSporting_Flip_Framework.Models.DataLayer.SeedData;
using Microsoft.EntityFrameworkCore;

namespace GBCSporting_Flip_Framework.Models
{
    public class GBCSportingContext : DbContext
    {
        public GBCSportingContext(DbContextOptions<GBCSportingContext> options)
            : base(options) { }

        public DbSet<Country> Countries { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Incident> Incidents { get; set; }
        public DbSet<Technician> Technicians { get; set; }

        public DbSet<Registration> Registrations { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // composite primary key for registration
            modelBuilder.Entity<Registration>()
                .HasKey(cp => new {cp.CustomerId, cp.ProductId});
            // one to many between customer and registration
            modelBuilder.Entity<Registration>()
                .HasOne(c => c.Customer)
                .WithMany(cr => cr.Registrations)
                .HasForeignKey(cu => cu.CustomerId);

            // one to many between product and registration
            modelBuilder.Entity<Registration>()
                .HasOne(p => p.Product)
                .WithMany(pr => pr.Registrations)
                .HasForeignKey(prod => prod.ProductId);


            // seed initial data
            modelBuilder.ApplyConfiguration(new SeedCustomers());
            modelBuilder.ApplyConfiguration(new SeedCountries());
            modelBuilder.ApplyConfiguration(new SeedIncidents());
            modelBuilder.ApplyConfiguration(new SeedProducts());
            modelBuilder.ApplyConfiguration(new SeedRegistrations());
            modelBuilder.ApplyConfiguration(new SeedTechnicians());

         
        }
    }
}
