using eCommerce.Core.RepositoryContract;
using eCommerce.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.Infrastructure
{
    public static class DepdennciesInjection
    {
        public static IServiceCollection AddInfraStructure(this IServiceCollection service)
        {

            service.AddScoped<IUserRepository, UserRepository>();

            return service;
        } 
    }
}
