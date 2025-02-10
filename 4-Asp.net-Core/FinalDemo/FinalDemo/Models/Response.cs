using FinalDemo.Services;

namespace FinalDemo.Models
{
    /// <summary>
    /// response handle
    /// </summary>
    public class Response
    {
        /// <summary>
        /// get set and return data
        /// </summary>
        public dynamic Data { get; set; }

        /// <summary>
        /// get set iserror by default no error
        /// </summary>
        public bool IsError { get; set; } = false;

        /// <summary>
        /// get set message 
        /// </summary>
        public string Message { get; set; } 


    }
}
