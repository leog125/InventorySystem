using Context.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Context.EntityConfiguration
{
    internal class InventatyEntityConfig : IEntityTypeConfiguration<Inventary>
    {
        public void Configure(EntityTypeBuilder<Inventary> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.InitialDate).IsRequired();
            builder.Property(x => x.FinalDate).IsRequired();
            builder.Property(x => x.State).IsRequired();

            //Relations
            builder.HasOne(x => x.ApplicationUser).WithMany()
                .HasForeignKey(x => x.ApplicationUserId);
            builder.HasOne(x => x.Winery).WithMany()
                .HasForeignKey(x => x.WineryId);
        }
    }
}
