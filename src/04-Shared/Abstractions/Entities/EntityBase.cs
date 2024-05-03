using RotaDeViagem.Shared.Interfaces.IEntities;

namespace RotaDeViagem.Shared.Abstractions.Entities
{
    public abstract class EntityBase: IEntity
    {
        public int Id { get; set; }
    }
}
