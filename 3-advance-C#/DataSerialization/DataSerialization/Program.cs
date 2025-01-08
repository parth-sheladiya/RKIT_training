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
            SerializeClass.RunSerializeClass();
            #endregion

            #region call deserialize method 
            DeserializeClass.RunDeserializeClass();
            #endregion

            #region call xmlserialize method 
            XMLserializeClass.RunXMLserializeClass();
            #endregion

            #region call xmldeserialize method 
            XMLdeserializeClass.RunXMLdeserializeClass();
            #endregion
        }


    }

   
}