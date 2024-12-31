using System;

namespace Basic_C_Sharp
{
    public class EnumerationDemo
    {
        public static void RunEnumerationDemo()
        {


            #region enum without method
            Console.WriteLine("enum without method");
            Console.WriteLine("Enter the order status (Pending, Processing, Shipped, Delivered, Cancelled):");
            string userInput = Console.ReadLine();

            // Convert user input to enum value
            if (Enum.TryParse(userInput, true, out OrderStatus status))
            {
                Console.WriteLine($"Current Status: {status}");

                // Integer Conversion
                int statusValue = (int)status;
                Console.WriteLine($"Status Value: {statusValue}");

                // Enum in Switch Case
                switch (status)
                {
                    case OrderStatus.Pending:
                        Console.WriteLine("Your order is pending.");
                        break;
                    case OrderStatus.Processing:
                        Console.WriteLine("Your order is being processed.");
                        break;
                    case OrderStatus.Shipped:
                        Console.WriteLine("Your order has been shipped.");
                        break;
                    case OrderStatus.Delivered:
                        Console.WriteLine("Your order has been delivered.");
                        break;
                    case OrderStatus.Cancelled:
                        Console.WriteLine("Your order has been cancelled.");
                        break;
                    default:
                        Console.WriteLine("Unknown status.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid order status.");
            }
            #endregion

            #region enum with method
            Console.WriteLine("enum with method");

            
                Role myRole = Role.Admin;
                Console.WriteLine(GetDescription(myRole)); // Output: Has full access
            
            static string GetDescription(Role role)
            {
                switch (role)
                {
                    case Role.Admin:
                        return "Has full access";
                    case Role.User:
                        return "Has limited access";
                    case Role.Guest:
                        return "Has guest access";
                    default:
                        return "Unknown role";
                }
            }

            #endregion

        }


        #region enum
        enum OrderStatus
        {
            Pending,
            Processing,
            Shipped,
            Delivered,
            Cancelled
        }
        #endregion


        #region enum role
        enum Role
        {
            Admin,
            User,
            Guest
        }
        #endregion

    }
}
