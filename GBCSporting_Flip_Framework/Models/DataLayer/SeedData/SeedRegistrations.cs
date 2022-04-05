using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GBCSporting_Flip_Framework.Models.DataLayer.SeedData
{
  
    internal class SeedRegistrations : IEntityTypeConfiguration<Registration>
    {
        public void Configure(EntityTypeBuilder<Registration> entity)
        {
            entity.HasData(

                new Registration { CustomerId = 1, ProductId = 1, },
                new Registration { CustomerId = 2, ProductId = 2, }

            );
        }
    }
}
