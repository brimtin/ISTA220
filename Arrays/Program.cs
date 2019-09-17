using System;
using System.Linq;
namespace Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int[] a = new int[10];
            int result = 0;
            for (int x = 0; x < a.Length; )
            {
                Console.Write($"{x+1}. please Enter a value between 0 and 100: ");
                 int.TryParse(Console.ReadLine(), out a[x]);
                
                if  (a[x] <=100 && a[x] >=0 )
                {
                    result += a[x];
                    x++;
                }
                else
                {
                    Console.WriteLine("\aInvalid Input!");
                }
               // Console.WriteLine(array[x]);
            }
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
