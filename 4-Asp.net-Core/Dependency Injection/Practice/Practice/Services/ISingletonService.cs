namespace Practice.Services
{
    /// <summary>
    /// Interface that defines the contract for a singleton service providing a unique identifier.
    /// This service is expected to return a globally unique identifier (GUID) for identification.
    /// Singleton services are typically created once and shared across the application.
    /// </summary>
    public interface ISingletonService
    {
        /// <summary>
        /// Method to retrieve the unique identifier (GUID) for the service.
        /// The GUID can be used to distinguish between different instances or services.
        /// </summary>
        /// <returns>A GUID representing the unique identifier of the service.</returns>
        Guid GetServiceId();
    }
}
