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

int AvStepeniB(int A, int B)
{
    if (B == 0)
    {
        
        return 1;
    }
    else
    {
        return A * AvStepeniB(A, B - 1);
    }
}

Console.Write("Введите значение число A: ");
int A = getNumberFromUser("");
Console.Write("Введите значение число B: ");
int B = getNumberFromUser("");
int stepenAB = AvStepeniB(A, B);
Console.Write($"A = {A}; B = {B} -> {stepenAB} ({A} ^ {B})");
Console.WriteLine();