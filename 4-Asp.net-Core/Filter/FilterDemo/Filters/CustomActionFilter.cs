using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace FilterDemo.Filters
{
    public class CustomActionFilter : Attribute, IActionFilter
    {
        private readonly string _name;

        // Constructor to accept 'name'
        public CustomActionFilter(string name)
        {
            _name = name;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            // Before executing action logic
            Console.WriteLine($"name is {_name} Custom Action Filter - Before Action Execution");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // After executing action logic
            Console.WriteLine($"name is {_name} Custom Action Filter - After Action Execution");
        }
    }
}
