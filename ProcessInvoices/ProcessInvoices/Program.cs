

string file = "invoices.dat";
DateTime currentDate = DateTime.Today;

//Console.WriteLine($"The Date used for calculating late fees is {currentDate.ToShortDateString()}");
Console.WriteLine("The Date used for calculating late fees is 4/29/2021");
readFile(file);


static void computeLateFees(int index, DateTime dueDate, decimal invoice)
{
    //DateTime currentDate = DateTime.Today;
    var currentDate = new DateTime(2021, 4, 29);
    decimal lateFee = 0.00m;
    System.TimeSpan days = currentDate.Subtract(dueDate);
    decimal daysPassed = Convert.ToDecimal(days.TotalDays);
    if (daysPassed < 1)
    {
        lateFee = 0.00m;
    }
    else if (daysPassed <= 7)
    {
        lateFee = invoice * (0.1m * daysPassed);
    }
    else if(daysPassed > 7)
    {
        daysPassed = daysPassed - 7;
        lateFee = (invoice * (0.1m * 7)) + (invoice * (0.01m * daysPassed));
    }
    
    Console.WriteLine($"Invoice: {index}          Due: {dueDate.ToShortDateString()}          Amount: {invoice}          Late Fee: {lateFee.ToString("C2")}");
   
}
 
static void readFile(string file)
{
    var reader = System.IO.File.OpenText(file);
    while (true)
    {
        string line = reader.ReadLine();
        DateTime dueDate;
        decimal invoiceAmount;
        string[] invoiceData = line.Split(',');
        int index_ID;

        if (invoiceData.Length != 3)
        {
            Console.WriteLine("Invalid line, each line must cotain an Index_ID, a date, and a monetary value.");
        }
        else if(!int.TryParse(invoiceData[0], out index_ID)){
            Console.WriteLine($"Expected element 0 in  {"'" + invoiceData[0] + ", " + invoiceData[1] + ", " + invoiceData[2] + "'"} must be an integer.");
        }
        else if (!DateTime.TryParse(invoiceData[1], out dueDate)){
            Console.WriteLine($"Expected element 1 in  {"'" + invoiceData[0] + ", " + invoiceData[1] + ", " + invoiceData[2] + "'"} must be a date.");
        }
        else if (!decimal.TryParse(invoiceData[2], out invoiceAmount))
        {
            Console.WriteLine($"Expected element 2 in  {"'" + invoiceData[0] + ", " + invoiceData[1] + ", " + invoiceData[2] + "'"} must be a decimal.");
        }
        else
        {
            index_ID = int.Parse(invoiceData[0]);
            dueDate = DateTime.Parse(invoiceData[1]);
            invoiceAmount = Convert.ToDecimal(invoiceData[2]);
            computeLateFees(index_ID, dueDate, invoiceAmount);

        }
    }
}
    
 

