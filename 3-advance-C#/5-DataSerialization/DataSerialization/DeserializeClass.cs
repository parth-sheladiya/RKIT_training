using Newtonsoft.Json;
using System;

namespace DataSerialization
{
    /// <summary>
    /// This class handles the deserialization of a JSON string into a Person object.
    /// </summary>
    public static class DeserializeClass
    {
        /// <summary>
        /// The main method that demonstrates deserialization of a JSON string into a Person object.
        /// </summary>
        public static void RunDeserializeClass()
        {
            // Sample JSON string to deserialize
            string json = "{'Name':'parth','Description':'full stack developer trainee'}";

            // Deserialize the JSON string into a Person object
            Person person = JsonConvert.DeserializeObject<Person>(json);

            // Output the deserialized Person object details
            Console.WriteLine("Deserialized Person object");
            Console.WriteLine("Name: " + person.Name);
            Console.WriteLine("Description: " + person.Description);
        }
    }
}
