using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Shop.Application.Interfaces;
using Shop.Persistence;
using Microsoft.Extensions.Configuration;

namespace Shop.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services,
            IConfiguration configuration)
        {

            // подключение фиктивной БД
            services.AddScoped<AppContext>(_ =>
            {
                // используется база данных в памяти
                var options = new DbContextOptionsBuilder<AppContext>()
                    .UseInMemoryDatabase("db").Options;

                return new AppContext(options);
            });

            // сервисы работы с данными
            services.AddScoped<IUsersContext>(provider => provider.GetService<AppContext>()!);
            services.AddScoped<IProductsContext>(provider => provider.GetService<AppContext>()!);
            services.AddScoped<IOrdersContext>(provider => provider.GetService<AppContext>()!);

            // сервис геренации авторизационных токинов
            services.AddSingleton<ITokensGenerator>(_ => new TokensGenerator(
                secret: configuration["Jwt:Secret"]!,
                issuer: configuration["Jwt:Issuer"]!,
                audience: configuration["Jwt:Audience"]!,
                tokenLiveTime: int.Parse(configuration["Jwt:TokenValidity"]!))
            );

            return services;
        }
    }
}
