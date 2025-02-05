using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibExtMethod
{

    
    /// <summary>
    /// extension method 
    /// it's must be in static class 
    /// it's not modified.
    /// 2 extension method
    /// multiple extension method can be allow in static class 
    /// </summary>
    public static class UserExtensions
    {
        // Extension method
        public static bool Login(this User user, string inputUsername, string inputPassword)
        {
            return user.Username == inputUsername && user.Password == inputPassword;
        }

        // Extension method to check user status
        public static void CheckStatus(this User user)
        {
            // using string interpolation and ternary operatoe
            Console.WriteLine(user.IsActive
                ? $"User {user.Username} is active."
                : $"User {user.Username} is inactive.");
        }
    }
}
