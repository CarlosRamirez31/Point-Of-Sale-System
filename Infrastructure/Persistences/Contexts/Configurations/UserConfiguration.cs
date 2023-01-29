using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistences.Contexts.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(e => e.UserId).HasName("PK__Users__1788CC4C97ED388B");

            builder.Property(e => e.Email).IsUnicode(false);
            builder.Property(e => e.Image).IsUnicode(false);
            builder.Property(e => e.Password).IsUnicode(false);
            builder.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false);
        }
    }
}
