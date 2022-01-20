// directives
// using
using System;   // This is an example of a directive
using Red;

namespace FirstProject  // This is a example of a namespace
{
    namespace subitem
    {
        class test
        {

        }
    }
    class Program   // This is an example of a class (type)
    {
        static void Main(String[] args) // This is a method
        {
            Console.WriteLine("Hello World");

            int i = 90;         // 90 is a literal
            char c = 'k';       // k is a literal
            double d = 3.14159; // 3.14159 is a literal

            int maxInteger = int.MaxValue;      // int.MaxValue is a constant
            double pi = Math.PI;                // Math.PI is a constant
           
        }
    }

    class b
    {

    }

    enum colors
    {
        red,
        green,
        blue,
        orange,
    }
    
    struct mine
    {
    }

    interface MyInterface
    {
    }

    delegate void test (int i);
        


}

namespace Red
{
    class A { }
}

namespace Green
{
    class B { }
}