using System;

namespace HW6D
{
    class Program
    {
        static void Main(string[] args)
        {

            App test = new App(20, 19);
            (int, int) xy;
            test.Deconstruct(out xy.Item1, out xy.Item2);

            Console.WriteLine(xy);

            var x = Courses.ITSA420;

            Console.WriteLine(x);
        }

           enum Courses : short { ITSA220 = 1, ITSA420, ITSA322 };
    

    
    }
}
