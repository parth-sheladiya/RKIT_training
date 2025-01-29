namespace InjectionDemo.Service
{
    /// <summary>
    /// interface
    /// </summary>
    public interface IPaymentService
    {
        /// <summary>
        /// Processes a payment with the given amount and currency
        /// </summary>
        /// <param name="amount">amount</param>
        /// <param name="currency">currency</param>
        /// <returns></returns>
        string ProcessPayment(decimal amount, string currency);
    }

}
