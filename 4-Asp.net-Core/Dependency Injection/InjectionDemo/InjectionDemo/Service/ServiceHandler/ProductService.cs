namespace InjectionDemo.Service.ServiceHandler
{
    public class ProductService : IProductService
    {
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
