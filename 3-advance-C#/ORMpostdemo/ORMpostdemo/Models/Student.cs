using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ORMpostdemo.Models
{
    public class Student
    {
        public int Id { get; set; }       // Primary Key (auto-incremented in DB)
        public string Name { get; set; }   // Student's Name
        public string Email { get; set; }  // Student's Email
        public int Age { get; set; }
    }
}