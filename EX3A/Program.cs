using System;

namespace EX3A
{
    class Program
    {
        
        //Step3
        static void Main(string []args)
        {
            Random randomNumber = new Random();

            int iterations = int.Parse(args[0]);

            var myEstimateOfPI = CalculateAnEstimateOfPI(iterations, randomNumber);
            var difference = Math.Abs(myEstimateOfPI - Math.PI);
            
            
            //step6	
	        Console.WriteLine($"Our estimate of PI is: {myEstimateOfPI}");	
            Console.WriteLine($"The difference between our estimation of PI and PI is: {difference}");
        }

        //step 1
        static (double, double) GetRandomNumber(Random r) => (r.NextDouble(), r.NextDouble());

        //step 2
        static double Hypotenuse(double x, double y)
        {
            double result = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));

            return result;
        }

        //Step4
        static double CalculateAnEstimateOfPI(int iterations, Random rand)
        {
            int count = 0;
            
            for (int i = 0; i < iterations; i++)
            {
                
                double x, y;
                (x, y) = GetRandomNumber(rand);
                if (Hypotenuse(x, y) <= 1)
                {
                    count++;
                }

            }
        //step5		
            return 4.0 * count / iterations;
        }

    }
}

/*
 * 1. Why do we multiply the value from step 5 above by 4?
 *    Because we are only accounting for one quadrant of the circle when 
 *    calcuating the hypotenuse. 
 *    
 * 2. What do you observe in the output when running your program with parameters of increasing size?
 *    The difference between our estimate and the actual value of PI decreases as the number of Iterations increase, but only up to a certain point,
 *    aftrer which the difference starts to increase.
 *    
 * 3. If you run the program multiple times with the same parameter, does the output remain the same? Why or why not?
 *    Any given parameter will always  return a different output because the number are being randomly generated.
 *    
 * 4. Find a parameter that requires multiple seconds of run time. What is that parameter?
 *    1,000,000,000
 * 5. How Acurate is PI?
 *    The difference between my estimation of PI and PI was: 8.08944102068665E-05 with above parameter

 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 */
