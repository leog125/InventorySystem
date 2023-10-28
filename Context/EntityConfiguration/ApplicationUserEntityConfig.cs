using Context.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Context.EntityConfiguration
{
    internal class ApplicationUserEntityConfig : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.Property(x => x.Names).HasMaxLength(80);
            builder.Property(x => x.Surnames).HasMaxLength(80);
            builder.Property(x => x.Address).HasMaxLength(80);
            builder.Property(x => x.City).HasMaxLength(80);
            builder.Property(x => x.Country).HasMaxLength(80);
        }
    }
}
