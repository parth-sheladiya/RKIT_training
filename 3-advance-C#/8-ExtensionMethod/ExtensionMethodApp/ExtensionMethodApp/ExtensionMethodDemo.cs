using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethodApp
{
    public static class ExtensionMethodDemo
    {
        // Extension method 
        public static int Age(this DateTime birthDate)
        {
            DateTime today = DateTime.Today;
            

            int age = today.Year - birthDate.Year;

            // Agar aaj ka din birthday se pehle hai to age ek kam karenge
            if (DateTime.Today < birthDate.AddYears(age))
            {
                age--;
            }

            return age;
            
        }
    }
}
