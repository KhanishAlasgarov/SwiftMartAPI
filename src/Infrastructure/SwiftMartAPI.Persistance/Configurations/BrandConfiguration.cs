using Bogus;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SwiftMartAPI.Domain.Entities;

namespace SwiftMartAPI.Persistance.Configurations;

internal class BrandConfiguration : IEntityTypeConfiguration<Brand>
{
    public void Configure(EntityTypeBuilder<Brand> builder)
    {
        builder.Property(x => x.Name).HasMaxLength(256);
        Faker fake = new();

        builder.HasData(new()
        {
            Id = 1,
            Name = fake.Commerce.Department(),
            CreatedDate = DateTime.Now,
            IsDeleted = false,

        },
        new()
        {
            Id = 2,
            Name = fake.Commerce.Department(),
            CreatedDate = DateTime.Now,
            IsDeleted = false,

        },
        new()
        {
            Id = 3,
            Name = fake.Commerce.Department(),
            CreatedDate = DateTime.Now,
            IsDeleted = true,

        });
    }
}
