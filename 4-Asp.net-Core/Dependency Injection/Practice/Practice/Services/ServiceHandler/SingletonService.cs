namespace Practice.Services.ServiceHandler
{
    /// <summary>
    /// Implementation of the ISingletonService interface.
    /// This service provides a unique identifier (GUID) for the service instance.
    /// A new GUID is generated when the service is created, and the same GUID is used throughout the application's lifetime.
    /// </summary>
    public class SingletonService : ISingletonService
    {
        // Private field to store the unique identifier for this service instance
        private readonly Guid _serviceid;

        /// <summary>
        /// Constructor that initializes the SingletonService and generates a new GUID.
        /// The GUID will be the same throughout the application's lifetime for this instance.
        /// </summary>
        public SingletonService()
        {
            _serviceid = Guid.NewGuid(); // Generate a new GUID for the service instance
        }

        /// <summary>
        /// Method to retrieve the unique identifier (GUID) of the service instance.
        /// The GUID is used to distinguish this instance from others.
        /// </summary>
        /// <returns>A GUID representing the unique identifier of the service.</returns>
        public Guid GetServiceId()
        {
            // Output the GUID to the console for debugging or logging purposes
            Console.WriteLine($"Singleton service id is {_serviceid}");
            return _serviceid; // Return the GUID
        }
    }
}
