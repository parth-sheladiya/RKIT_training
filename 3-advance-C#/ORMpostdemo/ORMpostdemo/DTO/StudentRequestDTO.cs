using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ORMpostdemo.DTO
{
    public class StudentRequestDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
    }
}