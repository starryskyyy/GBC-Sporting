using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GBCSporting_Flip_Framework.Models.DataLayer.SeedData
{
    internal class SeedCustomers : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> entity)
        {
            entity.HasData(
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
        }
    }
}
