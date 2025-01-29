namespace InjectionDemo.Service.ServiceHandler
{
    /// <summary>
    /// interface implementation inherit from ipaymentservice 
    /// </summary>
    /// </summary>
    public class RazorpayPaymentService : IPaymentService
    {
        /// <summary>
        /// Processes the payment through Juspay.
        /// </summary>
        /// <param name="amount">amount</param>
        /// <param name="currency">currency</param>
        /// <returns></returns>
        public string ProcessPayment(decimal amount, string currency)
        {
            return $"Razorpay: Payment of {amount} {currency} processed successfully!";
        }
    }

}
