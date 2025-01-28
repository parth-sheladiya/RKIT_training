using Microsoft.AspNetCore.Mvc.Filters;

namespace FilterDemo.Filters
{
    public class CustomResourceFilter : Attribute, IResourceFilter
    {
        private readonly string _name;
        public CustomResourceFilter(string name) 
        {
            _name = name;
        }
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            Console.WriteLine($"resource filter before {_name}");
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            Console.WriteLine($"resource filter after {_name}");
        }
    }
}
