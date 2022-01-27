using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Part 1
//Create a base class named Employee(don't forget the constructor).
//This class should contain the following string variables:
//name
//salary
//hireDate
//Add the following three methods to the Employee class — each should be virtual:
//getName()
//getSalary()
//hiredDate()

//Each of the above methods should print out the value of the corresponding variable along with a label.
//See below for the output.

//Create a subclass named Engineer that inherits from Employee and includes a new string variable, schoolAttended. Don 't forget the constructor.
//Within the Main method, instantiate a new Engineer object and call each of the methods (from # 2).


//Your output should look similar to the following:
//Employee Name: Rupert Scott
//Salary: 42000
//Hire Date: 11 / 22 / 12



//Part 2
//Create a subclass of Engineer named SoftwareEngineer.
//Within the new class, create a method that will override the getSalary() method and
// print "Salary: Sorry, this employee's salary is private.".
//Create a new instance of the SoftwareEngineer class and call each of the three methods available.
//Your output should now look similar to the following:
//Employee Name: Rupert Scott
//Salary: 42000
//Hire Date: 11 / 22 / 12
//-------------------------------------------------- -
//Employee Name: Shea Rovington
//Salary: Sorry, this employee 's salary is private.
//Hire Date: 03 / 27 / 18

namespace Page19
{


    public class Employee
    {
        public string name;
        public double salary;
        public string hireDate;

        //Add the following three methods to the Employee class — each should be virtual:
        public virtual void getName()
        //public virtual string getName()
        {
            Console.WriteLine($"Employee Name: {this.name}");
            //return this.name;
        }
        public virtual void getSalary()
        //public virtual double getSalary()
        {
            Console.WriteLine($"Salary: {this.salary}");
            //return this.salary;
        }
        public virtual void hiredDate()
        //public virtual string hiredDate()
        {
            Console.WriteLine($"Hire Date: {this.hireDate}");
            //return this.hireDate;
        }

    }


    //Create a subclass named Engineer that inherits from Employee and includes a new string variable, schoolAttended. Don 't forget the constructor.
    class Engineer : Employee
    {
        public string schoolAttended;

        public Engineer() { }
        public Engineer(string schoolName)
        {
            this.schoolAttended = schoolName;
        }
        public Engineer(string name, double salary, string hiredDate, string School)
        {
            this.name = name;
            this.salary = salary;
            this.hireDate = hiredDate;
            this.schoolAttended = School;
        }

    }


    //Part 2
    //Create a subclass of Engineer named SoftwareEngineer.
    class SoftwareEngineer : Engineer
    {
        public SoftwareEngineer() { }

        public SoftwareEngineer(string name, double salary, string hiredDate, string School)
        {
            this.name = name;
            this.salary = salary;
            this.hireDate = hiredDate;
            this.schoolAttended = School;

        }

        //Within the new class, create a method that will override the getSalary() method and
        // print "Salary: Sorry, this employee's salary is private.".
        public override void getSalary()
        {
            Console.WriteLine("Salary: Sorry, this employee's salary is private");
        }
    }
    class Program
    {
        public static void Main()
        {
            ////part1  
            ////Uncomment the entire main for part 1, part two will still be commented out (since it has 4 slashes)
            Engineer engineer1 = new Engineer("Rupert Scott", 42000, "11/22/12", "Arizona State University");
            engineer1.getName();
            engineer1.getSalary();
            engineer1.hiredDate();



            //////part 2, now uncomment main again, and part 2 will become uncommented too
            //////Part two
            Console.WriteLine("------------------------------------");
            SoftwareEngineer softwareEngineer1 = new SoftwareEngineer("Shea Rovington", 78000, "03/27/18", "Tech School");
            softwareEngineer1.getName();
            softwareEngineer1.getSalary();
            softwareEngineer1.hiredDate();
        }
    }
}

