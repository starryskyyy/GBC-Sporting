using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GBCSporting_Flip_Framework.Models.DataLayer.SeedData
{
    internal class SeedIncidents : IEntityTypeConfiguration<Incident>
    {
        public void Configure(EntityTypeBuilder<Incident> entity)
        {
            entity.HasData(

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
        }
    }
}
