using RotaDeViagem.Domain.Commands.Response;

namespace RotaDeViagem.Domain.Interface.IProviders
{
    public interface IRotaProvider
    {
        Task<IEnumerable<RotaResponse>> GetRotaByOrigemAsync(string origem);
        Task<IEnumerable<RotaResponse>> GetRotaByDestinoAsync(string destino);
    }
}
