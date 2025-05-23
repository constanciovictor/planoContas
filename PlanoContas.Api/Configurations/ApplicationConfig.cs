using FluentValidation;
using PlanoContas.Application.Applications;
using PlanoContas.Application.Interfaces;
using PlanoContas.Application.Mapper;
using PlanoContas.Domain.Interfaces.Repositories;
using PlanoContas.Domain.Interfaces.Services;
using PlanoContas.Domain.Services;
using PlanoContas.Infra.Repositories;

namespace PlanoContas.Api.Configurations
{
    public static class ApplicationConfig
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IPlanoContaService, PlanoContaService>();

            ConfigureApplication(services);
            ConfigureMapper(services);
            ConfigureRepository(services);
            ConfigureValidator(services);
        }

        public static void ConfigureApplication(this IServiceCollection services)
        {
            services.AddScoped<IPlanoContaApplication, PlanoContaApplication>();
        }

        public static void ConfigureMapper(this IServiceCollection services)
        {
            services.AddScoped<IPlanoContaMapper, PlanoContaMapper>();
        }

        public static void ConfigureRepository(this IServiceCollection services)
        {
            services.AddScoped<IPlanoContaRepository, PlanoContaRepository>();
            services.AddScoped<IBaseRepository<PlanoContas.Domain.Models.PlanoContas>, PlanoContaRepository>();
        }

        public static void ConfigureValidator(this IServiceCollection services)
        {
            services.AddTransient<IValidator<PlanoContas.Domain.Models.PlanoContas>, PlanoContaValidator>();
        }
    }
}
