using RotaDeViagem.DatabaseRepository.Repositories;
using RotaDeViagem.Domain.Interface.IProviders;
using RotaDeViagem.Domain.Interface.IRepositories;
using RotaDeViagem.Read.Database.Providers;

namespace RotaDeViagem.API.Setup
{
    public static class ProviderSetup
    {
        public static void AddDependencyProvider(this IServiceCollection services)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            services.AddTransient<IRotaProvider, RotaProvider>();

        }
    }
}
