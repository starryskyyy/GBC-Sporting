using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GBCSporting_Flip_Framework.Models.DataLayer.SeedData
{
    internal class SeedProducts : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> entity)
        {
            entity.HasData(

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
        }
    }
}
