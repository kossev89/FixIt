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
    internal class ServiceHistoryConfiguration : IEntityTypeConfiguration<ServiceHistory>
    {
        public void Configure(EntityTypeBuilder<ServiceHistory> builder)
        {
            var data = new SeedData();
            builder.HasData(data.FirstCarHistory);
        }
    }
}
