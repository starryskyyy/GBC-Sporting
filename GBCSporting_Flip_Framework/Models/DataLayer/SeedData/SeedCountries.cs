using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GBCSporting_Flip_Framework.Models.DataLayer.SeedData
{
    internal class SeedCountries : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> entity)
        {
            entity.HasData(

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
        }
    }
}
