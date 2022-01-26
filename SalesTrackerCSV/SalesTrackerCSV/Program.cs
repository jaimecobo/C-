/*
 *PROBLEM 2*
Expand the previous program to add the following features:

add another constructor to the sale object which will accept a csv line, parse it for correctness, and initialize the sale object with the data. 
The CSV line must contain an employeename, the salesamount and the commissionRate

validate three possible errors: (throw an exception with as much information as possible if one of these errors is discovered)

the csv line does not have the correct number of commas
the salesAmount is not recognizable as a decimal
the commission rate is not recognizable as a decimal
modify the Main to open a file called sales.csv containing sales data in a CSV format

create a list of sale objects (using System.Collections.Generic.List) and loop over each of the lines in the file to create a sale object using the constructor you just added

add the newly created object to the list on each iteration of the loop

place the construction code in a try-catch block: catch any exceptions, print them out, and continue executing the rest of the file. if an exception occurs, do not add the corrupted data to the list.

after reading all the data, close the reader

after reading all the data, now loop over all the data in the list, printing out an index and the item at that index.

now enter into an infinite loop and

Prompt the user to type in two numbers separated by spaces (from the list of data above)
parse the line and validate that the two numbers are correct
there should only be 2 numbers
both numbers should be able to be recognized as integers
if either number is negative, print out a message and try again (continue)
if either number is too large (larger that the count of elements in the list), print out a message and try again (continue)
if everything is fine with the numbers, add the two elements identified together and print out the results 
 */

public class sale
{
    //a public property of type string called Employee
    public string Employee
    { get; set; }
    //a public property of type decimal called SalesAmount
    public decimal SalesAmount
    { get; set; }
    //a private property of type decimal called commissionRate
    private decimal commissionRate
    { get; set; }


    //a public read only property of type decimal called Commission,
    //and it is to compute the commission by multiplying the SalesAmount times the commissionRate.
    public decimal Commission
    {
        get { return this.SalesAmount * this.commissionRate; }
    }

    // Empty constructor
    public sale()
    {
    }

    //a public constructor that accepts an employee name, a sales amount, and a commission rate to construct the sale object
    public sale(string name, decimal salesAmount, decimal commissionRate)
    {
        this.Employee = name;
        this.SalesAmount = salesAmount;
        this.commissionRate = commissionRate;
    }

    //a public constructor that accepts an employee name and a sales amount, and which sets the commission rate to 3% (.03)
    public sale(string name, decimal salesAmount)
    {
        this.Employee = name;
        this.SalesAmount = salesAmount;
        this.commissionRate = 0.03m;
    }

    // add another constructor to the sale object which will accept a csv line, parse it for correctness, and initialize the sale object with the data.
    // The CSV line must contain an employeename, the salesamount and the commissionRate
    // validate three possible errors: (throw an exception with as much information as possible if one of these errors is discovered)
    // the csv line does not have the correct number of commas
    // the salesAmount is not recognizable as a decimal
    // the commission rate is not recognizable as a decimal
    // modify the Main to open a file called sales.csv containing sales data in a CSV format
    public sale(string csv)
    {
        string[] data = csv.Split(',');
        if(data.Length != 3)
        {
            throw new Exception("The csv line does not have the correct number of elements, each line must have Employee, SaleAmount, and CommissionRate.");
        }

        this.Employee = data[0];
        decimal toCarryTryParse;
        if (!decimal.TryParse(data[1], out toCarryTryParse))
        {
            throw new Exception("The salesAmount is not recognizable as a decimal.");
        }
        this.SalesAmount = toCarryTryParse;

        if (!decimal.TryParse(data[2], out toCarryTryParse))
        {
            throw new Exception("The commission rate is not recognizable as a decimal.");
        }
        this.commissionRate = toCarryTryParse;

        
    }




    //an override of the ToString method which returns a string formatted with the following:
    //EmployeeName in a field 10 characters wide
    //SalesAmount in a field 15 characters wide, and rounded to 2 decimal places, with 4 spots on the left of the decimal point
    //CommissionRate in a field 10 characters wide, rounded to 3 decimal places, with 1 spot to the left of the decimal point
    //Commission
    public override string ToString()
    {
        //string EmployeeName = $"Employee:{this.Employee,10}    *";
        //string SalesAmount = $"    Sales:{this.SalesAmount,15:0000.00}    *";
        //string CommissionRate = $"    Rate:{this.commissionRate,10:0.000}    *";
        string commission = $"    Commision:{Commission,10:0.00}";
        //return EmployeeName + SalesAmount + CommissionRate + commission;

        return $"Employee:{Employee,10} Sales:{SalesAmount,15:0000.00} CommissionRate:{commissionRate,10:0.000} Commission:{commission}";
    }

    //a custom operator + which has the following features:
    //public static sale operator +(sale left, sale right) { implemented body }
    //    If the left employee is different than the right employee,
    //    throw an exception indicating that the left and right have to have the same employee name
    //    (show the actual values for left and right)
    //the newly created sales object will compute the new employee name by using the left employee name
    //    (the right employee name is the same)
    //the newly created sales object will compute the new sales amount by
    //    adding together the sales for the left and the right object
    //the newly created sales object will need to compute the new commissionRate by
    //    calculating the total commission for the left and right objects,
    //    and then divide this by the total sales for the left and the right objects.
    //    This formula will ensure that the commission on the newly created sale will be
    //    the sum of the two commissions on the left and right objects.
    //create a new sale object by calling the appropriate constructor providing the values computed above.
    //return the newly created sale object
    public static sale operator +(sale left, sale right)
    {
        if (left.Employee != right.Employee)
        {
            throw new Exception($"Can only add sale objects if the employee is the same, in this case left='{left.Employee}' and right='{right.Employee}'.");
        }
        decimal left_Right_Commission = left.Commission + right.Commission;
        decimal left_Rigth_Sale = left.SalesAmount + right.SalesAmount;
        decimal newCommissionRate = left_Right_Commission / left_Rigth_Sale;

        return new sale(left.Employee, left_Rigth_Sale, newCommissionRate);
    }

}


public class Program
{

    public static void Main()
    {
        System.IO.TextReader reader = System.IO.File.OpenText("sales.csv");
        List<sale> data01 = new List<sale>();
        while (!string.IsNullOrEmpty(reader.ReadLine()))
            //while (!string.IsNullOrWhiteSpace(reader.ReadLine()))
        {
            try
            {
                data01.Add(new sale(reader.ReadLine()));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        reader.Close();
        for (int i = 0; i < data01.Count; i++)
        {
            Console.WriteLine(data01[i]); 
        }

        string line;
        while (true)
        {
            Console.WriteLine("Type in two numbers separated by a space (from the list of data above)");
            line = Console.ReadLine();
            //if (string.IsNullOrEmpty(line))
            if (string.IsNullOrWhiteSpace(line))
            {
                break;
            }
            string[] data02 = line.Split(' ');
            if (data02.Length != 2)
            {
                Console.WriteLine("Input must have two numrbers separated by a space.");
            }
            else
            {
                int toCarryTryParse01;
                int toCarryTryParse02;
                if(!int.TryParse(data02[0], out toCarryTryParse01))
                {
                    Console.WriteLine($"The first parameter inserted with '{line}' is not and integer.");
                }
                if(!int.TryParse(data02[1], out toCarryTryParse02))
                {
                    Console.WriteLine($"The second parameter inserted with '{line}' is not and integer.");
                }
                if(toCarryTryParse01 <= 0)
                {
                    Console.WriteLine($"The first parameter inserted with '{line}' must be a positive number.");
                }
                if(toCarryTryParse02 <= 0)
                {
                    Console.WriteLine($"The second parameter inserted with '{line}' must be a positive number.");
                }
                if(toCarryTryParse01 >= data01.Count)
                {
                    Console.WriteLine($"The first paramenter inserted with '{line}' must be lower than '{data01.Count -1}'.");
                }
                if(toCarryTryParse02 >= data01.Count)
                {
                    Console.WriteLine($"The second paramenter inserted with '{line}' must be lower than '{data01.Count - 1}'.");
                }

                sale sale01 = data01[toCarryTryParse01];
                sale sale02 = data01[toCarryTryParse02];
                try
                {
                    sale sale03 = sale01 + sale02;
                    Console.WriteLine(sale03);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }
        //reader.Close();


    }
}