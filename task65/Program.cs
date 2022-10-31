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

void printRangeFromMtoN(int M, int N)
{
    if (N == M - 1)
    {
        return;
    }
    printRangeFromMtoN(M, N - 1);
    Console.Write($"{N}, ");
}

Console.Write("Введите значение M: ");
int userNumberM = getNumberFromUser("");
Console.Write("Введите значение N: ");
int userNumberN = getNumberFromUser("");
if (userNumberM > userNumberN)
{
    int buffer = userNumberN;
    userNumberN = userNumberM;
    userNumberM = buffer;
}
Console.Write($"M = {userNumberM}; N = {userNumberN} -> ");
printRangeFromMtoN(userNumberM, userNumberN);
Console.WriteLine();