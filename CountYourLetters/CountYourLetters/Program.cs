using System.Collections.Generic;

Console.WriteLine("Type a phrase on a single line");

string phrase = Console.ReadLine().ToUpper();
Dictionary<char, int> lettersCounter;
lettersCounter = new Dictionary<char, int>();

for (int i = 0; i < phrase.Length; i++)
{
    int value;
    if(i == 0 || !lettersCounter.TryGetValue(phrase[i], out value)){
        Console.WriteLine($"not seen '{ phrase[i]}' before, setting it to 1");
        lettersCounter.Add(phrase[i], 1);
    }
    else
    {
        lettersCounter[phrase[i]] = value + 1;
        if(lettersCounter[phrase[i]] == 2 )
        {
            Console.WriteLine($"Already counted {phrase[i]}, {lettersCounter[phrase[i]] - 1} time, adding one more");
        }
        else
        {
            Console.WriteLine($"Already counted {phrase[i]}, {lettersCounter[phrase[i]] - 1} times, adding one more");
        }
        
    }
}

foreach (KeyValuePair<char, int> entry in lettersCounter)
{
    if (entry.Value == 1)
    {
        Console.WriteLine($"'{entry.Key}' was found {entry.Value} time");
    }
    else
    {
        Console.WriteLine($"'{entry.Key}' was found {entry.Value} times");
    }
}


