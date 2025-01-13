using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ORMdemo.Models
{
    public class Response
    {
        /// <summary>
        /// Gets or Sets the response data according to the request.
        /// </summary>
        public dynamic Data { get; set; }

        /// <summary>
        /// Gets or Sets the error status of the request.
        /// </summary>
        public bool IsError { get; set; } = false;

        /// <summary>
        /// Gets or Sets the message according to the success or error response.
        /// </summary>
        public string Message { get; set; }
    }
}