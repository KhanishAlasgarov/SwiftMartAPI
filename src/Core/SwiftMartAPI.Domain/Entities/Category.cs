using SwiftMartAPI.Domain.Common;

namespace SwiftMartAPI.Domain.Entities;

public class Category : EntityBase
{
    public Category(string name, int parentId, int priorty)
    {
        Name = name;
        ParentId = parentId;
        Priorty = priorty;
    }



    public required string Name { get; set; }
    public required int ParentId { get; set; }
    public required int Priorty { get; set; }
    public IEnumerable<Detail>? Details { get; set; }

    public IEnumerable<Product>? Products { get; set; }
}

public class Product : EntityBase
{
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required int BrandId { get; set; }
    public Brand? Brand { get; set; }
    public required decimal Price { get; set; }
    public required decimal Discount { get; set; }

    public IEnumerable<Category>? Categories { get; set; }


    //public required string ImagePath { get; set; }
}

public class Detail : EntityBase
{
    public Detail(string title, string description, int categoryId)
    {
        Title = title;
        Description = description;
        CategoryId = categoryId;
    }

    public required string Title { get; set; }
    public required string Description { get; set; }
    public required int CategoryId { get; set; }
    public Category? Category { get; set; }
}


