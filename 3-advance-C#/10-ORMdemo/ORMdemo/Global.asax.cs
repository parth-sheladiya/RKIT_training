using Mysqlx.Crud;
using ORMdemo.Models.POCO;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Odbc;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace ORMdemo
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            // Database connection using connection string and orm lite tool.
            var connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;
            var dbFactory = new OrmLiteConnectionFactory(connectionString, MySqlDialect.Provider);

            // Storing OrmLiteConnectionFactory instance for further usage in any other component.
            Application["DbFactory"] = dbFactory;


            // Automatically create tables at application startup
            InitializeDatabase(dbFactory);

        }

        private void InitializeDatabase(OrmLiteConnectionFactory dbFactory)
        {
            using (var db = dbFactory.OpenDbConnection())
            {

                db.CreateTableIfNotExists<PDT01>();
               
            }
        }
    }
}
