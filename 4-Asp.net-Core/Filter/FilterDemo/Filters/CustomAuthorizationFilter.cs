using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FilterDemo.Filters
{
    /// <summary>
    /// Custom authorization filter to handle authorization logic.
    /// </summary>
    public class CustomAuthorizationFilter : Attribute, IAuthorizationFilter
    {
        private readonly string _name;

        /// <summary>
        /// Initializes the filter with a name.
        /// </summary>
        /// <param name="name">The name associated with the filter.</param>
        public CustomAuthorizationFilter(string name)
        {
            _name = name;
        }

        /// <summary>
        /// Executes authorization logic before the action is executed.
        /// </summary>
        /// <param name="context">The context of the authorization request.</param>
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            Console.WriteLine($"Authorization Filter - {_name}");

            bool isAuthenticated = context.HttpContext.User.Identity?.IsAuthenticated ?? false;

            //if (!isAuthenticated)
            //{
            //    context.Result = new UnauthorizedResult();
            //}
        }
    }
}