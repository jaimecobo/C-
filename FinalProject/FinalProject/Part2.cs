using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part2
{


    class EmployeeRecord
    {
        // create an employee Record with public properties
        //    ID                        a number to identify an employee
        //    Name                      the employee name
        //    StateCode                 the state collecting taxes for this employee
        //    HoursWorkedInTheYear      the total number of hours worked in the entire year (including fractions of an hour)
        //    HourlyRate                the rate the employee is paid for each hour worked
        //                                  assume no changes to the rate throughout the year.

        public int ID { get; set; }
        public string Name { get; set; }
        public string StateCode { get; set; }
        public decimal HoursWorkedInTheYear { get; set; }
        public decimal HourlyRate { get; set; }
        public decimal YearlyPay { get; }
        public decimal EmployeesTotalTaxDue { get; }

        //    provide a constructor that takes a csv and initializes the employeerecord
        //       do all error checking and throw appropriate exceptions
        public EmployeeRecord() { }
        public EmployeeRecord(string csv)
        {
            string[] data = csv.Split(',');
            if (data.Length != 5)
            {
                throw new Exception("Each line must have 'Employee ID', 'Name', 'State Code', 'Hours Worked' and 'Hourly Rate'. \n" +
                                    $"This line contains the following data: {csv} \n");
            }
            int toCarryTryParseInt;
            if (!int.TryParse(data[0], out toCarryTryParseInt))
            {
                throw new Exception($"Invalid Employee ID, the ID received is {data[0]}, Employee's IDs must be form by only integers values \n");
            }
            this.ID = toCarryTryParseInt;
            if (data[1].Length >= 20)
            {
                throw new Exception($"Invalid Employee Name, employee's names can not be longer than 20 characters, the name received is '{data[1]}' " +
                    $"that is {data[1].Length} long \n");
            }
            this.Name = data[1];
            if(data[2].Length != 2)
            {
                throw new Exception($"Invalid state code, the state code received is {data[2]}, state codes must be form by 2 capital letters \n");
            }
            this.StateCode = data[2];
            decimal toCarryTryParseDecimal;
            if (!decimal.TryParse(data[3], out toCarryTryParseDecimal))
            {
                throw new Exception($"The Hours Worked is not recognizable as decimal. -- Impossible to parse '{data[3]}' to decimal --\n");
            }
            this.HoursWorkedInTheYear = toCarryTryParseDecimal;
            if (!decimal.TryParse(data[4], out toCarryTryParseDecimal))
            {
                throw new Exception($"The Hourly Rate is not recognizable as decimal. -- Impossible to parse '{data[4]}' to decimal --\n");
            }
            this.HourlyRate = toCarryTryParseDecimal;
        }

        //    provide an additional READ ONLY property called  YearlyPay that will compute the total income for the employee
        //    by multiplying their hours worked by their hourly rate
        public decimal YearlyPayMethod(decimal hoursWorked, decimal hourlyRate)
        {
            //this.YearlyPay = hoursWorked * hourlyRate;
            return hoursWorked * hourlyRate;
        }


        //    provide an additional READONLY property that will compute the total tax due by:
        //    calling into the taxcalculator providing the statecode and the yearly income computed in the YearlyPay property
        public void EmployeesTotalTaxDueMethod(string name, string stateCode, decimal hrsWorked, decimal hrlyRate, bool verbose)
        {
            FinalProject.taxCalculator employeeTaxCalc = new  FinalProject.taxCalculator();
            Console.WriteLine($"\n{name.ToUpper()}'S TOTAL DUE TAXES IN '{stateCode}':");
            Console.WriteLine("TOTAL TAX DUE = " + employeeTaxCalc.ComputeTaxFor(stateCode, YearlyPayMethod(hrsWorked, hrlyRate), verbose) + "\n");
        }


        //    provide an override of toString to output the record : including the YearlyPay and the TaxDue
        public override string ToString()
        {
            return $"{ID,4} {Name,20} {StateCode,4} {HoursWorkedInTheYear, 10} {HourlyRate, 10}";
        }
    }

    // create an EmployeeList class that will read all the employees form the Employees.csv file
    // the logic is similar to the way the taxcalculator read its taxrecords
    class EmployeesList
    {
        // Create a List of employee records.  The employees are arranged into a LIST not a DICTIONARY
        // because we are not accessing the employees by state,  we are accessing the employees sequentially as a list
        public static List<EmployeeRecord> employeesList = new List<EmployeeRecord>();

        // create a static constructor to load the list from the file
        //   be sure to include try/catch to display messages
        static EmployeesList()
        {
            var reader = File.OpenText(@"employees.csv");
            string line;
            do
            {
                try
                {
                    line = reader.ReadLine();
                    EmployeeRecord eRecord = new EmployeeRecord(line);
                    Console.WriteLine(eRecord);
                    employeesList.Add(eRecord);
                    eRecord.EmployeesTotalTaxDueMethod(eRecord.Name, eRecord.StateCode, eRecord.HoursWorkedInTheYear, eRecord.HourlyRate, true);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            while (!reader.EndOfStream);
            reader.Close();

                //try
                //{
                //    foreach (var empList in employeesList)
                //    {
                //        Console.WriteLine(empList);
                //        empList.EmployeesTotalTaxDueMethod(empList.Name, empList.StateCode, empList.HoursWorkedInTheYear, empList.HourlyRate, true);
                //    }
                //}
                //catch (Exception ex)
                //{
                //    Console.WriteLine(ex.ToString());
                //}
           
            

        }
    }




    class Program
    {

        // loop over all the employees in the EmployeeList and print them
        // If the ToString() in the employee record is correct, all the data will print out.

        public static void MainPart2()
        {
            try
            {
                EmployeesList listOfEmplyees = new EmployeesList();
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}