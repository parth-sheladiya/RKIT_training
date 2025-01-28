using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Practice.Services;

namespace Practice.Controllers
{
    /// <summary>
    /// Controller that handles requests related to service instances.
    /// It demonstrates the usage of different service lifetimes: Scoped, Singleton, and Transient.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        // Fields to hold instances of the services for different lifetimes
        private readonly IScopeService _scopeServiceOne, _scopeServiceTwo;
        private readonly ISingletonService _singletonServiceOne, _singletonServiceTwo;
        private readonly ITransientService _transientServiceOne, _transientServiceTwo;

        /// <summary>
        /// Constructor that injects the service instances for different lifetimes.
        /// </summary>
        /// <param name="scopeServiceOne">First instance of ScopeService</param>
        /// <param name="scopeServiceTwo">Second instance of ScopeService</param>
        /// <param name="singletonServiceOne">First instance of SingletonService</param>
        /// <param name="singletonServiceTwo">Second instance of SingletonService</param>
        /// <param name="transientServiceOne">First instance of TransientService</param>
        /// <param name="transientServiceTwo">Second instance of TransientService</param>
        public ServiceController(
            IScopeService scopeServiceOne, IScopeService scopeServiceTwo,
            ISingletonService singletonServiceOne, ISingletonService singletonServiceTwo,
            ITransientService transientServiceOne, ITransientService transientServiceTwo
        )
        {
            // Initializing service instances
            _scopeServiceOne = scopeServiceOne;
            _scopeServiceTwo = scopeServiceTwo;
            _singletonServiceOne = singletonServiceOne;
            _singletonServiceTwo = singletonServiceTwo;
            _transientServiceOne = transientServiceOne;
            _transientServiceTwo = transientServiceTwo;
        }

        /// <summary>
        /// Action that retrieves the GUIDs for the different service instances.
        /// Demonstrates how the service lifetimes (Scoped, Singleton, Transient) behave.
        /// </summary>
        /// <returns>Returns the GUIDs of the service instances</returns>
        [HttpGet]
        public IActionResult GetServiceInfo()
        {
            // Returning the service GUIDs as a JSON response
            return Ok(new
            {
                Scoped = new
                {
                    instanceOne = _scopeServiceOne.GetServiceId(),
                    instanceTwo = _scopeServiceTwo.GetServiceId()
                },
                Singleton = new
                {
                    instanceOne = _singletonServiceOne.GetServiceId(),
                    instanceTwo = _singletonServiceTwo.GetServiceId()  
                },
                Transient = new
                {
                    instanceOne = _transientServiceOne.GetServiceId(),
                    instanceTwo = _transientServiceTwo.GetServiceId() 
                }
            });
        }
    }
}
