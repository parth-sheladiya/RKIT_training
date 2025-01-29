namespace InjectionDemo.Service.ServiceHandler
{
    /// <summary>
    /// Handles order placement and payment processing.
    /// </summary>
    public class OrderService : IOrderService
    {
        /// <summary>
        /// Payment service injected to process payments.
        /// </summary>
        private readonly IPaymentService _paymentService;

        /// <summary>
        /// Constructor to inject IPaymentService dependency.
        /// </summary>
        /// <param name="paymentService">Injected payment service instance.</param>
        public OrderService(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        /// <summary>
        /// Places an order and processes payment.
        /// </summary>
        /// <param name="productId">Product ID for the order.</param>
        /// <param name="quantity">Quantity of the product ordered.</param>
        /// <returns>Order confirmation and payment processing result.</returns>
        public string PlaceOrder(int productId, int quantity)
        {
            decimal amount = quantity * 100; // Dummy price calculation
            string currency = "INR";
            string paymentResult = _paymentService.ProcessPayment(amount, currency);

            return $"Order Placed for Product ID: {productId}, Quantity: {quantity}. {paymentResult}";
        }
    }
}
