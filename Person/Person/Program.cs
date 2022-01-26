using System;
namespace Exercise
{
    public class Person
    {
        string firstName;
        string lastName;

        // TODO: Accessors
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName
        {
            get
            {
                return (FirstName + " " + LastName);
            }
        }

        public Person()
        {
            this.firstName = "";
            this.lastName = "";
        }
        public Person(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }

    }
}

/*
In the Person class, add three property accessors:

A FirstName accessor that is a string that is responsible for getting and setting the protected firstName member variable.

A LastName accessor that is a string that is responsible for getting and setting the protected lastName member variable.

A FullName accessor that is a string that returns the first name concatenated with the last name with a space in between for its getter. There should be no setter.
 */