namespace InjectionDemo.Service.ServiceHandler
{
    public class ProductService : IProductService
    {
        private readonly IProductService _productservice;

        /// <summary>
        /// Constructor to inject IProductRepository dependency.
        /// </summary>
        /// <param name="productRepository">Injected product repository instance.</param>
        public ProductService(IProductService productservice)
        {
            _productservice = productservice;
        }

        /// <summary>
        /// Fetches product details based on product ID.
        /// </summary>
        /// <param name="productId">Product ID for fetching details.</param>
        /// <returns>Product details message.</returns>
        public string GetProductDetails(int productId)
        {
            return $"Product ID: {productId} - Product details fetched successfully!";
        }
    }
}
