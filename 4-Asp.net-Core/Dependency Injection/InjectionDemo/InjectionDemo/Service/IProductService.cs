namespace InjectionDemo.Service
{
    /// <summary>
    /// interfacew
    /// </summary>
    public interface IProductService
    {
        /// <summary>
        /// get oduct details via product id
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        string GetProductDetails(int productId);
    }

}
