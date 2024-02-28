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
    internal class ServiceConfiguration : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            var data = new SeedData();
            builder.HasData(new Service[] 
            {data.TireRotation, data.OilChange, data.Paint, data.BodyRepair , data.EngineRepair, data.Diagnostics });
        }
    }
}
