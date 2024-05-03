using MediatR;
using RotaDeViagem.Shared.Interfaces.IResponse;

namespace RotaDeViagem.Domain.Interface.Request
{
    public interface ICommandRequest: IRequest<IGenericResponse>
    {
    }

    public interface IUniqueIdCommandRequest : IRequest<IGenericResponse>
    {
        Guid UniqueId { get; set; }
    }
}
