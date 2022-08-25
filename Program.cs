/*
* Урок 7. Как не нужно писать код. Часть 1
*
* Задача 47. Задайте двумерный массив размером m×n,
* заполненный случайными вещественными числами.
*
* m = 3, n = 4.
*
* 0,5 7 -2 -0,2
* 1 -3,3 8 -9,9
* 8 7,8 -7,1 9
*
* Решение:
*/

double getDoubleByDivision(int a, int b)
{
    if (b == 0)
    {
        b = 1;
    }
    return Convert.ToDouble(a) / Convert.ToDouble(b);
}

double getRandomDouble()
{
    Random rnd = new Random();
    return getDoubleByDivision(
        rnd.Next(-10, 11),
        rnd.Next(-10, 11)
    );
}

void fillMatrixWithRandomDoubles(double[,] matrix)
{
    for (int rowIndex = 0; rowIndex < matrix.GetLength(0); rowIndex++)
    {
        for (int columnIndex = 0; columnIndex < matrix.GetLength(1); columnIndex++)
        {
            matrix[rowIndex, columnIndex] = getRandomDouble();
        }
    }
}

void printMatrixToConsole(double[,] matrix)
{
    for (int rowIndex = 0; rowIndex < matrix.GetLength(0); rowIndex++)
    {
        Console.Write("\n");
        for (int columnIndex = 0; columnIndex < matrix.GetLength(1); columnIndex++)
        {
            Console.Write($" {String.Format("{0:F1}", matrix[rowIndex, columnIndex])}");
        }
    }
}

Console.WriteLine("Введите количество строк матрицы");
int m = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Введите количество столбцов матрицы");
int n = Convert.ToInt32(Console.ReadLine());

if (m < 1 || n < 1)
{
    Console.WriteLine("Некорректные значения");
}
else
{
    double[,] matrix = new double[m, n];

    fillMatrixWithRandomDoubles(matrix);
    printMatrixToConsole(matrix);
}

/*
* Задача 50. Напишите программу, которая на вход принимает 
* позиции элемента в двумерном массиве, и возвращает 
* значение этого элемента или же указание, что такого элемента нет.
*
* Например, задан массив:
*
* 1 4 7 2
* 5 9 2 3
* 8 4 2 4
*
* 17 -> такого числа в массиве нет
*
* Решение:
*/

/*
* Очень запутанные условия: вероятно, под "позицией" элемента понимается
* порядковый номер элемента, если считать слева направо, начиная из верхнего левого угла
* матрицы.
*/

void fillMatrixWithRandomIntegers(int[,] matrix)
{
    Random rnd = new Random();
    for (int rowIndex = 0; rowIndex < matrix.GetLength(0); rowIndex++)
    {
        for (int columnIndex = 0; columnIndex < matrix.GetLength(1); columnIndex++)
        {
            matrix[rowIndex, columnIndex] = rnd.Next(-10, 11);
        }
    }
}

void printMatrixOfIntegersToConsole(int[,] matrix)
{
    for (int rowIndex = 0; rowIndex < matrix.GetLength(0); rowIndex++)
    {
        Console.Write("\n");
        for (int columnIndex = 0; columnIndex < matrix.GetLength(1); columnIndex++)
        {
            Console.Write($"  {matrix[rowIndex, columnIndex]}");
        }
    }
    Console.Write("\n");
}

Console.WriteLine("Введите количество строк матрицы");
int m = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Введите количество столбцов матрицы");
int n = Convert.ToInt32(Console.ReadLine());

if (m < 1 || n < 1)
{
    Console.WriteLine("Некорректные значения");
}
else
{
    int[,] matrix = new int[m, n];
    fillMatrixWithRandomIntegers(matrix);
    printMatrixOfIntegersToConsole(matrix);
    int pos = 1;
    while (pos >= 0)
    {
        Console.WriteLine("Введите позицию искомого элемента. Для выходы введите значение меньше единицы");
        pos = Convert.ToInt32(Console.ReadLine());
        if (pos < 1)
        {
            break;
        }

        int size = m * n;
        if (pos > size)
        {
            Console.WriteLine("такого числа в массиве нет");
        }
        else
        {
            pos--; // Надо учесть, что позиции начинаются с едминицы, а не с ноля.
            int row = pos / n;
            int col = pos - (n * row);

            Console.WriteLine($"значение элемента под индексами {row} {col} равно {matrix[row, col]}");
        }
    }
}

/*
* Задача 52. Задайте двумерный массив из целых чисел. 
* Найдите среднее арифметическое элементов в каждом столбце.
* 
* Например, задан массив:
* 1 4 7 2
* 5 9 2 3
* 8 4 2 4
* Среднее арифметическое каждого столбца: 4,6; 5,6; 3,6; 3.
*
* Решение:
*/

void fillMatrixWithRandomPositiveIntegers(int[,] matrix)
{
    Random rnd = new Random();
    for (int rowIndex = 0; rowIndex < matrix.GetLength(0); rowIndex++)
    {
        for (int columnIndex = 0; columnIndex < matrix.GetLength(1); columnIndex++)
        {
            matrix[rowIndex, columnIndex] = rnd.Next(0, 10);
        }
    }
}

double[] countColumnAverage(int[,] matrix)
{
    double[] count = new double[matrix.GetLength(1)];

    for (int columnIndex = 0; columnIndex < matrix.GetLength(1); columnIndex++)
    {
        int summ = 0;
        for (int rowIndex = 0; rowIndex < matrix.GetLength(0); rowIndex++)
        {
            summ += matrix[rowIndex, columnIndex];
        }
        count[columnIndex] = Convert.ToDouble(summ) / Convert.ToDouble(matrix.GetLength(0));
    }

    return count;
}

// Здесь и далее я буду переиспользовать реализованные выше функции.

Console.WriteLine("Введите количество строк матрицы");
int m = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Введите количество столбцов матрицы");
int n = Convert.ToInt32(Console.ReadLine());

if (m < 1 || n < 1)
{
    Console.WriteLine("Некорректные значения");
}
else
{
    int[,] matrix = new int[m, n];
    fillMatrixWithRandomPositiveIntegers(matrix);
    printMatrixOfIntegersToConsole(matrix);

    Console.WriteLine("Среднее арифметическое каждого столбца: " + String.Join("; ", countColumnAverage(matrix)));
}