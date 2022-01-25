using System.Text;

int number;
bool isParsable;
Console.Write("Usage: This program expects to be provided a single integer command line argument. \nPlease enter an integer value: ");
string input = Console.ReadLine();

//if(isParsable = int.TryParse(Console.ReadLine(), out number)){
if (isParsable = int.TryParse(input, out number))
{
    Console.WriteLine(MakeALlLines(number));
}
else
{
    Console.WriteLine($"Usage: The supplied parameter '{input}' is not a valid integer");
    //Console.WriteLine("You must enter a valid integer, please try again");
}


static string MakeALine(int num)
{
    StringBuilder numString = new StringBuilder("");
    for (int i = 1; i <= num; i++)
    {
        if (numString.Equals(""))
        {
            numString.Append(num);
        }
        else
        {
            numString.Append(" " + num);
        }
    }
    return numString.ToString();

}

static string MakeALlLines(int num)
{
    StringBuilder fullNumString = new StringBuilder("");
    for ( int i = 1; i <= num; i++)
    {
        if (fullNumString.Equals(""))
        {
            fullNumString.Append(MakeALine(i));
        }
        else
        {
            fullNumString.Append("\n" + MakeALine(i));
        }
    }
    return fullNumString.ToString();   

}
