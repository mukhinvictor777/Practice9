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

int Akkerman(int M, int N)
{
    if (M == 0)
    {
        return N + 1;
    }
    else 
    {
        if (M != 0 && N == 0)
        {
            return Akkerman(M - 1, 1);
        }
        else
        {
            return Akkerman(M - 1, Akkerman(M, N - 1));       
        }
    }
}

Console.Write("Введите значение M: ");
int userNumberM = getNumberFromUser("");
Console.Write("Введите значение N: ");
int userNumberN = getNumberFromUser("");
int akk = Akkerman(userNumberM, userNumberN);
Console.Write($"M = {userNumberM}; N = {userNumberN} -> A({userNumberM},{userNumberN}) = {akk}");
Console.WriteLine();