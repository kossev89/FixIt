using FixIt.Infrastructure.Data.Models;
using FixIt.Infrastructure.Data.Seed;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixIt.Infrastructure.Data.Configuration
{
    internal class TechnicianConfiguration : IEntityTypeConfiguration<Technician>
    {
        public void Configure(EntityTypeBuilder<Technician> builder)
        {
            var data = new SeedData();
            builder.HasData(new Technician[] { data.FirstTechnician, data.SecondTechnician, data.ThirdTechnician });
        }
    }
}
