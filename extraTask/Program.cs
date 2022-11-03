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
    }
    Console.Write(" ] ");
}

void printColorData(string data)
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.Write(data);
    Console.ResetColor();
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
    for (int i = startIndex; i <= EndIndex; i++)
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
    int sum = sumOfNumbersInArray(userArray, 0, userArray.Length-1);
    int tempLenght = userArray.Length;
    int[] plenty = new int [userArray.Length];
    int positive = 1;
    int negative = 1;
    int countOfActions = 0; // счетчик количества перебранных алгоритмом комбинаций для сравнения эффективности с общим числом всех возможных комбинаций
    int cointOfAnswers = 0; // счетчик числа найденных подмножеств
    Console.WriteLine();
    if (plentySum > sumOfPositive)
    {
        Console.Write("В множистве ");
        printArray(userArray);
        Console.WriteLine($" не существует подмножества с суммой всех элементов равной {plentySum}"); // проверка на существование множеств
        Console.WriteLine();
    }
        else 
        if (plentySum < sumOfNegative)
        {
            Console.Write("В множистве ");
            printArray(userArray);
            Console.WriteLine($" не существует подмножества с суммой всех элементов равной {plentySum}"); // проверка на существование множеств
            Console.WriteLine();
        }
        else
        {
            plenty = createCopyArray(userArray);
            if (plentySum == 0) // проверка нулевых элементов в исходном множестве
            {
                cointOfAnswers++;
                Console.Write("В множистве ");
                printArray(userArray);
                Console.WriteLine($"{cointOfAnswers} \t существует пустое подмножество, где нет ни одного элемента"); // выводим на экран мноэество, сумма элементов которого равна заданному числу
                Console.WriteLine();
                countOfActions++;
                for (int i = 0; i < tempLenght; i++)
                {
                    if (plenty[i] == 0)
                    {
                        cointOfAnswers++;
                        Console.Write("В множистве ");
                        printArray(userArray);
                        Console.WriteLine($"{cointOfAnswers} \t существует пустое подмножество, состоящее из [ 0 ]"); // выводим на экран мноэество, сумма элементов которого равна заданному числу
                        Console.WriteLine();
                        plenty = RemovedElementInArray(plenty, i); // удаление нулей из исходного множества
                        tempLenght -= 1;
                        countOfActions++;
                    }
                }
            }
            if (sum == plentySum) // проверка полного равенства
            {
                cointOfAnswers++;
                Console.Write("В множистве ");
                printArray(userArray);
                Console.WriteLine($"существует подмножество с суммой всех элементов равной {plentySum}"); // выводим на экран мноэество, сумма элементов которого равна заданному числу
                Console.Write($"{cointOfAnswers}\t");
                printArray(userArray);
                Console.WriteLine();
                countOfActions++;
            }
            for (int i = 0; i < tempLenght; i++)
            {
                if (plenty[i] == 0)
                {
                    plenty = RemovedElementInArray(plenty, i); // удаление нулей из исходного множества
                    tempLenght -= 1;
                    countOfActions++;
                }
            }
            plenty = sortArray(plenty); // сортировака множества по возрастанию
            tempLenght = plenty.Length;
            
            for (int i = 0; i < plenty.Length; i++)
            {
                if (plenty[i] < 0)
                {
                    positive = 0; 
                    countOfActions++;
                    break;
                }
            }
            if (positive == 1)
            {
                for (int i = tempLenght - 1; i >= 0; i--)
                {
                    if (plentySum < plenty[i])
                    {
                        plenty = RemovedElementInArray(plenty, i); // если все эелементы положительные, то удаляем элементы множества, которые не могут образовать искомую сумму
                        countOfActions++;
                        tempLenght--;
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
                        countOfActions++;
                        break;
                    }
                }
                if (negative == 1)
                {
                    for (int i = 0; i < tempLenght; i++)
                    {
                        if (plenty[i] < plentySum)
                        {
                            plenty = RemovedElementInArray(plenty, i); // если все эелементы отрицательные, то удаляем элементы множества, которые не могут образовать заданную сумму
                            countOfActions++;
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
                if  (plenty[i] == plentySum) // проверяем каждый элемент исходного множества на равенство заданной сумме
                {
                    cointOfAnswers++;
                    Console.Write("В множистве ");
                    printArray(userArray);
                    Console.WriteLine($"{cointOfAnswers} \t существует подмножество [ {plenty[i]} ] с суммой всех элементов равной {plentySum}"); // выводим на экран мноэество, сумма элементов которого равна заданному числу
                    Console.WriteLine();
                }
            }
            //Начинается основной алгоритм перебора вариантов
            int left = 0;
            int right = tempLenght-1;
            int leftSum = 0;
            int rightSum = 0;
            int tempCountOfDigit = 2;
            int[] answerArray = new int[tempCountOfDigit];
            int finded = 0;
            for (int kl = 0; kl < tempLenght-2; kl++) // kr = количество элементов слева для проверки суммы - 1 (-1 используется для более указания на нуженый индекс в массиве)
            {
                leftSum = sumOfNumbersInArray(plenty, left, left + kl);
                for (int kr = 0; kr < tempLenght-2; kr++) // kl = количество элементов справа для проверки суммы - 1 (-1 используется для более указания на нуженый индекс в массиве)
                {
                    rightSum = sumOfNumbersInArray(plenty, right - kr, right);
                    while ((left + kl < right - kr)&&(finded == 0))
                    {
                        if (leftSum + rightSum == plentySum) // сначала суммируем минимальный элемент с максимальным и проверяем на равенство сумме
                        {
                            for (int i = 0; i <= kl; i++)
                            {
                                answerArray[i] = plenty[left+i]; // записываем элементы слева в массив для печати ответа
                            }
                            for (int i = 0; i <= kr; i++)
                            {
                                answerArray[i+kl+1] = plenty[right-i]; // записываем элементы справа в массив для печати ответа
                            }    
                            cointOfAnswers++;
                            Console.Write("В множистве ");
                            printArray(userArray);
                            Console.WriteLine($"существует подмножество с суммой всех элементов равной {plentySum}"); // выводим на экран мноэество, сумма элементов которого равна заданному числу
                            printColorData($"{cointOfAnswers}\t");
                            printArray(answerArray);
                            Console.WriteLine();
                            countOfActions++;
                            finded = 1;
                        }
                        else
                        {
                            if (leftSum + rightSum < plentySum)
                            {
                                leftSum -= plenty[left];
                                left++;
                                leftSum += plenty[left+kl];
                                countOfActions++;
                            }
                            else
                            {
                                rightSum -= plenty[right];
                                right--;
                                rightSum += plenty[right-kr];
                                countOfActions++;
                            }
                        }
                    }
                    Array.Resize(ref answerArray, answerArray.Length + 1);
                    right = tempLenght - 1;
                    rightSum = sumOfNumbersInArray(plenty, right - kr, right);
                    left = 0;
                    leftSum = sumOfNumbersInArray(plenty, left, left + kl);
                    finded = 0;
                }
                tempCountOfDigit++;
                while (answerArray.Length != tempCountOfDigit)
                {
                    Array.Resize(ref answerArray, answerArray.Length - 1);
                }
            }
        }
        
    double maxCountOfActions = Math.Pow(2, userArray.Length);
    Console.WriteLine($"Количество комбинаций множеств, перебранное алгоритмом равно {countOfActions}");
    Console.WriteLine($"Общее количество комбинаций множеств равно {maxCountOfActions}");
    Console.WriteLine();
}

int [] userArray = new int [20] {-1, 0, -8, -5, -7, -5, -3, -15, 2, 4, 18, 25, 12, 9, -12, 0, 35, 3, 8, 11};
checkPlentyFromArray(userArray, 110);
