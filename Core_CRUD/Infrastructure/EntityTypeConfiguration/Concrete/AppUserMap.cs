using Core_CRUD.Infrastructure.EntityTypeConfiguration.Abstract;
using Core_CRUD.Models.Entities.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_CRUD.Infrastructure.EntityTypeConfiguration.Concrete
{
    public class AppUserMap : BaseMap<AppUser>
    {
        public override void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(x => x.FirstName).HasMaxLength(10).IsRequired(true);
            builder.Property(x => x.LastName).HasMaxLength(20).IsRequired(true);
            base.Configure(builder);
        }
    }
}
