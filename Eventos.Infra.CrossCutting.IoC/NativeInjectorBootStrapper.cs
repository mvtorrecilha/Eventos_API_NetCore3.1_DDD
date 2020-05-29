using Eventos.Application.Interfaces;
using Eventos.Application.Services;
using Eventos.Domain.Core.Interfaces.Repositories;
using Eventos.Domain.Core.Interfaces.Services;
using Eventos.Domain.Services.Services;
using Eventos.Infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Eventos.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // ASPNET
            //services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //services.AddSingleton(Mapper.Configuration);
            //services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetService));


            // Application
            services.AddScoped(typeof(IApplicationServiceBase<>), typeof(ApplicationServiceBase<>));
            services.AddScoped(typeof(IEventoApplicationService), typeof(EventoApplicationService));
            services.AddScoped(typeof(IPalestranteApplicationService), typeof(PalestranteApplicationService));

            //// Domain - Services
            services.AddScoped(typeof(IServiceBase<>), typeof(ServiceBase<>));
            services.AddScoped(typeof(IEventoService), typeof(EventoService));
            services.AddScoped(typeof(IPalestranteService), typeof(PalestranteService));

            //// Infra - Data
            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddScoped(typeof(IEventoRepository), typeof(EventoRepository));
            services.AddScoped(typeof(IPalestranteRepository), typeof(PalestranteRepository));

            //// Infra - Identity
            //services.AddTransient<IEmailSender, AuthMessageSender>();
            //services.AddTransient<ISmsSender, AuthMessageSender>();
            //services.AddScoped<IUser, AspNetUser>();

            //// Infra - Filtros
            //services.AddScoped<ILogger<GlobalExceptionHandlingFilter>, Logger<GlobalExceptionHandlingFilter>>();
            //services.AddScoped<ILogger<GlobalActionLogger>, Logger<GlobalActionLogger>>();
            //services.AddScoped<GlobalExceptionHandlingFilter>();
            //services.AddScoped<GlobalActionLogger>();
        }
    }
    
}
