using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Create a new interface called IAnimal that contains a method called eat(),
//which will print out the favorite food for that animal.

//Update the IMammal interface to extend from the IAnimal interface.

//Update the classes that implement the IMammal interface to add an implementation the eat() method.
//The list of eat() responses for each animal is listed below:

//Dog: "Dogs eat anything I am eating!."
//Cat: "When they are hot, cats eat Mice cream!"
//Cow: "What is a cow laying down called?   Ground Beef."
//Add a new class "Bacterium" which only implements IAnimal. It's eat() should say: "Bacteria eat viruses."

// I did look this up on wikipedia to see what the singular and plural of Bacteria was.  I thought Bacteria was singular
// but it turned out to be the plural of Bacterium

// you are welcome to come up with your own humorous virus message.  The best one will be added the next time the class is run!
// and feel free to change up the other messages to make me laugh when grading... 

//In the Main method, change the List to be a List of IAnimal instead of a List of IMammal

//Create a Bacterium and add it to the List.

//Alter the foreach to use IAnimal instead of IMammal.

//Add code in the loop to check if the animal is in fact a mammal, and if so, then invoke their speak and run features. (hint Use is or as) Another Hint(?. can be used to conditionally call something only if the thing on the left is NOT null, this works well with as)

//Always call the eat method for all animals

//Your output will look like the following:

//(What a tree has! (Bark)  What is on the top of your house (Roof) what is sandpaper (ruff)!
//Dogs can run at a top speed of 45 mph!
//Dogs eat anything I am eating!.
//I will sing my favorite song: three blind mice!
//Cats don't run, but they can lie on the living-room sofa for hours at a time!
//When they are hot, cats eat Mice cream!
//Why did the cow cross the road?   To get to the Udder side!
//Cows don't run, they just mooooove along!
//What is a cow laying down called?   Ground Beef.
//Bacteria eat viruses.




namespace Page18b
{
    //Create a new interface called IAnimal that contains a method called eat(),
    //which will print out the favorite food for that animal.
    interface IAnimal
    {
        void eat();
    }

    // you can cut and paste your existing interface and animal classes here as a starting point if you want
    interface IMammal : IAnimal
    {
        void speak();
        void run();
    }

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
        public void eat()
        {
            Console.WriteLine("Dogs eat anything I am eating!.");
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
        public void eat()
        {
            Console.WriteLine("When they are hot, cats eat Mice cream!");
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
        public void eat()
        {
            Console.WriteLine("What is a cow laying down called?   Ground Beef.");
        }

    }
    // end of cut and paste region   you should start with these classes in this Part 2

    //Add a new class "Bacterium" which only implements IAnimal. It's eat() should say: "Bacteria eat viruses."

    class Bactrium : IAnimal
    {
        public void eat()
        {
            Console.WriteLine("Bacteria eat viruses.");
        }
    }

    public class Program
    {
        public static void Main()
        {
            Dog d = new Dog();
            Cat c = new Cat();
            Cow b = new Cow();  // b is for bovine!

            //Create a Bacterium and add it to the List.  (done for you - you're welcome!)

            Bactrium p = new Bactrium(); // p is for Planktonic Bacteria from Sponge Bob


            //In the Main method, change the List to be a List of IAnimal instead of a List of IMammal
            List<IAnimal> a = new List<IAnimal>();
            a.Add(d);
            a.Add(c);
            a.Add(b);
            a.Add(p);

            Console.WriteLine("------------------------------------------------------------");
            foreach (IAnimal animal in a)
            {
                (animal as IMammal)?.speak();
                Console.WriteLine("###########");

                if (animal is IMammal)
                {
                    IMammal m = (IMammal)animal;
                    m.run();
                }
                Console.WriteLine("************");
                animal.eat();
                Console.WriteLine("\\\\\\\\\\\\//////");
            }



            //Alter the foreach to use IAnimal instead of IMammal.

            //Always call the eat method for all animals

            //Add code in the loop to check if the animal is in fact a mammal,
            //and if so, then invoke their speak and run features.
            //(hint Use is or as)


            // eat is always called 
            // use IS for the run
            // use AS for the speak

            // this way you see how both techniques work, and can see which you like better

            // use IS for the run

            // if (condition)
            //  {
            //       //create a variable of the correct type using a cast, then call the methods in the interface
            //       IMammal m = (IMammal) variable;
            //       m.run();
            //  }
            // where the condition is asking the question IS the variable   'a'  an 'IMammal'
            // IS is an operator    (is somevariable on left of IS) IS (some type to check on right of IS)
            // the IS operator is a CONDITIONAL operator that returns TRUE
            // if the variable on the left is in fact derived from the type on the right of the keyword IS
            // otherwise it returns FALSE
            // the keyword IS is actually in lowercase I capitalized it in the comment for effect

            // the condition would look something like:
            //      variable is IMammal


            // use AS and ?.   for the speak  

            // when using AS, you do not need an if, because it is built into the ?. operator

            //  What is ?.
            //  ?. is an operator that CONDITIONALLY invokes the method on the Right 
            //    based upon whether the item on the left is null or not.
            //       if the thing on the LEFT is NULL, then the method on the right is not Invoked
            //       if the thing on the LEFT is NOT NULL, then the method on the right is in fact Invoked

            // the ?. is designed to be used in combination with AS because AS will
            //           return null if the thing on the left of AS is not derived from the thing on the right
            //   or will return the thing on hte left if the thing on hte left is in fact derived from the thing on the right


            //  so

            //  (variable as IMammal)   will either evaluate to null or to variable.
            //      if the variable implements the interface IMammal, then (variable as IMammal) returns the variable
            //  but if the variable does not implement the interface, then (variable as IMammal) returns null

            // so 

            // (variable as IMammal)?.speak();   will either call speak() or not.
            // 

            // I see a teaching opportunity, and can not let it go.
            // even though this is not need in THIS lab,  the ?. operator can be used '''fluently'''
            // it was designed to be able to be 'chained' together like

            // (variable AS IType)?.Property?.SubPropertyinProperty?.SubSubProperty??optionalvalue;

            // this will be evaluated like:
            // (variable AS IType)      does variable implement the interface IType?  yes: return variable   no : return null
            // (variable AS IType) ?. Property
            //                left    right
            //                          did we get null on the previous step (is left null),
            //                                then dont get the property and forward null to the next step
            //                          did we get the variable on the previous step,  then return the property on the variable
            // (variable AS IType)?.Property  ?.  SubProperty
            //                          left      right
            //                          did we get null on the previous step(is left null),
            //                                then dont get the Subproperty and forward null to the next step
            //                          did we get the property on the previous step,
            //                                then return the subProperty on the Property
            // (variable AS IType)?.Property?.SubProperty  ?.  SubPropertyInProperty
            //                                       left      right
            //                          did we get null on the previous step(is left null),
            //                                then dont get the SubPropertyInProperty and forward null to the next step
            //                          did we get the subProperty on the previous step,
            //                                then return the subpropertyInProperty on the SubProperty
            // (variable AS IType)?.Property?.SubProperty?.SubPropertyInProperty  ?? optionavalue;
            //                                                              left     right
            //                          did we get null on the previous step(is left null),
            //                                then  forward the optionalvalue to the next step
            //                          did we get the subproperty on the previous step,
            //                                then return the subPropertyInProperty on the SubProperty to the next step

            // notice that the last one is a ?? it is similar to the final else clause or the default case 
            // ?. is similar to a set of nested 'if else' statements, once one fails (by returning null) then the
            // null will go all the way down the line until it reaches the ?? and will return what it finds there.
            // as long as all the ?. operators dont fail by returning null, then the final one will be returned as the final answer.


            // so here is your reward for reading all the way to the end:
            // you have reached the end of the teaching opportunity

            // (variable as IMammal)?.speak()   is the answer you are seeking.  if will either safely call speak or wont


        }
    }



}

