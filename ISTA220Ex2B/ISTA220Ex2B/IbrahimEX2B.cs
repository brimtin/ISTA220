/*
3. Using your own words in a comment at the top of your .cs file, describe "syntactic sugar".
Syntactic sugar in my opinion is a coding style used by programmer to make codes easier to read and work with.
When used, it allows developpers to use a given method is different ways without having to rewrite, change or
make a new method. It provides some added benefits to said method.

*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISTA220Ex2B
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1.Write a method that takes two optional parameters.
            // Language(string country = "Spain", string languageSpoken = "Spanish")
            {
               // Console.WriteLine($" In {country} , they speak {languageSpoken}");
            }
            //Testing overloaded methods created in question#2.
           // Language();
            //Language("Spain");
            //Language("Spain", "Spanish");
            Language("France", "French");
            Console.ReadLine();
        }
        //2. Manually write out the method you created in #1, this time using overloaded functions rather than optional parameters.
        static void Language(string country, string languageSpoken)
        {
            Console.WriteLine($" In {country} , they speak {languageSpoken}");
        }
        //static void Language(string country)
        //{
        //    Language(country, "Spanish");
        //}
        //static void Language()
        //{
        //    Language("Spain", "Spanish");
        //}
    }
}
