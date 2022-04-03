using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GBCSporting_Flip_Framework.Models.DataLayer.SeedData
{
  
    internal class SeedTechnicians : IEntityTypeConfiguration<Technician>
    {
        public void Configure(EntityTypeBuilder<Technician> entity)
        {
            entity.HasData(

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
