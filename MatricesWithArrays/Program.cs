using System;

// Write a C# program to obtain the determinant of a matrix of the form => int[,,,] = new [1,1,4,4].
// Using the data structure above, generate the result of the above squared and return the array.

namespace MatricesWithArrays
{
    public class Program
    {
        private static int _rows;
        private static int _columns;
        private const int RandomMaxValue = 30;
        private const int RandomMinValue = 0;
        private static int[,] _matrix;
        private static readonly int[,,,] Matrix4D = new int[1, 1, 4, 4];
        private static readonly Random Random = new Random();

        private static void Main()
        {
            Console.WriteLine("Hi What's your name ?");
            var name = Console.ReadLine();

            Console.WriteLine($"Welcome {name}, this is a program to perform some matrix calculations for a matrix of the form => int[,,,] = new [1,1,4,4]. Get ready to be marveled.");
            RandomNumberChoice();
            DisplayMatrix(Matrix4D);

            Console.WriteLine("Calculating the determinant...");
            MatrixDeterminant(Matrix4D);

            Console.WriteLine("\nUsing the data structure above, the result of the above squared is below");
            MatrixSquared(Matrix4D);

            Console.WriteLine("Press any key to continue matrix calculation or close the program");
            Console.ReadLine();
            MatrixGenerator();
            DisplayMatrix(_matrix);

            Console.WriteLine("\nNow I'll find the determinant and the square");
            MatrixDeterminant(_matrix);
            MatrixSquared(_matrix);
            Console.ReadLine();
        }

        private static void EnterMatrixEntries(int[,,,] array)
        {
            Console.WriteLine("Now start entering values for the matrix one row after the other");
            for (var i = 0; i < array.GetLength(0); i++)
            {
                for (var j = 0; j < array.GetLength(1); j++)
                {
                    for (var k = 0; k < array.GetLength(2); k++)
                    {
                        for (var l = 0; l < array.GetLength(3); l++)
                        {
                            try
                            {
                                var input = int.Parse(Console.ReadLine());
                                array[i, j, k, l] = input;
                            }
                            catch (Exception) // once user tries anything fishy, i generate random values
                            {
                                Console.WriteLine("You wanted to crash the program but you failed. I will generate random values");
                                RandomNumberGen(Matrix4D);
                                Console.WriteLine("Now enter the next number for the matrix");
                            }
                        }
                        if (i < array.GetLength(0)) Console.WriteLine("Now the next row"); // only print when all rows have not been filled
                    }
                }
                Console.WriteLine();
            }
        }

        private static void EnterMatrixEntries(int[,] array)
        {
            Console.WriteLine("Enter values for the matrix below");
            for (var i = 0; i < _rows; i++)
            {
                for (var j = 0; j < _columns; j++)
                {
                    try
                    {
                        var input = int.Parse(Console.ReadLine());
                        array[i, j] = input;
                    }
                    catch (Exception) // once user tries anything fishy, i generate random values
                    {
                        Console.WriteLine("You wanted to crash the program but you failed. I will generate a random value");
                        array[i, j] = Random.Next(RandomMinValue, RandomMaxValue); // Next returns random integers from 0 to 30
                    }
                }
                if (i < _rows - 1)
                    Console.WriteLine("Now the next row");
            }
            Console.WriteLine();
        }

        private static void RandomNumberChoice(int[,] array) // for 2D array, normal matrix
        {
            Console.Write("Do you want to enter your own values for the matrix? let your yes be yes and your no be no ");
            try
            {
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
                            EnterMatrixEntries(array);
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("You wanted to crash the program but you failed. I will generate random values");
                            RandomNumberGen(array);
                        }
                        break;

                    case "no":
                        RandomNumberGen(array);
                        break;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("You wanted to crash the program but you failed. I will run as intended");
                RandomNumberGen(_matrix);
            }
        }

        private static void RandomNumberChoice()
        {
            Console.Write("Do you want to enter your own values for the matrix? let your yes be yes and your no be no ");
            try
            {
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
                            EnterMatrixEntries(Matrix4D);
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("You wanted to crash the program but you failed. I will generate random values");
                            RandomNumberGen(Matrix4D);
                        }
                        break;

                    case "no":
                        Console.WriteLine($"Random numbers will now be generated for the matrix from {RandomMinValue} to {RandomMaxValue}");
                        RandomNumberGen(Matrix4D);
                        break;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("You wanted to crash the program but you failed. I will run as intended");
                RandomNumberGen(Matrix4D);
            }
        }

        private static void RandomNumberGen(int[,] array)
        {
            for (var i = 0; i < _rows; i++)
            {
                for (var j = 0; j < _columns; j++)
                {
                    array[i, j] = Random.Next(RandomMinValue, RandomMaxValue); // Next returns random integers from 0 to 30
                }
            }
            Console.WriteLine("Your matrix has been filled with random numbers");
        }

        private static void RandomNumberGen(int[,,,] array)
        {
            for (var i = 0; i < Matrix4D.GetLength(0); i++)
            {
                for (var j = 0; j < Matrix4D.GetLength(1); j++)
                {
                    for (var k = 0; k < Matrix4D.GetLength(2); k++)
                    {
                        for (var l = 0; l < Matrix4D.GetLength(3); l++)
                        {
                            array[i, j, k, l] = Random.Next(RandomMinValue, RandomMaxValue);
                        }
                    }
                }
            }
        }

        private static void MatrixGenerator() // generate 2D array or matrix
        {
            Console.WriteLine("Let's create your matrix shall we?");
            try
            {
                bool pass;
                do
                {
                    Console.WriteLine("Enter the number of rows");
                    pass = int.TryParse(Console.ReadLine(), out _rows);
                } while (!pass);

                do
                {
                    Console.WriteLine("Enter the number of columns");
                    pass = int.TryParse(Console.ReadLine(), out _columns);
                } while (!pass);
            }
            catch (Exception)
            {
                Console.WriteLine("You wanted to crash the program but you failed. I will use the default of a 2 x 2 matrix");
                _rows = 2;
                _columns = 2;
            }

            _matrix = new int[_rows, _columns];
            RandomNumberChoice(_matrix); // calls for user input or initiates number generator function from within
        }

        private static void MatrixDeterminant(int[,] array)
        {
            var determinant = 0;
            if (_rows != _columns)
            {
                Console.WriteLine("Determinant can only be calculated only for square matrices! \n Equal rows and columns");
            }
            else
            {
                if (_rows == 2)
                {
                    determinant = array[0, 0] * array[1, 1] - array[0, 1] * array[1, 0];
                }
                else
                {
                    for (var i = 0; i < _columns; i++) // 3x3 matrix only
                    {
                        var a = array[0, i];
                        var b = array[1, (i + 1) % _columns];
                        var c = array[2, (i + 2) % _columns];
                        var d = array[1, (i + 2) % _columns];
                        var e = array[2, (i + 1) % _columns];
                        determinant += a * (b * c - d * e);
                    }
                }

                Console.WriteLine($"The determinant of the matrix is {determinant}.");
            }
        }

        private static void MatrixDeterminant(int[,,,] array)
        {
            if (array.GetLength(2) != array.GetLength(3))
            {
                Console.WriteLine("Determinant can only be calculated only for square matrices! \nEqual rows and columns");
            }
            else
            {
                var determinant = array[0, 0, 0, 0] * (array[0, 0, 1, 1] * (array[0, 0, 2, 2] * array[0, 0, 3, 3] - array[0, 0, 2, 3] * array[0, 0, 3, 2])
                                                        - array[0, 0, 1, 2] * (array[0, 0, 2, 1] * array[0, 0, 3, 3] - array[0, 0, 2, 3] * array[0, 0, 3, 1])
                                                        + array[0, 0, 1, 3] * (array[0, 0, 2, 1] * array[0, 0, 3, 2] - array[0, 0, 2, 2] * array[0, 0, 3, 1]))
                                  // second column
                                  - array[0, 0, 0, 1] * (array[0, 0, 1, 0] * (array[0, 0, 2, 2] * array[0, 0, 3, 3] - array[0, 0, 2, 3] * array[0, 0, 3, 2])
                                                      - array[0, 0, 1, 2] * (array[0, 0, 2, 0] * array[0, 0, 3, 3] - array[0, 0, 2, 3] * array[0, 0, 3, 0])
                                                      + array[0, 0, 1, 3] * (array[0, 0, 2, 0] * array[0, 0, 3, 2] - array[0, 0, 2, 2] * array[0, 0, 3, 0]))
                                  //third column
                                  + array[0, 0, 0, 2] * (array[0, 0, 1, 0] * (array[0, 0, 2, 1] * array[0, 0, 3, 3] - array[0, 0, 2, 3] * array[0, 0, 3, 1])
                                                      - array[0, 0, 1, 1] * (array[0, 0, 2, 0] * array[0, 0, 3, 3] - array[0, 0, 2, 3] * array[0, 0, 3, 0])
                                                      + array[0, 0, 1, 3] * (array[0, 0, 2, 0] * array[0, 0, 3, 1] - array[0, 0, 2, 1] * array[0, 0, 3, 0]))
                                   //fourth column
                                   - array[0, 0, 0, 3] * (array[0, 0, 1, 0] * (array[0, 0, 2, 1] * array[0, 0, 3, 2] - array[0, 0, 2, 2] * array[0, 0, 3, 1])
                                                       - array[0, 0, 1, 1] * (array[0, 0, 2, 0] * array[0, 0, 3, 2] - array[0, 0, 2, 2] * array[0, 0, 3, 0])
                                                       + array[0, 0, 1, 2] * (array[0, 0, 2, 0] * array[0, 0, 3, 1] - array[0, 0, 2, 1] * array[0, 0, 3, 0]));

                Console.WriteLine($"The determinant of the matrix is {determinant}.");
            }
        }

        private static void MatrixSquared(int[,,,] array)
        {
            var arrayCopy = (int[,,,])array.Clone();
            var rowCount = array.GetLength(2);
            var columnCount = array.GetLength(3);
            var copyColumnCount = arrayCopy.GetLength(3);
            if (rowCount == copyColumnCount)
            {
                var arrayProduct = new int[1, 1, 4, 4];
                for (var i = 0; i < rowCount; i++)
                {
                    for (var j = 0; j < copyColumnCount; j++)
                    {
                        var sum = 0;
                        for (var k = 0; k < columnCount; k++)
                        {
                            var a = array[0, 0, i, k];
                            var b = arrayCopy[0, 0, k, j];
                            sum += a * b;
                        }
                        arrayProduct[0, 0, i, j] = sum;
                    }
                }
                Console.WriteLine("Here is the square of the matrix above");
                DisplayMatrix(arrayProduct);
            }
            else
            {
                Console.WriteLine("The matrix must have the same number of rows as columns");
            }
        }

        private static void MatrixSquared(int[,] array)
        {
            //var arrayCopy = (int[,])array.Clone();
            var rowCount = _rows;
            var columnCount = _columns;
            // var copyColumnCount = array.GetLength(1);
            if (rowCount == columnCount)
            {
                var arrayProduct = (int[,])array.Clone();
                for (var i = 0; i < rowCount; i++)
                {
                    for (var j = 0; j < array.GetLength(1); j++)
                    {
                        var sum = 0;
                        for (var k = 0; k < columnCount; k++)
                        {
                            var a = array[i, k];
                            var b = array[k, j];
                            sum += a * b;
                        }
                        arrayProduct[i, j] = sum;
                    }
                }
                Console.WriteLine("Here is the square of the matrix below");
                DisplayMatrix(arrayProduct);
            }
            else
            {
                Console.WriteLine("The matrix must have the same number of rows as columns");
            }
        }

        private static void DisplayMatrix(int[,,,] array)
        {
            for (var i = 0; i < array.GetLength(0); i++)
            {
                for (var j = 0; j < array.GetLength(1); j++)
                {
                    for (var k = 0; k < array.GetLength(2); k++)
                    {
                        for (var l = 0; l < array.GetLength(3); l++)
                        {
                            Console.Write($"   {array[i, j, k, l]}\t");
                        }
                        Console.WriteLine();
                    }
                }
                Console.WriteLine("");
            }
        }

        private static void DisplayMatrix(int[,] array)
        {
            for (var i = 0; i < array.GetLength(0); i++)
            {
                for (var j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write($" {array[i, j]}\t");
                }
                Console.WriteLine();
            }
        }
    }
}