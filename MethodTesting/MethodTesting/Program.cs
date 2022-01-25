int data = 10;

//Console.WriteLine();
//OutWork(out data);
//Console.WriteLine($"After OutWork: in Main, the value of data is {data}");

Console.WriteLine($"Before: in Main, the value of data is {data}");
NormalWork(data);   // The value of data is passed as an argument into NormalWork
Console.WriteLine($"After NormalWork: in Main, the value of data is {data}");

Console.WriteLine();
ReferenceWork(ref data);
Console.WriteLine($"After ReferenceWork: in Main, the value of data is {data}");

Console.WriteLine();
OutWork(out data);
Console.WriteLine($"After OutWork: in Main, the value of data is {data}");



static void NormalWork(int i)       // i is a formal paramenter, i is passed by value
{
    Console.WriteLine($"Before: in NormalWork, the value of i is {i}");
    i = i * 10 + 9;
    Console.WriteLine($"After: in NormalWork, the value of i is {i}");
}


static void ReferenceWork(ref int i)    // i is now passed 'by ref' instead of normal
{
    Console.WriteLine($"Before: in ReferenceWork, the value of i is {i}");
    i = i * 10 + 9;
    Console.WriteLine($"After: in ReferenceWork, the value of i is {i}");
}


static void OutWork(out int i)    // i has no value assigned, the value of i will be assigned inside the method
{
    //Console.WriteLine($"Before: in OutWork, the value of i is {i}");
    i = 10 + 9;
    Console.WriteLine($"After: in OutWork, the value of i is {i}");
}
