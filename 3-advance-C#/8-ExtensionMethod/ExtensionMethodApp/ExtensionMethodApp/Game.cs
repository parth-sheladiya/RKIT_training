using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethodApp
{
    public class Game
    {
        private int secretNumber;

        public Game()
        {
            Random rnd = new Random();
            secretNumber = rnd.Next(1, 101); // 1 se 100 tak random number generate karega
        }

        public void Play()
        {
            int guess = 0;
            Console.WriteLine("Guess a number between 1 and 100!");

            while (guess != secretNumber)
            {
                Console.Write("Enter your guess: ");
                guess = Convert.ToInt32(Console.ReadLine());

                if (guess < secretNumber)
                    Console.WriteLine("your entered number is low pleasse enter high number");
                else if (guess > secretNumber)
                    Console.WriteLine("your entered number is higgh pleasse enter low number");
                else
                    Console.WriteLine("your guess number is " + guess);
            }
        }
    }
}
