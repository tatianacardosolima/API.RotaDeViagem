using RotaDeViagem.DatabaseRepository.Repositories;
using RotaDeViagem.Domain.Interface.IRepositories;

namespace RotaDeViagem.API.Setup
{
    public static class RepositorySetup
    {
        public static void AddDependencyRepository(this IServiceCollection services)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            services.AddScoped<IRotaRepository, RotaRepository>();

        }
    }
}
