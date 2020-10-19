using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tutorial.Car.BL.Services;
using Tutorial.Car.BL.Validators;
using Tutorial.Car.Common;
using Tutorial.Car.Common.IRepositories;
using Tutorial.Car.DAL;
using Tutorial.Car.DAL.Repositories;
using Tutorial.Car.DAL.Repositories.Main;

namespace Tutorial.Car.API
{
    public static class DependencyResolver
    {
        private static void DefaultNetInjectors(IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<AppSettings>(configuration);
        }

        public static void Resolve(IServiceCollection services, IConfiguration configuration)
        {
            var appSettingSection = configuration.GetSection("AppSettings");
            DefaultNetInjectors(services, appSettingSection);

            HttpClientServices(services, appSettingSection);
            Repositories(services);
            Services(services);
            Validators(services);
            Mappers(services);
        }

        private static void HttpClientServices(IServiceCollection services, IConfigurationSection appSettingSection)
        {
            //services.AddHttpClient("FaceBookApi", client =>
            //{
            //    client.BaseAddress = new Uri("https://facebook.com/api/betasdasd");
            //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //});

            //services.AddHttpClient("GoogleApi", client =>
            //{
            //    client.BaseAddress = new Uri("https://google.com/api/betasdasd");
            //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //});

            //services.AddHttpClient<ICarService, CarService>("GoogleApi");
        }

        private static void Mappers(IServiceCollection services)
        {

        }

        private static void Validators(IServiceCollection services)
        {
            services.AddScoped<ICarValidator, CarValidator>();
        }

        private static void Services(IServiceCollection services)
        {
            services.AddScoped<ICarService, CarService>();
        }

        private static void Repositories(IServiceCollection services)
        {
            services.AddScoped<IConnectionFactory, ConnectionFactory>();
            services.AddScoped<IHelperRepository, HelperRepository>();
            services.AddScoped<ICarRepository, CarRepository>();
        }
    }
}
