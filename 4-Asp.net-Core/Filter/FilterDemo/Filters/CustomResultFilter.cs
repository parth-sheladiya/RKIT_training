using Microsoft.AspNetCore.Mvc.Filters;

namespace FilterDemo.Filters
{
    public class CustomResultFilter : Attribute, IResultFilter
    {
        private readonly string _name;

        /// <summary>
        /// Initializes the filter with a name.
        /// </summary>
        /// <param name="name">The name associated with the filter.</param>
        public CustomResultFilter(string name)
        {
            _name = name;
        }
            
        public void OnResultExecuted(ResultExecutedContext context)
        {
            Console.WriteLine($"Result Filter - before execution {_name}");
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            Console.WriteLine($"Result Filter - After execution {_name}");
        }
    }
}
