using System;

namespace FinalDemo.Models
{
    /// <summary>
    /// response class it is give responce  handle to globally
    /// </summary>
    public class Responce
    {
        /// <summary>
        /// error by default no error set
        /// </summary>
        public bool IsError { get; set; } = false;
        /// <summary>
        /// message field
        /// </summary>
        public string Message { get; set; }

       /// <summary>
       /// dynamic data
       /// </summary>
        public dynamic Data { get; set; }
    }
}