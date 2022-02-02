using System;

namespace LambdaTesting
{
    class Program
    {
        static void Mainold(string [] args)
        {
            Action<int, string, bool> c;
            Action<int> b;
            Action a;

            Func<int> f1;
            Func<string,int> f2;

            Predicate<string> p;
            p = isString3letters;
            Console.WriteLine(p("hello"));
            Console.WriteLine(p("Two"));
            Console.WriteLine(p(null));

            
            f2 = function2a;
            //f2 = function2b;
            f1 = function1;
            // c = testc;
            // a = Test2();
            // b = testb;
            //// a = test;
            // b(5);

            int rv = f1();
            
        }

        static bool isString3letters(string s)
        {
            if ( s == null) return false;
            return 3 == s.Length;
        }

        static int function2a(string s)
        {
            return 0;
        }

        static string function2b(int i)
        {
            return "zero";
        }

        static int function1()
        {
            return 0;
        }

        static void testc(int a, string s, bool b)
        {
            Console.WriteLine("In testc");
        }

        static void testb(int a)
        {
            Console.WriteLine(a);
        }

        static void test()
        {
            Console.WriteLine("This is test");
        }

        static Action<int> test2b()
        {
            Action<int> a;
            a = testb;
            return a;

            return testb;
        }

        static Action Test2()
        {
            Action a;
            a = test;
            return a;

            return test;
        }
    }
}

// Lambda Expressions and predefined Delegates

// Action   = a variable that can be attached to a method that returns *void*
//             is doing "Something"

// Action a;                    connects to a method returning void and taking no arguments
// Action<int> b;               connects to a method returning void and taking a single int argument
// Action<int,string> c;        connects to a method returning void and taking two argumnts, and int and string


// Func     = a variable that can be attached to a method that returns something
//             is computing "Something"

// Func<int> a;                connects to a method returning int and taking no arguments
// Func<string,int> b;         connects to a method returning int and taking a string argument
// Func<double,double,double>  connects to a method returning double and taking two double arguments

// Predicate= a variable that can be attached to a method returning bool (either true or false)
//             is answering a yes/no or true/false question