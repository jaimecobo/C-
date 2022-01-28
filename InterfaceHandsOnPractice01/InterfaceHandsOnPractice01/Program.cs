using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Part 1


// A
//Create an interface named IMammal that includes the following methods:
//speak(): It should print to the console the sound made by the animal.
//run(): It should print to the console the top speed at which the animal can run.

// B
//Create three classes — Dog, Cat, and Cow — which implement the IMammal interface. Below is a list of print statements that should be made for each mammal's speak() and run() method:
//speak() list:
//Dog: "(What a tree has! (Bark)  What is on the top of your house (Roof) what is sandpaper (ruff)!""
//Cat: "I will sing my favorite song: three blind mice!"
//Cow: "Why did the cow cross the road?   To get to the Udder side!"
//run() list:
//Dog: "Dogs can run at a top speed of 45 mph!"
//Cat: "Cats don't run, but they can lie on the living-room sofa for hours at a time!"
//Cow: "Cows don't run, they just mooooove along!"

//In the Main method, instantiate new objects for a Dog, Cat, and Cow.
//Create a List of IMammal variable and called animals and attach it to a newly allocated list;
//Add each animal to the list.
//Using foreach, loop over the list and invoke the speak() and run() methods.


//The output will look like the following:
//(What a tree has! (Bark)  What is on the top of your house (Roof) what is sandpaper (ruff)!
//Dogs can run at a top speed of 45 mph!
//I will sing my favorite song: three blind mice!
//Cats don't run, but they can lie on the living-room sofa for hours at a time!
//Why did the cow cross the road?   To get to the Udder side!
//Cows don't run, they just mooooove along!
//Notice how even though your for loop is executing the exact same method each time through the loop, the actual method being executed is appropriate for each animal.


namespace Page18a
{
    //Create an interface named IMammal that includes the following methods:
    //speak(): It should print to the console the sound made by the animal.
    //run(): It should print to the console the top speed at which the animal can run.
    interface IMammal
    {
        void speak();
        void run();
    }

    //Create three classes — Dog, Cat, and Cow — which implement the IMammal interface.
    //Below is a list of print statements that should be made for each mammal's speak() and run() method:
    //speak() list:
    //Dog: "(What a tree has! (Bark)  What is on the top of your house (Roof) what is sandpaper (ruff)!""
    //Cat: "I will sing my favorite song: three blind mice!"
    //Cow: "Why did the cow cross the road?   To get to the Udder side!"
    //run() list:
    //Dog: "Dogs can run at a top speed of 45 mph!"
    //Cat: "Cats don't run, but they can lie on the living-room sofa for hours at a time!"
    //Cow: "Cows don't run, they just mooooove along!"
    class Dog : IMammal
    {
        public void speak()
        {
            Console.WriteLine("(What a tree has! (Bark)  What is on the top of your house (Roof) what is sandpaper (ruff)!");
        }
        public void run()
        {
            Console.WriteLine("Dogs can run at a top speed of 45 mph!");
        }

    }

    class Cat : IMammal
    {
        public void speak()
        {
            Console.WriteLine("I will sing my favorite song: three blind mice!");
        }
        public void run()
        {
            Console.WriteLine("Cats don't run, but they can lie on the living-room sofa for hours at a time!");
        }

    }

    class Cow : IMammal
    {
        public void speak()
        {
            Console.WriteLine("Why did the cow cross the road?   To get to the Udder side!");
        }
        public void run()
        {
            Console.WriteLine("Cows don't run, they just mooooove along!");
        }

    }

    public class Program
    {
        public static void Main()
        {
            Dog d = new Dog();
            Cat c = new Cat();
            Cow b = new Cow();  // b is for bovine!

            //Create a List of IMammal variable and called animals and attach it to a newly allocated list;

            //Add each animal to the list.

            //Using foreach, loop over the list and invoke the speak() and run() methods.

            //Notice how even though your for loop is executing the exact same
            //method each time through the loop, the actual method being executed is appropriate for each animal.

            List<IMammal> list = new List<IMammal>();
            list.Add(d);
            list.Add(c);
            list.Add(b);
            foreach (IMammal m in list)
            {
                m.speak();
                m.run();
            }


        }
    }



}


