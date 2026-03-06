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

                        break;
                    case "4":

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
            Console.WriteLine("Введіть кількість рядків");
            int rows = int.Parse(Console.ReadLine());
            Console.WriteLine("Введіть кількість стовпців");
            int cols = int.Parse(Console.ReadLine());

            int[,] matrix = new int[rows, cols];

            EnterArray(matrix, rows, cols);

            MinEl(matrix, rows, cols);

            Console.WriteLine("Натисніть любу кнопку для виходу в меню вибору");
            Console.ReadKey();
        }

        static void MinEl(int[,] matrix, int rows, int cols)
        {
            for (int i = 0; i < rows; i++)
            {
                int min = matrix[i, 0];
                int minIndex = 0;
                for (int j = 1; j < cols; j++)
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

            Console.WriteLine("Введіть кількість рядків");
            int rows = int.Parse(Console.ReadLine());
            Console.WriteLine("Введіть кількість стовпців");
            int cols = int.Parse(Console.ReadLine());

            int[,] matrix = new int[rows, cols];

            EnterArray(matrix, rows, cols);

            SwapMaxWithFirst(matrix, rows, cols);

            Console.WriteLine("Натисніть любу кнопку для виходу в меню");
            Console.ReadKey();
        }

        static void SwapMaxWithFirst(int[,] matrix, int rows, int cols)
        {
            for (int i = 0; i < rows; i++)
            {
                int max = matrix[i, 0];
                int maxIndex = 0;
                for (int j = 1; j < cols; j++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        maxIndex = j;
                    }
                }
                // Обмін місцями
                int temp = matrix[i, 0];
                matrix[i, 0] = matrix[i, maxIndex];
                matrix[i, maxIndex] = temp;
            }
            Console.WriteLine("Матриця після обміну:");
            PrintMatrix(matrix, rows, cols);
        }

        static void EnterArray(int[,] matrix, int rows, int cols)
        {
            for (int i = 0; i < rows; i++)
            {
                Console.WriteLine($"Введіть {cols} чисел для рядка {i} через пробіл: ");
                string[] input = Console.ReadLine().Split(' ');
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = int.Parse(input[j]);
                }
            }
            PrintMatrix(matrix, rows, cols);
        }
        static void PrintMatrix(int[,] matrix, int rows, int cols)
        {
            Console.WriteLine("Ваша матриця:");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
