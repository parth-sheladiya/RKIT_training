using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FilterDemo.Filters
{
    /// <summary>
    /// Custom exception filter to handle and log exceptions.
    /// </summary>
    public class CustomExceptionFilter : Attribute, IExceptionFilter
    {
        /// <summary>
        /// Handles exceptions that occur during the execution of the action.
        /// </summary>
        /// <param name="context">The context of the exception.</param>
        public void OnException(ExceptionContext context)
        {
            Console.WriteLine($"Exception (my) : {context.Exception}");

            // Create a response object with error details
            var response = new
            {
                Message = "An error occurred.",
                Error = context.Exception.Message
            };

            // Set the result to an ObjectResult with the response and a 500 status code
            context.Result = new ObjectResult(response)
            {
                StatusCode = 500
            };
        }
    }
}