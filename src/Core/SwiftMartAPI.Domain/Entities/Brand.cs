using SwiftMartAPI.Domain.Common;

namespace SwiftMartAPI.Domain.Entities;

public class Brand : EntityBase
{
    public Brand(string name)
    {
        Name = name;
    }
    public Brand()
    {

    }
    public string Name { get; set; }
}




