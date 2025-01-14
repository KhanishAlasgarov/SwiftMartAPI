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
    public Category()
    {
        
    }


    public string Name { get; set; }
    public int ParentId { get; set; }
    public int Priorty { get; set; }
    public IEnumerable<Detail>? Details { get; set; }

    public IEnumerable<ProductCategory>? ProductCategories { get; set; }
}


