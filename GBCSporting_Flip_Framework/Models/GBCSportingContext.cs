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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().HasData(
                new Country { CountryId = 1, CountryName = "Austria" },
                new Country { CountryId = 2, CountryName = "Canada" },
                new Country { CountryId = 3, CountryName = "France" },
                new Country { CountryId = 4, CountryName = "Germany" },
                new Country { CountryId = 5, CountryName = "India" },
                new Country { CountryId = 6, CountryName = "Iran" },
                new Country { CountryId = 7, CountryName = "Italy" },
                new Country { CountryId = 8, CountryName = "Lithuania" },
                new Country { CountryId = 9, CountryName = "Mexico" },
                new Country { CountryId = 10, CountryName = "New Zealand" },
                new Country { CountryId = 11, CountryName = "Russia" },
                new Country { CountryId = 12, CountryName = "Singapore" },
                new Country { CountryId = 13, CountryName = "Turkey" },
                new Country { CountryId = 14, CountryName = "United States" },
                new Country { CountryId = 15, CountryName = "Vietnam" }

                );

            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    CustomerId = 1,
                    FirstName = "Elizaveta",
                    LastName = "Vygovskaia",
                    Address = "67 Tikhvinskaya street",
                    City = "Moscow",
                    State = "Moskovskaya oblast",
                    PostalCode = "140002",
                    CountryId = 11,
                    CustEmail = "elizaveta.vygovskaia@georgebrown.ca",
                    CustPhone = "+7(943)234-1234"

                },
                new Customer
                {
                    CustomerId = 2,
                    FirstName = "Jordon",
                    LastName = "Jensen",
                    Address = "3852 Eglinton Avenue",
                    City = "Toronto",
                    State = "Ontario",
                    PostalCode = "M4P 1A6",
                    CountryId = 2,
                    CustEmail = "jordon.jensen@georgebrown.ca",
                    CustPhone = "+1(506)312-9547"

                },
                new Customer
                {
                    CustomerId = 3,
                    FirstName = "Phuong",
                    LastName = "Hoang",
                    Address = "532 Hoang Hoa Tham",
                    City = "Ha Noi",
                    State = "Hanoi",
                    PostalCode = "901011",
                    CountryId = 15,
                    CustEmail = "phuong.hoang2@georgebrown.ca",
                    CustPhone = "+94(564)123-1234"

                },
                new Customer
                {
                    CustomerId = 4,
                    FirstName = "Truong",
                    LastName = "Thi Bui",
                    Address = "3422 Bay Street",
                    City = "Toronto",
                    State = "Ontario",
                    PostalCode = "M5J 2R8",
                    CountryId = 2,
                    CustEmail = "truongthi.bui@georgebrown.ca",
                    CustPhone = "+1(647)893-3833"

                }
                );

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    ProductId = 1,
                    Code = "H332K",
                    Name = "Draft Manager 1.0",
                    YearlyPrice = 6.65,
                    ReleaseDate = DateTime.Now
                },

                new Product
                {
                    ProductId = 2,
                    Code = "TVE32",
                    Name = "League Scheduler 1.0",
                    YearlyPrice = 5.54,
                    ReleaseDate = DateTime.Now
                }

                );

            modelBuilder.Entity<Incident>().HasData(
                new Incident
                {
                    IncidentId = 1,
                    CustomerId = 2,
                    ProductId = 2,
                    Title = "Could not install",
                    Description = "When trying to install getting error 123",
                    TechnicianId = 1,
                    DateClosed = DateTime.Now
                },
                new Incident
                {
                    IncidentId = 2,
                    CustomerId = 1,
                    ProductId = 1,
                    Title = "Error launching program",
                    Description = "Program crash almost instantly when I open it",
                    TechnicianId = 2,
                    DateClosed = DateTime.Now
                }
                );

            modelBuilder.Entity<Technician>().HasData(
                new Technician
                {
                    TechnicianId = 1,
                    TechName = "Samuel Brooks",
                    TechEmail = "sam.brooks@gmail.com",
                    TechPhone = "+1(342)234-4223"
                },
                new Technician
                {
                    TechnicianId = 2,
                    TechName = "Richard Pharo",
                    TechEmail = "r.pharo@gmail.com",
                    TechPhone = "+1(542)112-4367"
                }
                );


        }
    }
}
