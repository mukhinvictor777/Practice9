int getNumberFromUser(string userInformation)
{
    int  result = 0;
    while (result == 0 || result < 1)
    {
        Console.Write(userInformation);
        string userLine = Console.ReadLine();
        int.TryParse(userLine, out result);
        if (result == 0 || result < 1) Console.WriteLine($"Введите целое положительное число, вы вввели {userLine}"); 
        else break;
    }
    return result;
}

void numberRange(int N)
{
    if (N == 0)
    {
        return;
    }
    Console.Write($"{N}, ");
    numberRange(N - 1);
}

Console.Write("Введите значение N: ");
int userNumber = getNumberFromUser("");
Console.Write($"N = {userNumber} -> ");
numberRange(userNumber);
Console.WriteLine();
