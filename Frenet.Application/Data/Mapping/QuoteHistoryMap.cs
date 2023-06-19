using Frenet.Application.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Frenet.Application.Data.Mapping
{
    public class QuoteHistoryMap : IEntityTypeConfiguration<QuoteHistory>
    {
        public void Configure(EntityTypeBuilder<QuoteHistory> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(X => X.SellerCEP).IsRequired().HasMaxLength(10);
            builder.Property(X => X.Carrier).IsRequired().HasMaxLength(250);
            builder.Property(X => X.CarrierCode).IsRequired().HasMaxLength(100);
            builder.Property(X => X.DeliveryTime).IsRequired().HasMaxLength(10);
            builder.Property(X => X.ServiceCode).IsRequired().HasMaxLength(100);
            builder.Property(X => X.ServiceDescription).IsRequired().HasMaxLength(1000);
            builder.Property(X => X.ShippingPrice).IsRequired().HasMaxLength(100);
            builder.Property(X => X.OriginalDeliveryTime).IsRequired().HasMaxLength(10);
            builder.Property(X => X.OriginalShippingPrice).IsRequired().HasMaxLength(100);
        }
    }
}