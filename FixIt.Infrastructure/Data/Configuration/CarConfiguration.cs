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
    internal class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            var data = new SeedData();
            builder.HasData(new Car[] { data.FirstCar, data.SecondCar });
        }
    }
}
