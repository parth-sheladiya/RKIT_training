namespace InjectionDemo.Service
{
    /// <summary>
    /// interface
    /// </summary>
    public interface IOrderService
    {
        /// <summary>
        /// Places an order for a product with a specified quantity
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        string PlaceOrder(int productId, int quantity);
    }

}
