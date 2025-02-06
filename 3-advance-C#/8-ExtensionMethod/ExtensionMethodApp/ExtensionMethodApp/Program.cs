using System;


namespace ExtensionMethodApp
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime birthDate = new DateTime(2004, 11, 20);

            // Extension method ka use
            int age = birthDate.Age();

            Console.WriteLine($"parth   is: {age} years old");

            Game game = new Game();
            game.Play(); 
        }
    }
}
