using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RdxServer.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            //services.AddScoped<MeuDBContext>();
            //services.AddScoped<IProdutoRepository, ProdutoRepository>();
            //services.AddScoped<IFornecedorRepository, FornecedorRepository>();
            //services.AddScoped<IEnderecoRepository, EnderecoRepository>();
            //services.AddSingleton<IValidationAttributeAdapterProvider, MoedaValidationAttributeAdapterProvider>();

            //services.AddScoped<INotificador, Notificador>();
            //services.AddScoped<IFornecedorService, FornecedorService>();
            //services.AddScoped<IProdutoService, ProdutoService>(); 

            return services;
        }
    }
}
