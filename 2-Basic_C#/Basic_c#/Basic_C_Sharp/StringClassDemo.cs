using System;
using System.Text;

namespace Basic_C_Sharp
{
   public class StringClassDemo
    {

        #region string class
        public static void RunStringClassDemo()
        {
            string text = "Hello, World!";
            Console.WriteLine(text.Length);

            string firstName = "Rahul";
            string lastName = "Sharma";
            string fullName = string.Concat(firstName, " ", lastName);
            Console.WriteLine(fullName);

            string name = "Rahul Sharma";
            string fName = name.Substring(0, 5);
            Console.WriteLine(fName);

            string txt = "Hello, World!";
            string newText = txt.Replace("World", "C#");
            Console.WriteLine(newText);

            string sentence = "Rahul loves coding";
            string[] words = sentence.Split(' ');
            Console.WriteLine(words[1]);

            string[] newWords = { "Rahul", "loves", "coding" };
            string newSentence = string.Join(" ", newWords);
            Console.WriteLine(newSentence);


            string spaceText = "   Hello, World!   ";
            Console.WriteLine(spaceText.Trim());

            string containTxt = "C# programming is fun";
            Console.WriteLine(containTxt.Contains("fun"));

            string ulText = "Hello, World!";
            Console.WriteLine(ulText.ToUpper()); 
            Console.WriteLine(ulText.ToLower());

            string iName = "Rahul";
            int age = 25;
            string message = $"My name is {iName} and I am {age} years old.";
            Console.WriteLine(message); 


            string a = "Hello";
            string b = "hello";
            Console.WriteLine(a == b); 

            string eqText = "Hello";
            string eqText1 = "hello";
            Console.WriteLine(eqText.Equals(eqText1, StringComparison.OrdinalIgnoreCase));
            #endregion

            #region string builder

            Console.WriteLine("string builder");
            StringBuilder sb = new StringBuilder();


            sb.Append(" rajkot");
            sb.AppendLine(" ahmedabad");
            sb.Replace("rajkot", "vadodara");
            sb.Insert(0, " surat");
            /// sb.Remove(2, 5);


            Console.WriteLine(sb.ToString());
            #endregion










        }
    }
}
