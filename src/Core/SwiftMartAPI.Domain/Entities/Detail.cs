using SwiftMartAPI.Domain.Common;

namespace SwiftMartAPI.Domain.Entities;

public class Detail : EntityBase
{
    public Detail(string title, string description, int categoryId)
    {
        Title = title;
        Description = description;
        CategoryId = categoryId;
    }
    public Detail()
    {
        
    }

    public required string Title { get; set; }
    public required string Description { get; set; }
    public required int CategoryId { get; set; }
    public Category? Category { get; set; }
}


