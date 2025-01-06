using System;
using System.Runtime.ConstrainedExecution;
using TypesOfClass;

public class Program
{
    public static void Main()
    {
        // calling  instance class
        InstanceClass.CreateAndDisplayCar();

        // calling static class
        ExampleStaticClass.CallMathUtilities();

        // callibng method
        ExamplePartialClass.CallMethods();

        // calling singletonclass
        ExampleSingletonClass.ShowMessage();

        // calling abstaract class method 
        ExampleAbstractClass.CallAnimalMethods();   

        // calling seald class 
        ExampleSealedClass.CallDriveMethodStatic(); 
    }
}
