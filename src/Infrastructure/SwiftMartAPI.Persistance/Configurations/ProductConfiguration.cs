using Bogus;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SwiftMartAPI.Domain.Entities;

namespace SwiftMartAPI.Persistance.Configurations;

internal class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        Faker faker = new();

        builder.HasData(new()
        {
            Id = 1,
            Title = faker.Commerce.ProductName(),
            Description = faker.Commerce.ProductDescription(),
            BrandId = 1,
            Discount = faker.Random.Decimal(0, 10),
            Price = faker.Finance.Amount(10, 1000),
            CreatedDate = DateTime.Now,
            IsDeleted = false,
        }, new()
        {
            Id = 2,
            Title = faker.Commerce.ProductName(),
            Description = faker.Commerce.ProductDescription(),
            BrandId = 3,
            Discount = faker.Random.Decimal(0, 10),
            Price = faker.Finance.Amount(10, 1000),
            CreatedDate = DateTime.Now,
            IsDeleted = false,
        });
    }
}
