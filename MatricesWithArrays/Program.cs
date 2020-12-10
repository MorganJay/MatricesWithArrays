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
        private static int[,,,] Matrix4D = new int[1, 1, 4, 4];
        private static readonly Random Random = new Random();

        private static void Main()
        {
            //Console.WriteLine("Hi What's your name ?");
            //var name = Console.ReadLine();

            //Console.WriteLine($"Welcome {name}, this is a program to show some matrix calculation. Get ready to be marveled.");
            //RandomNumberChoice(Matrix4D);
            //DisplayMatrix(Matrix4D);

            ////Console.WriteLine("Calculate the determinant...");
            ////Console.ReadLine();
            ////MatrixDeterminant(matrix4D);

            //Console.WriteLine("\nUsing the data structure above, the result of the above squared is below");
            //MatrixSquared(Matrix4D);

            Console.WriteLine("Press any key to continue matrix calculation or close the program");
            Console.ReadLine();
            MatrixGenerator();
            DisplayMatrix(_matrix);

            Console.WriteLine("\nNow I'll find the determinant");
            MatrixDeterminant(_matrix);
            Console.ReadLine();
        }

        private static void EnterMatrixEntries(int[,,,] array)
        {
            for (var i = 0; i < array.GetLength(0); i++)
            {
                Console.WriteLine(" [ ");
                for (var j = 0; j < array.GetLength(1); j++)
                {
                    for (var k = 0; k < array.GetLength(2); k++)
                    {
                        for (var l = 0; l < array.GetLength(3); l++)
                        {
                            try
                            {
                                var input = int.Parse(Console.ReadLine());
                                Matrix4D[i, j, k, l] = input;
                            }
                            catch (Exception) // once user tries anything fishy, i generate random values
                            {
                                Console.WriteLine("You wanted to crash the program but you failed. I will generate random values");
                                RandomNumberGen(Matrix4D);
                            }
                        }
                        Console.WriteLine("Now the next row");
                    }
                }
                Console.WriteLine(" ]\n");
            }
        }

        private static void EnterMatrixEntries()
        {
            Console.WriteLine("Enter values for the matrix below");
            Console.WriteLine(" [ ");
            for (var i = 0; i < _rows; i++)
            {
                for (var j = 0; j < _columns; j++)
                {
                    try
                    {
                        var input = int.Parse(Console.ReadLine());
                        _matrix[i, j] = input;
                    }
                    catch (Exception) // once user tries anything fishy, i generate random values
                    {
                        Console.WriteLine("You wanted to crash the program but you failed. I will generate a random value");
                        _matrix[i, j] = Random.Next(RandomMinValue, RandomMaxValue); // Next returns random integers from 0 to 30
                    }
                }
                Console.WriteLine("Now the next row");
            }
            Console.WriteLine(" ]\n");
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
                            EnterMatrixEntries();
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("You wanted to crash the program but you failed. I will generate random values");
                            RandomNumberGen(_matrix);
                        }
                        break;

                    case "no":
                        RandomNumberGen(_matrix);
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
                    _matrix[i, j] = Random.Next(RandomMinValue, RandomMaxValue); // Next returns random integers from 0 to 30
                }
            }
            Console.WriteLine("Your matrix has been filled with random numbers");
        }

        private static void RandomNumberChoice(int[,,,] array)
        {
            Console.WriteLine($"Random numbers will now be generated for the matrix from {RandomMinValue} to {RandomMaxValue}");
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
                            Matrix4D[i, j, k, l] = Random.Next(RandomMinValue, RandomMaxValue);
                        }
                    }
                }
            }
        }

        private static void MatrixGenerator()
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
            RandomNumberChoice(); // calls for user input or initiates number generator function from within
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
                for (var i = 0; i < _rows; i++)
                {
                    for (var j = 0; j < _columns; i++)
                    {
                        var a = array[i, j];
                        var b = array[i + 1, (j + 1) % _columns];
                        var c = array[i + 2, (j + 2) % _columns];
                        var d = array[i + 1, (j + 2) % _columns];
                        var e = array[i + 2, (j + 1) % _columns];

                        determinant += a * (b * c - d * e);
                    }
                }
            }
            Console.WriteLine($"The determinant of the matrix is {determinant}.");
        }

        private static void MatrixDeterminant(int[,,,] array)
        {
            if (array.GetLength(2) != array.GetLength(3))
            {
                Console.WriteLine("Determinant can only be calculated only for square matrices! \nEqual rows and columns");
            }
            else
            {
                var a = new Matrix(array.GetLength(2), array.GetLength(3), Matrix4D);
                var determinant = a.Determinant();
                Console.WriteLine($"The determinant of the matrix is {determinant}.");
            }
        }

        private static void MatrixSquared(int[,,,] array)
        {
            var arrayCopy = (int[,,,])array.Clone();
            var rowCount = array.GetLength(2);
            var columnCount = array.GetLength(3);
            var copyColumnCount = arrayCopy.GetLength(3);
            if (array.GetLength(2) == arrayCopy.GetLength(3))
            {
                var arrayProduct = (int[,,,])array.Clone();
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

        private static void DisplayMatrix(int[,,,] array)
        {
            for (var i = 0; i < array.GetLength(0); i++)
            {
                Console.WriteLine(" [");
                for (var j = 0; j < array.GetLength(1); j++)
                {
                    for (var k = 0; k < array.GetLength(2); k++)
                    {
                        for (var l = 0; l < array.GetLength(3); l++)
                        {
                            Console.Write($"   { array[i, j, k, l] }");
                        }
                        Console.WriteLine();
                    }
                }
                Console.WriteLine(" ]\n");
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