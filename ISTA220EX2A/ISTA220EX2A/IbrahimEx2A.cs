using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISTA220EX2A
{
    class IbrahimEx2A
    {
        static void Main(string[] args)
        {

            //Main Menu
            int selected;
            do
            {
                DisplayMenu();
                string selection = Console.ReadLine();
                selected = int.Parse(selection);

                switch (selected)
                {
                   case 0:
                        {
                            break;
                        }
                    case 1:
                        {
                            // Part 1

                            Console.WriteLine("\nPart 1, circumference and area of a circle.");
                            Console.Write("Please enter an integer greater than 0 for the radius: ");
                            string strCircle = Console.ReadLine();
                            int radiusForCircle = int.Parse(strCircle);

                            Console.WriteLine("The circumference is {0:0.00}", CircumferenceofCircle(radiusForCircle));
                            Console.WriteLine("The area is {0:0.00}", AreaOfCircle(radiusForCircle));
                            Console.WriteLine("Please press Enter to go back to Main menu....");
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        }
                    case 2:
                        {
                            // Part 2
                            Console.WriteLine("\nPart 2, volume of a hemisphere.");
                            Console.Write("Please enter an integer greater than 0 for the radius: ");
                            string strHemisphere = Console.ReadLine();
                            int radiusForHemisphere = int.Parse(strHemisphere);

                            Console.WriteLine("The volume is {0:0.00}", VolumeOfHemisphere(radiusForHemisphere));
                            Console.WriteLine("Please press Enter to go back to Main menu....");
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        }
                    case 3:
                        {
                            // Part 3
                            Console.WriteLine("\nPart 3, area of a triangle (Heron's formula).");
                            Console.Write("Please enter an integer greater than 0 for the lenth of side a: ");
                            string strSideA = Console.ReadLine();
                            int sideA = int.Parse(strSideA);
                            Console.Write("Please enter an integer greater than 0 for the lenth of side b: ");
                            string strSideB = Console.ReadLine();
                            int sideB = int.Parse(strSideB);
                            Console.Write("Please enter an integer greater than 0 for the lenth of side c: ");
                            string strSideC = Console.ReadLine();
                            int sideC = int.Parse(strSideC);

                            Console.WriteLine("The area is {0:0.00}", AreaOfTriangle(sideA, sideB, sideC));
                            Console.WriteLine("Please press Enter to go back to Main menu....");
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        }
                    case 4:
                        {
                            // Part 4
                            Console.WriteLine("\nPart 4, solving a quadratic equation.");
                            Console.Write("Please enter an integer greater than 0 for the value of a: ");
                            string strA = Console.ReadLine();
                            int a = int.Parse(strA);
                            Console.Write("Please enter an integer greater or equal to 0 for the value of b: ");
                            string strB = Console.ReadLine();
                            int b = int.Parse(strB);
                            Console.Write("Please enter an integer greater or equal to 0 for the value of c: ");
                            string strC = Console.ReadLine();
                            int c = int.Parse(strC);

                            double p = Math.Pow(b, 2) - (4 * a * c);

                            if (p > 0)
                            {
                                Console.WriteLine("The positive solution is {0:F2}", QuadricEquationPositive(a, b, c, p));
                                Console.WriteLine("The negative solution is {0:F2}", QuadricEquationNegative(a, b, c, p));
                            }
                            else
                            {
                                Console.WriteLine("no results found");
                            }
                            Console.WriteLine("Please press Enter to go back to Main menu....");
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        }
                    default :
                    {
                            Console.Clear();
                            break;
                    }
                }
            }
            while (selected != 0);

        }

        static void DisplayMenu()
        {
            
            Console.WriteLine("Please select from the following Menu: ");
            Console.WriteLine("Press 1 to calculate the area and circumference of a circle ");
            Console.WriteLine("Press 2 to calculate the volume of a hemisphere ");
            Console.WriteLine("Press 3 to calculate the area of a triangle given the length of the sides ");
            Console.WriteLine("Press 4 to solve a quadratic equation ");
            Console.WriteLine("Press 0 to exit the console ");
            Console.Write(".....");
        }

        static double CircumferenceofCircle (int r)
        {
            double circumferenceCircle = 2 * r * Math.PI;

            return circumferenceCircle;
        }

        static double AreaOfCircle(int r)
        {
            double areaCircle = Math.PI * Math.Pow(r, 2);

            return areaCircle;

        }

        static double VolumeOfHemisphere(int r)
        {
            double volume = ( (4 * Math.PI * Math.Pow(r,3))/ 3 ) / 2;
                         
            return volume;
        }

        static double AreaOfTriangle(int a, int b, int c)
        {
            double p = (a + b + c) / 2;
            double areaOfTriangle = Math.Sqrt(p * (p - a) * (p - b) * (p - c));

            return areaOfTriangle;
        }
        
        static double QuadricEquationPositive(int a, int b, int c, double p)
        {
            double x = (-b + Math.Sqrt(p)) / (2 * a);

            return x;
        }

        static double QuadricEquationNegative(int a, int b, int c, double p)
        {
            double x = (-b - Math.Sqrt(p)) / (2 * a);

            return x;
        }
       
    }
}
