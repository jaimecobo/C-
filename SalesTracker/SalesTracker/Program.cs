/*
Create a new console application called SalesTracker and create a class called sale with the following features:

a public property of type string called Employee
a public property of type decimal called SalesAmount
a private property of type decimal called commissionRate
a public read only property of type decimal called Commission, and it is to compute the commission by multiplying the SalesAmount times the commissionRate.
a public constructor that accepts an employee name, a sales amount, and a commission rate to construct the sale object
a public constructor that accepts an employee name and a sales amount, and which sets the commission rate to 3% (.03)
an override of the ToString method which returns a string formatted with the following:
EmployeeName in a field 10 characters wide
SalesAmount in a field 15 characters wide, and rounded to 2 decimal places, with 4 spots on the left of the decimal point
CommissionRate in a field 10 characters wide, rounded to 3 decimal places, with 1 spot to the left of the decimal point
Commission
a custom operator + which has the following features:
public static sale operator + (sale left, sale right) { implemented body }
If the left employee is different than the right employee, throw an exception indicating that the left and right have to have the same employee name 
(show the actual values for left and right)
the newly created sales object will compute the new employee name by using the left employee name (the right employee name is the same)
the newly created sales object will compute the new sales amount by adding together the sales for the left and the right object
the newly created sales object will need to compute the new commissionRate by calculating the total commission for the left and right objects, 
and then divide this by the total sales for the left and the right objects. 
This formula will ensure that the commission on the newly created sale will be the sum of the two commissions on the left and right objects.
create a new sale object by calling the appropriate constructor providing the values computed above.
return the newly created sale object
Test the sale object by using the following Main which creates several sale objects , 
prints them out using Console.WriteLine, and then adds them together to see if they work as expected.
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

        sale s1 = new sale("One", 1000, .10M);
        sale s2 = new sale("One", 500, .05M);
        sale s3 = new sale("Two", 2500, .10M);
        sale s4 = new sale("Two", 3000);

        try
        {
            Console.WriteLine(s1);
            Console.WriteLine(s2);
            Console.WriteLine(s3);
            Console.WriteLine(s4);
            Console.WriteLine(s1 + s2);
            Console.WriteLine(s3 + s4);
            Console.WriteLine(s2 + s3);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
    