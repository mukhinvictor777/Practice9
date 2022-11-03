void printArrayFromIndex(int[] incomingArray, int startIndex, int endIndex)
{
    Console.Write(" [ ");
    for (int i = startIndex; i <= endIndex; i++)
    {
        Console.Write(incomingArray[i]);
        if (i < incomingArray.Length - 1)
        {
            Console.Write(" ");
        }   
    }
}

int getLenghtFromUser(string userInformation)
{
    int  result = 0;
    while (result == 0 || result < 1)
    {
        Console.Write(userInformation);
        string userLine = Console.ReadLine();
        int.TryParse(userLine, out result);
        if (result == 0 || result < 1) Console.WriteLine($"Введите целое число больше нуля, вы вввели {userLine}"); else break;
    }
    return result;
}

int getNumberFromUser(string userInformation)
{
    int  result = 0;
    while (result == 0)
    {
        Console.Write(userInformation);
        string userLine = Console.ReadLine();
        int.TryParse(userLine, out result);
        if (result == 0 && userLine != "0") Console.WriteLine($"Введите целое, вы вввели {userLine}"); else break;
    }
    return result;
}


int [] getRandomArray(int arrayLenght, int startPoint, int endPoint)
{
    int [] randomArray = new int [arrayLenght];
    for (int i = 0; i < arrayLenght; i++)
    {
        randomArray[i] = new Random().Next(startPoint, endPoint + 1);
    }
    return randomArray;
}


int [] createCopyArray(int[] incomingArray)
{
    int [] copiedArray = new int [incomingArray.Length];
    for (int i = 0; i < copiedArray.Length; i++)
    {
        copiedArray[i] = incomingArray[i];
    }
    return copiedArray;
}  

int [] RemovedElementInArray(int[] incomingArray, int index)
    {
        if (incomingArray.Length == index)
        {
            Array.Resize(ref incomingArray, incomingArray.Length - 1);
        }
        else
        {
            for (int i = index; i < incomingArray.Length - 1; i++)
            {
                incomingArray[i] = incomingArray[i+1];
            }
            Array.Resize(ref incomingArray, incomingArray.Length - 1);
        }
        return incomingArray;
    }

int [] addElementInArray(int[] incomingArray, int index, int element)
    {
        Array.Resize(ref incomingArray, incomingArray.Length + 1);
            for (int i = index; i < incomingArray.Length - 1; i++)
            {
                incomingArray[i+1] = incomingArray[i];
            }
            incomingArray[index] = element;
    return incomingArray;
    }
          
            
            int difference = 0;
            int sumSecondCycle = 0;
            int sumTemporary = 0;
            int firstPositiveIndex = 0;
            for (int i = 0; i < tempLenght; i++)
            {
                if (plenty[i] > 0)
                {
                    firstPositiveIndex = i;
                    break;
                }
                else
                {
                    firstPositiveIndex = tempLenght - 1;
                }
            }
            while (temporaryArray.Length < tempLenght - 1)
            {
                for (int k = 0; k < temporaryArray.Length; k++)
                {
                    for (int i = 0; i < tempLenght-1; i++)
                    {
                        temporaryArray[k] = plenty[i];
                        sumSecondCycle = sumOfNumbersInArray(temporaryArray, 0, temporaryArray.Length);
                        difference = plentySum - sumSecondCycle;
                        if (difference == 0)
                        {
                            Console.Write("В множистве ");
                            printArray(userArray);
                            Console.WriteLine($" существует подмножество с суммой всех элементов равной {plentySum}");
                            printArray(temporaryArray);   
                        }
                        else
                        {
                            if (difference > 0)
                            {
                                if (difference > plenty[tempLenght-1])
                                {
                                    break;
                                }
                                else
                                    {
                                        left = firstPositiveIndex;
                                        right = tempLenght - 1;
                                        while (right > left)
                                        {
                                            countOfActions++;
                                            if (difference == plenty[right])
                                            {
                                                Console.Write("В множистве ");
                                                printArray(userArray);
                                                Console.WriteLine($" существует подмножество с суммой всех элементов равной {plentySum}");
                                                printArrayFromIndex(plenty, startIndex, endIndex);
                                                console.Write($" {plenty[right]} ] ");
                                                Console.WriteLine();  
                                            }
                                            else
                                            {
                                                left = (right - left)/2;
                                            }
                                        }
                                    }
                            }
                        }
                    }
                Array.Resize(ref temporaryArray, temporaryArray.Length + 1);
            }

{-1, 0, -8, -5, -7, -5, -3, -15, 2, 4, 18, 25, 12, 9, -12, 0, 35, 3, 8, 11};