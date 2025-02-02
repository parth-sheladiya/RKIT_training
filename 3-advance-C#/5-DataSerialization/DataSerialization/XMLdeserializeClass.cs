using System;
using System.Xml.Linq;

namespace DataSerialization
{
    /// <summary>
    /// This class demonstrates how to deserialize an XML string into a Person object.
    /// </summary>
    public class XMLdeserializeClass
    {
        /// <summary>
        /// The main method that demonstrates the process of converting an XML string into a Person object.
        /// </summary>
        public static void RunXMLdeserializeClass()
        {
            // Sample XML string to deserialize
            string xmlString = " <Person><Name>Test</Name><Description>test description</Description></Person>";

            // Parse the XML string into XElement
            XElement parseXML = XElement.Parse(xmlString);

            // Convert the XML elements into a Person object
            Person deserializedObject = new Person
            {
                Name = parseXML.Element("Name")?.Value,          // Get the Name element value
                Description = parseXML.Element("Description")?.Value,  // Get the Description element value
            };

            // Display the deserialized object details
            Console.WriteLine("XML to object: " + $"Name: {deserializedObject.Name}, Description: {deserializedObject.Description}");
        }
    }

}