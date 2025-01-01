using System;

namespace Basic_C_Sharp
{
    public class ScopeAndAccessibilityModifier
    {

        #region  variable
        public int myPublicVar = 10; // Accessible anywhere

        private int myPrivateVar = 20;


        protected int myProtectedVar = 30;

        internal int myInternalVar = 40;

        protected internal int myProtectedInternalVar = 50;

        private protected int myPrivateProtectedVar = 60;

        #endregion
        public static void RunScopeAndAccessibilityModifierDemo()
        {


            int localVar = 5;
            int localVar2 = 15;
            Console.WriteLine(localVar + localVar2);


            DemoClass demo = new DemoClass();
            DerivedClass derived = new DerivedClass();

            // Access public method
            demo.PublicMethod();

            // Access private method (via public wrapper method)
            demo.CallPrivateMethod();

            // Access internal method
            demo.InternalMethod();

            // Access protected internal method
            demo.ProtectedInternalMethod();

            // Access static method
            DemoClass.StaticMethod();

            // Access protected and private protected methods via derived class
            derived.AccessProtectedMethods();

            // Uncommenting the below lines will cause errors:
            // demo.PrivateMethod(); // Error: Not accessible
            // demo.ProtectedMethod(); // Error: Not accessible
            // demo.PrivateProtectedMethod(); // Error: Not accessible

        }

        public class DemoClass
        {
            // Private method: Only accessible within this class
            private void PrivateMethod()
            {
                Console.WriteLine("This is a Private Method. Only accessible within this class.");
            }

            // Public method: Accessible from anywhere
            public void PublicMethod()
            {
                Console.WriteLine("This is a Public Method. Accessible from anywhere.");
            }

            // Protected method: Accessible within this class and derived classes
            protected void ProtectedMethod()
            {
                Console.WriteLine("This is a Protected Method. Accessible in derived classes.");
            }

            // Internal method: Accessible within the same assembly
            internal void InternalMethod()
            {
                Console.WriteLine("This is an Internal Method. Accessible within the same assembly.");
            }

            // Protected Internal method: Accessible within the same assembly or derived classes
            protected internal void ProtectedInternalMethod()
            {
                Console.WriteLine("This is a Protected Internal Method. Accessible in the same assembly or derived classes.");
            }

            // Private Protected method: Accessible within the same assembly and derived classes
            private protected void PrivateProtectedMethod()
            {
                Console.WriteLine("This is a Private Protected Method. Accessible within the same assembly and derived classes.");
            }

            // Static method: Accessible without creating an object of the class
            public static void StaticMethod()
            {
                Console.WriteLine("This is a Static Method. Can be called without creating an object.");
            }

            // Method to call the private method within this class
            public void CallPrivateMethod()
            {
                PrivateMethod(); // Calling private method
            }
        }
        public class DerivedClass : DemoClass
        {
            public void AccessProtectedMethods()
            {
                // Accessing protected method
                ProtectedMethod();

                // Accessing protected internal method
                ProtectedInternalMethod();

                // Accessing private protected method
                PrivateProtectedMethod();
            }
        }
    }
}
