using System;
using Newtonsoft.Json;
using System.Xml.Linq;
using System.Security.Cryptography.X509Certificates;

namespace DataSerialization
{

    class Program
    {
        public static void Main(string[] args)
        {
            #region call serialize method 
            // serialize class method
            //SerializeClass.RunSerializeClass();
            #endregion

            #region call deserialize method 
            // deserialize class method
           // DeserializeClass.RunDeserializeClass();
            #endregion

            //xmlserialize class method
            #region call xmlserialize method 
            XMLserializeClass.RunXMLserializeClass();
            #endregion

            //dexmlserialize class method
            #region call xmldeserialize method 
            XMLdeserializeClass.RunXMLdeserializeClass();
            #endregion
        }


    }

   
}