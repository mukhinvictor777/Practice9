void printArray(int[] incomingArray)
{
    Console.Write(" [ ");
    for (int i = 0; i < incomingArray.Length; i++)
    {
        Console.Write(incomingArray[i]);
        if (i < incomingArray.Length - 1)
        {
            Console.Write(" ");
        }
        Console.Write(" ] ");    
    }
}

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

int sumOfPositiveNumbers(int [] userArray)
{
    int sum = 0;
    for (int i = 0; i < userArray.Length; i++)
    {
        if (userArray[i] > 0)
        {
            sum = sum + userArray[i];
        }
    }
    return sum;
}

int sumOfNegativeNumbers(int [] userArray)
{
    int sum = 0;
    for (int i = 0; i < userArray.Length; i++)
    {
        if (userArray[i] < 0)
        {
            sum = sum + userArray[i];
        }
    }
    return sum;
}

int sumOfNumbersInArray(int [] userArray, int startIndex, int EndIndex)
{
    int sum = 0;
    for (int i = 0; i < userArray.Length; i++)
    {
        {
            sum = sum + userArray[i];
        }
    }
    return sum;
}

int[] sortArray(int[] incomingArray)
{
    int buffer = 0;
    for (int i = 0; i < incomingArray.Length - 1; i++)
    {
        for (int j = i; j < incomingArray.Length; j++)
        {
            if (incomingArray[j] < incomingArray[i])
            {
                buffer = incomingArray[i];
                incomingArray[i] = incomingArray[j];
                incomingArray[j] = buffer;
            }
        }
    }
    return incomingArray;
}

int [] RemovedElementInArray(int[] incomingArray, int index)
{
    if (incomingArray.Length - 1 == index)
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

void checkPlentyFromArray(int [] userArray, int plentySum)
{
    int sumOfPositive = sumOfPositiveNumbers (userArray);
    int sumOfNegative = sumOfNegativeNumbers (userArray);
    int sum = sumOfNumbersInArray(userArray, 0, userArray.Length);
    int tempLenght = userArray.Length;
    int [] plenty = userArray;
    int positive = 1;
    int negative = 1;
    int countOfActions = 0;
    Console.WriteLine();
    if (plentySum > sumOfPositive)
    {
        Console.Write("В множистве ");
        printArray(userArray);
        Console.WriteLine($" не существует подмножества с суммой всех элементов равной {plentySum}");
        Console.WriteLine();
    }
        else 
        if (plentySum < sumOfNegative)
        {
            Console.Write("В множистве ");
            printArray(userArray);
            Console.WriteLine($" не существует подмножества с суммой всех элементов равной {plentySum}");
            Console.WriteLine();
        }
        else
        {
            if (plentySum == 0)
            {
                Console.Write("В множистве ");
                printArray(userArray);
                Console.WriteLine(" существует пустое подмножество, где нет ни одного элемента");
                Console.WriteLine();
                countOfActions++;
                for (int i = 0; i < tempLenght; i++)
                {
                    if (plenty[i] == 0)
                    {
                        Console.Write("В множистве ");
                        printArray(userArray);
                        Console.WriteLine(" существует пустое подмножество, состоящее из [ 0 ]");
                        Console.WriteLine();
                        plenty = RemovedElementInArray(plenty, i);
                        tempLenght -= 1;
                        countOfActions++;
                    }
                }
            }
            if (sum == plentySum)
            {
                Console.Write("В множистве ");
                printArray(userArray);
                Console.WriteLine($" существует подмножество с суммой всех элементов равной {plentySum}");
                printArray(userArray);
                Console.WriteLine();
                countOfActions++;
            }
            for (int i = 0; i < tempLenght; i++)
            {
                if (plenty[i] == 0)
                {
                    plenty = RemovedElementInArray(plenty, i);
                    tempLenght -= 1; 
                }
            }
            plenty = sortArray(plenty);
            printArray(plenty);
            Console.WriteLine();
            tempLenght = plenty.Length;
            
            for (int i = 0; i < plenty.Length; i++)
            {
                if (plenty[i] < 0)
                {
                    positive = 0;
                    break;
                }
            }
            if (positive == 1)
            {
                for (int i = tempLenght - 1; i >= 0; i--)
                {
                    if (plentySum < plenty[i])
                    {
                        plenty = RemovedElementInArray(plenty, i);
                    }
                }
            }
            else
            {
                for (int i = 0; i < tempLenght; i++)
                {
                    if (plenty[i] > 0)
                    {
                        negative = 0;
                        break;
                    }
                }
                if (negative == 1)
                {
                    for (int i = 0; i < tempLenght; i++)
                    {
                        if (plenty[i] < plentySum)
                        {
                            plenty = RemovedElementInArray(plenty, i);
                            tempLenght--;
                        }
                    }
                }
            }
                      
            tempLenght = plenty.Length;
            printArray(plenty);
            Console.WriteLine();
            for (int i = 0; i < tempLenght; i++)
            {
                countOfActions++;
                if  (plenty[i] == plentySum)
                {
                    Console.Write("В множистве ");
                    printArray(userArray);
                    Console.WriteLine($" существует подмножество {plenty[i]} с суммой всех элементов равной {plentySum}");
                    Console.WriteLine();
                }
            }

            int difference = 0;
            int sumSecondCycle = 0;
            int sumTemporary = 0;
            int left = 0;
            int right = 0;
            int firstPositiveIndex = 0;
            int[] temporaryArray = {plenty[0]};
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
            // Начинается основной алгоритм перебора вариантов
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
        }
    }
    maxCountOfActions = Math.Pow(2, userArray.Length);
    Console.WriteLine($"Количество комбинаций множеств, перебранное алгоритмом равно {countOfActions}");
    Console.WriteLine($"Общее количество комбинаций множеств равно {maxCountOfActions}");
}

int [] userArray = new int [20] {-1, 0, -8, -5, -7, -5, -3, -15, 2, 4, 18, 25, 12, 9, -12, 0, 35, 3, 8, 11};
printArray(userArray);
checkPlentyFromArray(userArray, 40);