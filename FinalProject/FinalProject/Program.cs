/*
Create a new C# project as you have done throughout this course. Name this project finalProject.

Part 1:
The file https:/resources.api.exeterlms.com/content/courses/ADN102/20210916181932/media/taxtable.csv is located in your student resources, 
and looks similar to this excel representation:
the first column represents state code for a state
the second column is the state name spelled out
the third column is the floor for the tax rate. The amount being taxed should be greater than or equal to this value.
the fourth column is the ceiling for the tax rate. The amount being taxed should be strictly less than this value. 
The special value 9999999999 is used to indicate that there is not a ceiling.
the fifth column is the tax rate to be applied for values in that range.
the rates are cumulative, i.e. the first 499 dollars earned in AL (Alabama) will be taxed at the rate of 2%, 
then the next 2500 dollars earned will be taxed at the rate of 4%, and every dollar over 3000 is taxed at 5%.

Create a class TaxCalculator that automatically reads the information in this file at startup with no functions being invoked by the Main entry point 
(think about a special type of constructor that does this), and exposes a single static method: ComputeTaxFor that accepts two values, a state abbreviation, 
and an income amount earned. The method should compute the tax due and return the tax as a decimal.

Be sure to have your program check the data file for formatting errors, print out why the parsing failed, and ignore the lines.

The TaxCalculator should have a setting allowing it to be silent or verbose. In silent mode it will just return the tax, in verbose mode it will explain in detail 
(using console.WriteLine)how the tax calculation was computed.

Create a Main method to allow you to test the tax calculator. You should be able to enter a state abbreviation and a amount earned. Test the calculator in verbose mode.

 *******************************************************************
Part 2:
Extend the program to read another CSV file containing Employees.
The file employees.csv is located in the same place where you found https:/resources.api.exeterlms.com/content/courses/ADN102/20210916181932/media/taxtable.csv
Each employee should have a ID, Name, State code, Number of hours worked (for the year) and an hourly rate. 
Read the csv file into a class named EmployeeRecord, and provide an additional computed property which returns the tax due for that employee using the tax calculator created in step 1. After reading the employees into the list, print out the list of employees along with the tax due.

Note: You will need to use the tax calculator from part 1 to calculate the appropriate state tax.

********************************************************************
Extend the program again to allow the user to sort the list of employees by one of several attributes:
State
Employee ID
Employee Name
Yearly Pay
Tax due




Dictionary<String, List<string>> dic = new Dictionary<string, List<string>>();

            List<string> li1 = new List<string>();
            li1.Add("text1"); li1.Add("text2"); li1.Add("text3"); li1.Add("text4");

            List<string> li2 = new List<string>();
            li2.Add("text1"); li2.Add("text2"); li2.Add("text3"); li2.Add("text4");

            dic["1"] = li1;
            dic["2"] = li2;


            foreach (string key in dic.Keys)
            {
                foreach (string val in dic[key])
                {
                    Console.WriteLine(val);
                }

*/

using System.Linq;
//namespace Final_Project
//{
    public class TaxRecord
    {
        public string statecode;
        public string statename;
        public decimal floorRate;
        public decimal ceilingRate;
        public decimal taxRate;

        public TaxRecord() { }
        public TaxRecord(string csv)
        {
            string[] data = csv.Split(',');
            if (data.Length != 5)
            {
                throw new Exception("Each line must have 'State Code', 'State Name', 'Floor Rate', 'Ceiling Rate' and 'Tax Rate'. \n" +
                                    $"This line contains the following data: {csv} \n");
            }
            if (data[0].Length != 2)
            {
                throw new Exception($"Invalid state code, the state code received is {data[0]}, state codes must be form by 2 capital letters \n");  //The state code is not equal to two.
            }
            this.statecode = data[0];
            this.statename = data[1];
            decimal toCarryTryParseDecimal;
            if (!decimal.TryParse(data[2], out toCarryTryParseDecimal))
            {
                throw new Exception($"The floor rate is not recognizable as decimal. -- Impossible to parse '{data[2]}' to decimal --\n");
            }
            this.floorRate = toCarryTryParseDecimal;
            if (!decimal.TryParse(data[3], out toCarryTryParseDecimal))
            {
                throw new Exception($"The ceiling rate is not recognizable as decimal. -- Impossible to parse '{data[3]}' to decimal --\n");
            }
            this.ceilingRate = toCarryTryParseDecimal;
            if (!decimal.TryParse(data[4], out toCarryTryParseDecimal))
            {
                throw new Exception($"The tax rate is not recognizable as decimal. -- Impossible to parse '{data[4]}' to decimal --\n");
            }
            this.taxRate = toCarryTryParseDecimal;

        }

        public override string ToString()
        {
            return $"{statecode,4} {statename,15} {floorRate,10} {ceilingRate,10} {taxRate}";
        }




    }

    class taxCalculator
    {
        static Dictionary<string, List<TaxRecord>> taxRecords = new Dictionary<string, List<TaxRecord>>();
        static taxCalculator()
        {

            var reader = File.OpenText(@"taxtable.csv");
            string line;
            do
            {
                try
                {
                    line = reader.ReadLine();
                    TaxRecord r = new TaxRecord(line);
                    Console.WriteLine(r);
                    if (taxRecords.ContainsKey(r.statecode))
                    {
                        taxRecords[r.statecode].Add(r);
                    }
                    else
                    {
                        List<TaxRecord> list = new List<TaxRecord>();
                        list.Add(r);
                        taxRecords.Add(r.statecode, list);
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            while (!reader.EndOfStream);
            reader.Close();
        }

        public decimal ComputeTaxFor(string stateAbv, decimal incomeEarned, bool verbose)
        {
            if (verbose)
            {
            //Console.WriteLine($"  ---------------------------------------------------------------------------------------------------------------------------");
            //Console.WriteLine($" {"| Your total income is = ",25} {incomeEarned,12}{"                                                    |",87}");
            //Console.WriteLine(" |---------------------------------------------------------------------------------------------------------------------------|");
            //Console.WriteLine($"{" |       INCOME",12} {" -",4} {"FLOOR RATE",12} {"=",4} {"TAXABLE",12} {"*",3} {"  TAX RATE  ",8} {"=",1} {"    TAX DUE  |",55}");
            //Console.WriteLine(" |---------------------------------------------------------------------------------------------------------------------------|");
            Console.WriteLine("\n");
            Console.WriteLine($"  --------------------------------------------------------------------------------------");
            Console.WriteLine($" {"| Your total income is = ",25} {incomeEarned,12}{"                                               |",50}");
            Console.WriteLine(" |--------------------------------------------------------------------------------------|");
            Console.WriteLine($"{" |       INCOME",12} {" -",4} {"FLOOR RATE",12} {"=",4} {"TAXABLE",12} {"*",3} {"  TAX RATE  ",8} {"=",1} {"    TAX DUE  |",18}");
            Console.WriteLine(" |--------------------------------------------------------------------------------------|");
        }
            decimal finalComputedTax = 0m;

            foreach (string statecode in taxRecords.Keys)
            {
                if (!taxRecords.ContainsKey(stateAbv))
                {
                    throw new Exception($"There is no record for state '{stateAbv}' \n");
                }
                foreach (TaxRecord r in taxRecords[statecode])
                {
                    if (r.statecode == stateAbv)
                    {
                        //Console.WriteLine($"{r.statecode}");
                        //Console.WriteLine($"{r.statecode} - {r.floorRate,10} - {r.ceilingRate,10} - {r.taxRate, 10}");
                        if (incomeEarned >= r.ceilingRate)
                        {
                            finalComputedTax += (r.ceilingRate - r.floorRate) * r.taxRate;
                            if (verbose)
                            {
                                //Console.WriteLine($" | {r.ceilingRate,12} {"-",4} {r.floorRate,12} {"=",4} {r.ceilingRate - r.floorRate,12} {" * ",4} " +
                                //    $"{r.taxRate,8} {"=",4} {"  tax due for this income portion =",36} {finalComputedTax,15}  |");
                                Console.WriteLine($" | {r.ceilingRate,12} {"-",4} {r.floorRate,12} {"=",4} {r.ceilingRate - r.floorRate,12} {" * ",4} " +
                                    $"{r.taxRate,8} {"=",4} {finalComputedTax,15}  |");
                        }
                            continue;
                        }

                        if (incomeEarned > r.floorRate && incomeEarned < r.ceilingRate)
                        {
                            finalComputedTax += (incomeEarned - r.floorRate) * r.taxRate;
                            if (verbose)
                            {
                            //Console.WriteLine($" | {incomeEarned,12} {"-",4} {r.floorRate,12} {"=",4} {incomeEarned - r.floorRate,12} {" * ",4} " +
                            //    $"{r.taxRate,8} {"=",4} {"  tax due for this income portion =",36} {finalComputedTax,15}  |");
                            Console.WriteLine($" | {incomeEarned,12} {"-",4} {r.floorRate,12} {"=",4} {incomeEarned - r.floorRate,12} {" * ",4} " +
                                $"{r.taxRate,8} {"=",4} {finalComputedTax,15}  |");

                        }
                        }
                    }


                }
            }
            if (verbose)
            {
            //Console.WriteLine(" |---------------------------------------------------------------------------------------------------------------------------|");
            //Console.WriteLine($" {"|                                                                            TOTAL TAX DUE = ",85} {finalComputedTax,15:0000.00} {"              |",15}");
            //Console.WriteLine($"{"  ---------------------------------------------------------------------------------------------------------------------------"}");
            Console.WriteLine(" |--------------------------------------------------------------------------------------|");
            Console.WriteLine($" {"|                                            TOTAL TAX DUE = ",49} {finalComputedTax,15:0.00} {"         |",9}");
            Console.WriteLine($"{"  --------------------------------------------------------------------------------------"}");
        }
            return finalComputedTax;
        }
    }


    class Program
    {
        public static void Main()
        {
            taxCalculator taxCalc = new taxCalculator();
            Console.WriteLine("\n TOTAL TAX DUE = " + taxCalc.ComputeTaxFor("CA", 9, true) + "\n");
        }
    }

//}