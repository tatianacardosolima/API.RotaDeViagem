namespace RotaDeViagem.Shared.Interfaces.IEntities
{
    public interface IAuditableEntity : IEntity
    {
        long Id { get; set; }
        Guid UniqueId { get; set; }
        string CreatedBy { get; set; }
        string ModifiedBy { get; set; }
        DateTime CreatedAt { get; set; }
        DateTime? ModifiedAt { get; set; }

        //bool IsDeleted { get; set; }
    }
}
