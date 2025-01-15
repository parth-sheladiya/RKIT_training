using ServiceStack.OrmLite.MySql;
using ServiceStack.OrmLite;
using System.Web.Http;

namespace ORMpostdemo
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()


        {

            // Set the OrmLite Dialect Provider for MySQL
            OrmLiteConfig.DialectProvider = new MySqlDialectProvider();
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
