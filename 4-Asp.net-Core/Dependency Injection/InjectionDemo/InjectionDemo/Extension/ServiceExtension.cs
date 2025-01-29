using InjectionDemo.Service.ServiceHandler;
using InjectionDemo.Service;

namespace InjectionDemo.Extension
{
    /// <summary>
    /// custom extension service
    /// </summary>
    public static class ServiceExtension
    {
        /// <summary>
        /// custom method addproductservice and order service 
        /// </summary>
        /// <param name="services"></param>
        public static void AddProductOrderService(this IServiceCollection services)
        {
            // Register IProductService with its implementation ProductService as Transient
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IOrderService, OrderService>();
        }
    }
}
