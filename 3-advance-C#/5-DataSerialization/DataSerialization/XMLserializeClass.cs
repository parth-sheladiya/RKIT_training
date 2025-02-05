using System;
using System.Xml.Linq;

namespace DataSerialization
{
    /// <summary>
    /// This class demonstrates how to serialize a Person object into XML format using XElement.
    /// </summary>
    public static class XMLserializeClass
    {
        /// <summary>
        /// The main method that demonstrates converting a Person object to XML format.
        /// </summary>
        public static void RunXMLserializeClass()
        {
            // Create a new Person object and assign values to its properties
            Person person = new Person();
            person.Name = "parth";
            person.Description = "parth description";

            // Convert the Person object to XML format using xelement class
            XElement xml = new XElement("Person",
                new XElement("Name", person.Name),
                new XElement("Description", person.Description));

            // Display the serialized XML
            Console.WriteLine("Serialized XML is: " + xml);
        }
    }
}