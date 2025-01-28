namespace Practice.Services.ServiceHandler
{
    /// <summary>
    /// Implementation of the ITransientService interface.
    /// This service provides a unique identifier (GUID) for the service instance.
    /// A new GUID is generated each time the service is created.
    /// Transient services are created every time they are requested.
    /// </summary>
    public class TransientService : ITransientService
    {
        // Private field to store the unique identifier for this service instance
        private readonly Guid _serviceid;

        /// <summary>
        /// Constructor that initializes the TransientService and generates a new GUID.
        /// A new GUID is generated every time a new instance of the service is created.
        /// </summary>
        public TransientService()
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
            Console.WriteLine($"Transient service id is {_serviceid}");
            return _serviceid; // Return the GUID
        }
    }
}
