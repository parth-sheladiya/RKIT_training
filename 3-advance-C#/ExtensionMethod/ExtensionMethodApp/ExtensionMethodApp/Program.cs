using System;
// import class library in same assembly
using ClassLibExtMethod;

namespace ExtensionMethodApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new User object
            User user = new User { Username = "admin", Password = "1234", IsActive = true };

            // Take user input for username and password
            Console.Write("Enter username: ");
            string username = Console.ReadLine();
            Console.Write("Enter password: ");
            string password = Console.ReadLine();

            // Check login credentials using the extension method
            if (user.Login(username, password))
            {
                Console.WriteLine("Login Successful!");
                // useer is active or not 
                user.CheckStatus(); 
            }
            else
            {
                Console.WriteLine("Login Failed!");
            }
        }
    }
}
