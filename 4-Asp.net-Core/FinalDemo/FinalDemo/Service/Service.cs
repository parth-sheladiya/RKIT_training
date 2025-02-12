using FinalDemo.BL.Interface;
using FinalDemo.BL.Operations;
using FinalDemo.Models;

namespace FinalDemo.Service
{
    public static class Service
    {
        public static void RegisterEcommerceServices(this IServiceCollection RegisterService)
        {
            RegisterService.AddTransient<Response>();
            RegisterService.AddScoped<IBLORD, BLOrder>();
            RegisterService.AddScoped<IBLPDT , BLPdt>();
            RegisterService.AddScoped<IBLUSR,BLUser>();
        }
    }
}
