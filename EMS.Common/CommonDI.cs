using Microsoft.Extensions.DependencyInjection;
namespace EMS.Common
{
    public static class CommonDI
    {
        public static void AddCommonLayer(this IServiceCollection services)
        {
            MappingConfig.RegisterMapping();
        }
    }
}
