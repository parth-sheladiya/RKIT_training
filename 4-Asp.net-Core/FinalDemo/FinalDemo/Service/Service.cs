using FinalDemo.BL.Interface;
using FinalDemo.BL.Operations;
using FinalDemo.Models;

namespace FinalDemo.Service
{
    /// <summary>
    /// service register using extension method
    /// </summary>
    public static class Service
    {
        public static void RegisterEcommerceServices(this IServiceCollection RegisterService)
        {
            // response
            RegisterService.AddTransient<Response>();
            RegisterService.AddScoped<IBLORD, BLOrder>();
            RegisterService.AddScoped<IBLPDT , BLPdt>();
            RegisterService.AddScoped<IBLUSR,BLUser>();
        }
    }
}
