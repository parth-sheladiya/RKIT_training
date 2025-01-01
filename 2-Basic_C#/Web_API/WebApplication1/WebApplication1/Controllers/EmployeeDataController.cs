using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    public class EmployeeDataController : ApiController
    {
        public string[] myEmployees = { "parth", "keyur", "brijesh", "meet" };
        [HttpGet]
        public string[] GetEmployee()
        {
            return myEmployees;
        }

        [HttpGet]
        public string GetEmployeeByID(int id)
        {
            return myEmployees[id];
        }
    }
}
