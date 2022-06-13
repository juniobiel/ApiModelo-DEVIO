using Api.Extensions;
using Business.Interfaces;
using Business.Notifications;
using Business.Services;
using Data.Context;
using Data.Repository;
using DevIO.Api.Configuration;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Api.Config
{
    public static class Injections
    {
        public static IServiceCollection ResolveDependencies( this IServiceCollection services )
        {
            services.AddScoped<DataDbContext>();
            

            services.AddScoped<IFornecedorRepository, FornecedorRepository>();
            services.AddScoped<IFornecedorService, FornecedorService>();

            services.AddScoped<IEnderecoRepository, EnderecoRepository>();

            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IProdutoService, ProdutoService>();

            services.AddScoped<INotificador, Notificador>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IUser, AspNetUser>();

            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            return services;
        }
    }
}
