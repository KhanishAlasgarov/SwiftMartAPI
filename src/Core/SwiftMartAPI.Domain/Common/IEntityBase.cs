namespace SwiftMartAPI.Domain.Common;

public interface IEntityBase
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public bool IsDeleted { get; set; }
}
