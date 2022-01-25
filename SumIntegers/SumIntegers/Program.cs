Console.WriteLine("Enter as many integers as you want separated by spaces, press return when are ready for the sum");
string[] numbers = (Console.ReadLine()).Split();
int result = 0;
for (int i = 0; i < numbers.Length; i++)
{
    bool isNumber;
    if (isNumber = int.TryParse(numbers[i], out int n))
    {
        result += Convert.ToInt32(numbers[i]);
        Console.WriteLine($"Accepted: {numbers[i]}, total now is {result} ");
    }
    else
    {
        Console.WriteLine($"Rejected: '{numbers[i]}' invalid integer");
    }
}

    Console.WriteLine($"The total final sum of acceptable integers is {result}");

