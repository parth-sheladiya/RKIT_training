using System;
using System.Collections.Generic;

namespace BaseLibraryFeatures
{
    // Base class with a virtual Sort method
    public class BaseSorter
    {
        // Virtual method that can be overridden in derived classes
        public virtual void FeaturesSort(int[] array)
        {
            Console.WriteLine("Base Sort method is called.");
        }
    }

    // Derived class that overrides the Sort method and implements Bubble Sort
    public class BubbleSorter : BaseSorter
    {
        // Override the Sort method with Bubble Sort algorithm
        public override void FeaturesSort(int[] array)
        {
            int n = array.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        // Swap the elements
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
            
        }
    }

    public class BaseLibraryFeature
    {
        // Method to demonstrate sorting algorithm
        public static void RunBaseClassLibrary()
        {
            // Example array to be sorted
            int[] numbers = { 5, 3, 8, 4, 1 };

            Console.WriteLine("Original Array:");
            foreach (var number in numbers)
            {
                Console.Write(number + " ");
            }
            

            // Create an instance of BubbleSorter and call the overridden Sort method
            BaseSorter sorter = new BubbleSorter();
            sorter.FeaturesSort(numbers);

            // Displaying the sorted array
            Console.WriteLine("Sorted Array:");
            foreach (var number in numbers)
            {
                Console.Write(number + " ");
            }
           
        }
    }

}