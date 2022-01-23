using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Page14
{
    class Program
    {
        public static void Main()
        {
            int r = 10;

            Console.WriteLine(Math.PI);
            Console.WriteLine(2 * Math.PI);
            Console.WriteLine($"A Circle with radius 10 has a circumference of using Math.PI  {2 * Math.PI * r}");
            Console.WriteLine($"A Circle with radius 10 has a circumference of using Math 6.28318  {6.283185307179586 * r}");
            Console.WriteLine($"A Circle with radius 10 has a circumference of using 355/113  {2 * (355 / 113) * r}");

            // modify the statement below to correct the problem: it should not print out 60, but should print out 62.83185...

            Console.WriteLine($"A Circle with radius 10 has a circumference of using 355/113  {2 * (355.0 / 113.0) * r}");
            // explain why line 19 is wrong here:
            //
            // On line 19 the result is 60 because the division of 355 by 113 is 3 and not the expected value of 3.14159292035.
            // In c# the result of and operation with two or more integer values will always result in an integer value, regardless of the actual result has decimals
            //
        }
    }
}
