using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistences.Contexts.Configurations
{
    public class BranchOfficeConfiguration : IEntityTypeConfiguration<BranchOffice>
    {
        public void Configure(EntityTypeBuilder<BranchOffice> builder)
        {
            builder.HasKey(e => e.BranchOfficeId).HasName("PK__BranchOf__27247FF9B01DC2A7");

            builder.Property(e => e.Address).IsUnicode(false);
            builder.Property(e => e.Code)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.Phone)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.HasOne(d => d.Business).WithMany(p => p.BranchOffices)
                .HasForeignKey(d => d.BusinessId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BranchOff__Busin__5BE2A6F2");

            builder.HasOne(d => d.District).WithMany(p => p.BranchOffices)
                .HasForeignKey(d => d.DistrictId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BranchOff__Distr__5CD6CB2B");
        }
    }
}

