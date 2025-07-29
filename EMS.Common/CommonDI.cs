using EMS.Common.HashPassword;
using EMS.Common.MapsterMapping;
using EMS.Common.Token;
using Mapster;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;
namespace EMS.Common
{
    public static class CommonDI
    {
        public static void AddCommonLayer(this IServiceCollection services)
        {
            MappingConfig.RegisterMapping();

            var config = TypeAdapterConfig.GlobalSettings;

            services.AddSingleton(config);

            services.AddScoped<IMapper, ServiceMapper>();
            services.AddScoped<IPasswordHasher, PasswordHasher>();
            services.AddScoped<ITokenService, TokenService>();
        }
    }
}
