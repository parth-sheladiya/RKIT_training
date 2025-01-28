namespace Practice.Services
{
    /// <summary>
    /// Interface that defines the contract for a transient service providing a unique identifier.
    /// This service is expected to return a globally unique identifier (GUID) for identification.
    /// Transient services are typically created each time they are requested.
    /// </summary>
    public interface ITransientService
    {
        /// <summary>
        /// Method to retrieve the unique identifier (GUID) for the service.
        /// The GUID can be used to distinguish between different instances or services.
        /// </summary>
        /// <returns>A GUID representing the unique identifier of the service.</returns>
        Guid GetServiceId();
    }
}
