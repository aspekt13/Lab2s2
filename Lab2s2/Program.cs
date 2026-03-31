using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Lab2s2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Лабораторна робота №2, варіанти: 1 блок 1, 6 блок 2, 3 блок 3, 4 блок 4");
                Console.WriteLine("Виберіть блок для виконання");
                Console.WriteLine("Введіть 1 для Блок 1 (варіант 1)");
                Console.WriteLine("Введіть 2 для Блок 2 (варіант 6)");
                Console.WriteLine("Введіть 3 для Блок 3 (варіант 3)");
                Console.WriteLine("Введіть 4 для Блок 4 (варіант 4)");
                Console.WriteLine("Введіть 0 для виходу з програми");
                switch (Console.ReadLine())
                {
                    case "1":
                        Block1();
                        break;
                    case "2":
                        Block2();
                        break;
                    case "3":
                        Block3();
                        break;
                    case "4":
                        Block4();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
                        Console.ReadKey();
                        break;
                }
            }
        }
        static void Block1()
        {
            Console.Clear();
            Console.WriteLine("Блок 1 (варіант 1)\nЗнайти мінімальний елемент у кожному рядку. Вивести його значення та індекси.");
            int rows = GetValidInt("Введіть кількість рядків:");
            int cols = GetValidInt("Введіть кількість стовпців:");

            int[,] matrix = new int[rows, cols];

            EnterArray(matrix, rows, cols);

            MinElement(matrix);

            Console.WriteLine("Натисніть любу кнопку для виходу в меню вибору");
            Console.ReadKey();
        }

        static void MinElement(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int min = matrix[i, 0];
                int minIndex = 0;
                for (int j = 1; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < min)
                    {
                        min = matrix[i, j];
                        minIndex = j;
                    }
                }
                Console.WriteLine($"Мінімальний елемент у рядку {i}: {min} (індекси: [{i}, {minIndex}])");
            }
        }

        static void Block2()
        {
            Console.Clear();
            Console.WriteLine("Блок 2 варіант 6\nОбміняти місцями перший з максимальних і перший (технічно 0-ий) елементи в кожному рядку матриці.");

            int rows = GetValidInt("Введіть кількість рядків:");
            int cols = GetValidInt("Введіть кількість стовпців:");
            int[,] matrix = new int[rows, cols];

            EnterArray(matrix, rows, cols);

            SwapMaxWithFirst(matrix);

            Console.WriteLine("Натисніть любу кнопку для виходу в меню");
            Console.ReadKey();
        }

        static void SwapMaxWithFirst(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int max = matrix[i, 0];
                int maxIndex = 0;
                for (int j = 1; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > max) 
                    {
                        max = matrix[i, j];
                        maxIndex = j;
                        break;
                    }
                }
                // Обмін місцями
                int temp = matrix[i, 0];
                matrix[i, 0] = matrix[i, maxIndex];
                matrix[i, maxIndex] = temp;
            }
            Console.WriteLine("Матриця після обміну:");
            PrintMatrix(matrix);
        }

        static void Block3()
        {
            Console.Clear();
            Console.WriteLine("Блок 3 варіант 3\nУпорядкувати за незростанням елементів рядок з максимальним добутком елементів.");
            int rows = GetValidInt("Введіть кількість рядків:");
            int cols = GetValidInt("Введіть кількість стовпців:");
            int[,] matrix = new int[rows, cols];

            EnterArray(matrix, rows, cols);
            SortRowWithMaxProduct(matrix);

            Console.WriteLine("Натисніть любу кнопку для виходу в меню");
            Console.ReadKey();
        }
        static void SortRowWithMaxProduct(int[,] matrix)
        {
            long[] rowProducts = new long[matrix.GetLength(0)]; // Масив для зберігання добутків рядків
            long maxProduct = long.MinValue; // Змінна для зберігання максимального добутку

            for (int i = 0; i < matrix.GetLength(0); i++) // Обчислюємо добуток для кожного рядка
            {
                long product = 1;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    product *= matrix[i, j];
                }

                rowProducts[i] = product;

                if (product > maxProduct)
                {
                    maxProduct = product;
                }
            }
            for (int i = 0; i < matrix.GetLength(0); i++) // Сортуємо рядки з максимальним добутком
            {
                if (rowProducts[i] == maxProduct)
                {
                    int[] tempRow = new int[matrix.GetLength(1)];
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        tempRow[j] = matrix[i, j];
                    }
                    Array.Sort(tempRow);
                    Array.Reverse(tempRow);
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        matrix[i, j] = tempRow[j];
                    }
                }
            }

            Console.WriteLine($"\nМатриця після сортування (Максимальний добуток: {maxProduct})");
            PrintMatrix(matrix);
        }

        static void Block4()
        {
            Console.Clear();
            Console.WriteLine("Блок 4 варіант 4\nУпорядкувати стовпчики матриці за незростанням максимального елемента.");

            int rows = GetValidInt("Введіть кількість рядків:");
            int cols = GetValidInt("Введіть кількість стовпців:");
            int[,] matrix = new int[rows, cols];

            EnterArray(matrix, rows, cols);
            SortColsByMaxElement(matrix);

            Console.WriteLine("Натисніть любу кнопку для виходу в меню");
            Console.ReadKey();
        }
        static void SortColsByMaxElement(int[,] matrix)
        {
            int[] maxElements = new int[matrix.GetLength(1)];

            // Знаходимо максимальний елемент для кожного стовпця
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                int max = matrix[0, j];
                for (int i = 1; i < matrix.GetLength(0); i++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                    }
                }
                maxElements[j] = max;
            }

            for (int i = 0; i < matrix.GetLength(1) - 1; i++)
            {
                for (int j = 0; j < matrix.GetLength(1) - i - 1; j++)
                {
                    if (maxElements[j] < maxElements[j + 1])
                    {
                        int tempMax = maxElements[j];
                        maxElements[j] = maxElements[j + 1];
                        maxElements[j + 1] = tempMax;

                        SwapColumns(matrix, matrix.GetLength(0), j, j + 1);
                    }
                }
            }
            Console.WriteLine("\nМатриця після сортування стовпців:");
            PrintMatrix(matrix);
        }
        static void SwapColumns(int[,] matrix, int rows, int col1, int col2)
        {
            for (int k = 0; k < rows; k++)
            {
                int tempValue = matrix[k, col1];
                matrix[k, col1] = matrix[k, col2];
                matrix[k, col2] = tempValue;
            }
        }

        static void EnterArray(int[,] matrix, int rows, int cols)
        {
            for (int i = 0; i < rows; i++)
            {
                bool ok = false;
                while (!ok)
                {
                    Console.WriteLine($"Введіть {cols} чисел для рядка {i} через пробіл: ");
                    string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    if (input.Length != cols) 
                    {
                        Console.WriteLine("Помилка. Невірна кількість чисел."); 
                        continue;
                    }
                    ok = true;
                    for (int j = 0; j < cols; j++)
                    {
                        if (!int.TryParse(input[j], out matrix[i, j]))
                        {
                            Console.WriteLine($"Помилка. Ви ввели не число");
                            ok = false; break;
                        }
                    }
                }
            }
            Console.WriteLine("Ваша матриця:");
            PrintMatrix(matrix);
        }
        static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        static int GetValidInt(string message)
        {
            int number;
            Console.WriteLine(message);
            while (!int.TryParse(Console.ReadLine(), out number))
            {
                Console.WriteLine("Помилка. Введіть коректне ціле число цифрами.");
                Console.WriteLine(message);
            }
            return number;
        }
    }
}
