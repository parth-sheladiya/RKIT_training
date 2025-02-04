#region Singleton Class
/// <summary>
/// Singleton class ensures that only one instance of the class exists.
/// 3 process of singleton class
/// </summary>
public class ExampleSingletonClass
{
    //Create only a single object of the class
    private static ExampleSingletonClass instance;

    //Make constructor private so no one can create an object of it from outside.
    private ExampleSingletonClass() { }

    //  Define a property to get the instance
    public static ExampleSingletonClass Instance
    {
        get
        {
            // Check if the instance exists.
            if (instance == null)
            {
                // If not, create the instance.
                instance = new ExampleSingletonClass();
            }
            return instance;
        }
    }

    // Method to display a message
    public static void ShowMessage()
    {
        Console.WriteLine("Singleton Class: Only one instance of this class exists.");
    }
}
#endregion
