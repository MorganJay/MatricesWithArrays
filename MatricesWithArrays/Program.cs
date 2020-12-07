using System;

// Write a C# program to obtain the determinant of a matrix of the form => int[,,,] = new [3,4,2,3].
// Using the data structure above, generate the result of the above squared and return the array

namespace MatricesWithArrays
{
    public class Program
    {
        private static int rows;
        private static int columns;
        private static int randomMaxValue = 30;
        private static int randomMinValue;
        private static int[,] matrix;
        private static readonly int[,,,] matrix4D = new int[3, 4, 2, 3];
        private static readonly Random Random = new Random();

        private static void Main(string[] args)
        {
            Console.WriteLine("Hi What's your name ?");
            var name = Console.ReadLine();

            Console.WriteLine($"Welcome {name}, this is a program to show some matrix calculation. Get ready to be marveled.");
            RandomNumberChoice();
            DisplayMatrix(matrix4D);

            Console.WriteLine("Calculate the determinant...");
            Console.ReadLine();
            MatrixDeterminant(matrix4D);

            Console.WriteLine("\nUsing the data structure above, the result of the above squared is below");
            Console.ReadLine();
            MatrixSquared(matrix4D);
            DisplayMatrix(matrix4D);

            Console.WriteLine("Press any key to continue matrix calculation or close the program");
            Console.ReadLine();
            MatrixGenerator();
            DisplayMatrix(matrix);

            Console.WriteLine("Now I'll find the determinant");
            MatrixDeterminant(matrix);
        }

        private static void RandomNumberChoice()
        {
            Console.WriteLine($"Random numbers will now be generated for the matrix of the form => int[,,,] = new [3,4,2,3] from {randomMinValue} to {randomMaxValue}");
            Console.Write("Do you want to change this range? ");
            var decision = Console.ReadLine().ToLower();

            while (decision != "yes" && decision != "no")
            {
                Console.WriteLine("You have to type yes or no");
                decision = Console.ReadLine();
            }

            switch (decision)
            {
                case "yes":
                    try
                    {
                        Console.Write("Enter a minimum value of your choice ");
                        randomMinValue = int.Parse(Console.ReadLine());
                        Console.WriteLine();
                        Console.Write("Enter a maximum value of your choice ");
                        randomMaxValue = int.Parse(Console.ReadLine());
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("You wanted to crash the program but you failed. I will use the default range");
                        randomMinValue = 0;
                        randomMaxValue = 30;
                    }
                    break;

                case "no":
                    RandomNumberGen();
                    break;
            }
        }

        private static void RandomNumberGen()
        {
            for (var i = 0; i < matrix4D.GetLength(0); i++)
            {
                for (var j = 0; j < matrix4D.GetLength(1); j++)
                {
                    for (var k = 0; k < matrix4D.GetLength(2); k++)
                    {
                        for (var l = 0; l < matrix4D.GetLength(3); l++)
                        {
                            matrix4D[i, j, k, l] = Random.Next(randomMinValue, randomMaxValue);
                        }
                    }
                }
            }
        }

        private static void MatrixGenerator()
        {
            Console.WriteLine("Calculate the determinant of a 3x3 matrix");
            try
            {
                bool pass;
                do
                {
                    Console.WriteLine("Enter the number of rows");
                    pass = int.TryParse(Console.ReadLine(), out rows); // validating if input is a number
                } while (pass);

                do
                {
                    Console.WriteLine("Enter the number of columns");
                    pass = int.TryParse(Console.ReadLine(), out columns);
                } while (pass);
            }
            catch (Exception)
            {
                Console.WriteLine("You wanted to crash the program but you failed. I will use the default of a 2 x 2 matrix");
                rows = 2;
                columns = 2;
            }

            matrix = new int[rows, columns];

            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < columns; j++)
                {
                    matrix[i, j] = Random.Next(randomMinValue, randomMaxValue); // Next returns random integers from 0 to 30
                }
            }
            Console.WriteLine("Your matrix has been filled with random numbers");
        }

        private static void MatrixDeterminant(int[,] array)
        {
            var determinant = 0;
            if (rows != columns)
            {
                Console.WriteLine("Determinant can only be calculated only for square matrices! \n Equal rows and columns");
            }
            else
            {
                for (var i = 0; i < columns; i++)
                {
                    determinant += array[0, i] * (array[1, (i + 1) % columns] * array[2, (i + 2) % columns] -
                                                     array[1, (i + 2) % columns] * array[2, (i + 1) % columns]);
                }
            }
            Console.WriteLine($"The determinant of the 3x3 matrix is {determinant}.");
        }

        private static void MatrixDeterminant(int[,,,] array)
        {
            var determinant = 0;
            if (array.GetLength(2) != array.GetLength(3))
            {
                Console.WriteLine("Determinant can only be calculated only for square matrices! \nEqual rows and columns");
            }
            else
            {
                // work to be done.
                for (var i = 0; i < columns; i++)
                {
                }
            }
            Console.WriteLine($"The determinant of the matrix is {determinant}.");
        }

        private static void MatrixSquared(int[,,,] array)
        {
            for (var i = 0; i < array.GetLength(0); i++)
            {
                for (var j = 0; j < array.GetLength(1); j++)
                {
                    for (var k = 0; k < array.GetLength(2); k++)
                    {
                        for (var l = 0; l < array.GetLength(3); l++)
                        {
                            var entry = matrix4D[i, j, k, l];
                            var squaredEntry = (int)Math.Pow(entry, 2);
                            matrix4D[i, j, k, l] = squaredEntry;
                        }
                    }
                }
            }
        }

        private static void DisplayMatrix(int[,,,] array)
        {
            for (var i = 0; i < array.GetLength(0); i++)
            {
                Console.WriteLine("[");
                for (var j = 0; j < array.GetLength(1); j++)
                {
                    Console.WriteLine(" {");
                    for (var k = 0; k < array.GetLength(2); k++)
                    {
                        for (var l = 0; l < array.GetLength(3); l++)
                        {
                            Console.Write($"  { matrix4D[i, j, k, l] }");
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine(" }");
                }
                Console.WriteLine("]\n");
            }
        }

        private static void DisplayMatrix(int[,] array)
        {
            for (var i = 0; i < array.GetLength(0); i++)
            {
                for (var j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write($" { array[i, j] }");
                }
                Console.WriteLine();
            }
        }
    }
}