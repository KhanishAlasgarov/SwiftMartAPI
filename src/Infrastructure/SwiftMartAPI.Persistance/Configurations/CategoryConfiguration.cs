using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SwiftMartAPI.Domain.Entities;

namespace SwiftMartAPI.Persistance.Configurations;

internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasData(new()
        {
            Id = 1,
            Name = "Electric",
            Priorty = 1,
            ParentId = 0,
            IsDeleted = false,
            CreatedDate = DateTime.Now,
        }, new()
        {
            Id = 2,
            Name = "Fashion",
            Priorty = 1,
            ParentId = 0,
            IsDeleted = false,
            CreatedDate = DateTime.Now,
        }, new()
        {
            Id = 3,
            Name = "Computer",
            Priorty = 2,
            ParentId = 1,
            IsDeleted = false,
            CreatedDate = DateTime.Now,
        }, new()
        {
            Id = 4,
            Name = "Women",
            Priorty = 2,
            ParentId = 2,
            IsDeleted = false,
            CreatedDate = DateTime.Now,
        });

    }
}
