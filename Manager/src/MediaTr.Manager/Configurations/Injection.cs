using Bogus;
using Hangfire;
using System.Reflection;

namespace MediaTr.Manager.Configurations;

public static class Injection
{
    public static IServiceCollection AddInjection(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        services.AddSingleton<Faker>(x => new Faker("pt_BR"));

        return services;
    }
}
