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

int SumOfDigitFromNumber(int number)
{
    if (number / 10 == 0)
    {
        
        return number % 10;
    }
    else
    {
        return SumOfDigitFromNumber(number / 10) + number % 10;
    }
}

Console.Write("Введите значение число: ");
int userNumber = getNumberFromUser("");
int sumOfDigit = SumOfDigitFromNumber(userNumber);
Console.Write($"{userNumber} -> {sumOfDigit}");
Console.WriteLine();