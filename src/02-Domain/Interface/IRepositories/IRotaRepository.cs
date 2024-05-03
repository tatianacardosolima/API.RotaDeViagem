using RotaDeViagem.Domain.Entities;
using RotaDeViagem.Shared.Interfaces.IRepositories;

namespace RotaDeViagem.Domain.Interface.IRepositories
{
    public interface IRotaRepository: IRepository<Rota, int>
    {
    }
}
