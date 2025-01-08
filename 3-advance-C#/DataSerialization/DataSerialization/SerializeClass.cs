using System;
using Newtonsoft.Json;

namespace DataSerialization
{
    /// <summary>
    /// This class handles the serialization of the Person object to JSON format.
    /// </summary>
    public static class SerializeClass
    {
        /// <summary>
        /// The main method that demonstrates serialization of a Person object to JSON.
        /// </summary>
        public static void RunSerializeClass()
        {
            Person person = new Person();
            person.Name = "parth";
            person.Description = "full stack developer trainee";

            // Serialization
            //convert person object to json string
            string json = JsonConvert.SerializeObject(person);
            // display message
            Console.WriteLine("Serialized JSON is: " + json);
        }
    }

    /// <summary>
    /// Represents a person with a name and description.
    /// </summary>
    public class Person
    {
        /// <summary>
        /// Gets or sets the name of the person.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description of the person.
        /// </summary>
        public string Description { get; set; }
    }
}
