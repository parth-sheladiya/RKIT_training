﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalDemo.Models
{
    public class User
    {
        /// <summary>
        /// userid
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// username
        /// </summary>
        public string username { get; set; }
        /// <summary>
        /// Password
        /// </summary>
        public string password { get; set; }

        /// <summary>
        /// user role
        /// </summary>
        public string role { get; set; }
    }
}