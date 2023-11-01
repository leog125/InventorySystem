using Context.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Context.EntityConfiguration
{
    internal class InventatyDetailEntityConfig : IEntityTypeConfiguration<InventaryDetail>
    {
        public void Configure(EntityTypeBuilder<InventaryDetail> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.StockPrevious).IsRequired();
            builder.Property(x => x.Amount).IsRequired();

            //Relations
            builder.HasOne(x => x.Inventary).WithMany()
                .HasForeignKey(x => x.InventaryId);
            builder.HasOne(x => x.Product).WithMany()
                .HasForeignKey(x => x.ProductId);
        }
    }
}
