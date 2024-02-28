using FixIt.Infrastructure.Data.Seed;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixIt.Infrastructure.Data.Configuration
{
    internal class UserConfiguration : IEntityTypeConfiguration<IdentityUser>
    {
        public void Configure(EntityTypeBuilder<IdentityUser> builder)
        {
            var data = new SeedData();
            builder.HasData(new IdentityUser[] { data.AdminUser, data.CustomerUser });
        }
    }
}
