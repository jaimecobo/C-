using System;
namespace Hypotenuse
{
    public class StudentProgram
    {
        public static void Main()
        {
            double x = Hypotenuse(10.0, 20.0);
            Console.WriteLine(x);
        }
        static double Hypotenuse(double a, double b)
        {
            return Math.Sqrt(a * a + b * b);
        }
    }
}
