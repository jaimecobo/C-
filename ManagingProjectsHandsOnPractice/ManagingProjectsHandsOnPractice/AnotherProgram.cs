using System;

namespace ManagingProjectsHandsOnPractice
{
    namespace myNamespace 
    {
        class AnotherProgram
        {
            public static void printText()
            {
                Console.WriteLine("Hello Earth!");
            }
        }

    }

    namespace textNamespace
    {
        class AnotherProgram01
        {
            public static void printText()
            {
                Console.WriteLine("I am text from textNamespace.");
            }

        }
    }
    
}


/*
*Create another file named AnotherProgram.cs.
*Within AnotherProgram.cs, include the following:
*The necessary using statement for System
*A namespace named myNamespace. Within this namespace add the following:
*A class named AnotherProgram
*Add a method within the class named printText that prints "Hello Earth!" to the console.
*Again within the AnotherProgram.cs file, create another namespace.
*Give this namespace a unique name.
*The namespace should have a class that includes a method.
*The method should have a unique print statement.
*Using the using keyword, make both of the namespaces from AnotherProgram.cs available to the Program.cs file using aliases.
*Within the Main method in Program.cs, call each of the methods from the namespaces in AnotherProgram.cs.
*Your final output should look similar to the following:
Hello World!
Hello Earth!
I am text from the textNamespace.
 */
