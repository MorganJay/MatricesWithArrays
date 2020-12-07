using System;

namespace MatricesWithArrays
{
    internal class Matrix
    {
        private int _rowMatrix; //number of rows for matrix
        private int _columnMatrix;
        private int[,] _matrix; //holds values of matrix itself

        //create r*c matrix and fill it with data passed to this constructor
        public Matrix(int[,] array)
        {
            _matrix = array;
            _rowMatrix = _matrix.GetLength(0);
            _columnMatrix = _matrix.GetLength(1);
            Console.WriteLine("Constructor which sets matrix size {0}*{1} and fills it with initial data executed.", _rowMatrix, _columnMatrix);
        }

        //returns value of an element for a given row and column of matrix
        public int ReadElement(int row, int column)
        {
            return _matrix[row, column];
        }

        //sets value of an element for a given row and column of matrix
        public void SetElement(int value, int row, int column)
        {
            _matrix[row, column] = value;
        }

        public double DeterMatrix()
        {
            int det = 0;
            int value = 0;
            int i, j, k;

            i = _rowMatrix;
            j = _columnMatrix;
            int n = i;

            if (i != j)
            {
                Console.WriteLine("determinant can be calculated only for square matrix!");
                return det;
            }

            for (i = 0; i < n - 1; i++)
            {
                for (j = i + 1; j < n; j++)
                {
                    det = ReadElement(j, i) / ReadElement(i, i);

                    for (k = i; k < n; k++)
                    {
                        value = ReadElement(j, k) - det * ReadElement(i, k);

                        SetElement(value, j, k);
                    }
                }
            }

            det = 1;
            for (i = 0; i < n; i++)
                det *= ReadElement(i, i);

            return det;
        }
    }

    //Matrix mat03 = new Matrix(new[,]
    //{
    //{1.0, 2.0, -1.0},
    //{-2.0, -5.0, -1.0},
    //{1.0, -1.0, -2.0},
    //});

    //Matrix mat04 = new Matrix(new[,]
    //{
    //{1.0, 2.0, 1.0, 3.0},
    //{-2.0, -5.0, -2.0, 1.0},
    //{1.0, -1.0, -3.0, 2.0},
    //{4.0, -1.0, -3.0, 1.0},
    //});

    //Matrix mat05 = new Matrix(new[,]
    //{
    //{1.0, 2.0, 1.0, 2.0, 3.0},
    //{2.0, 1.0, 2.0, 2.0, 1.0},
    //{3.0, 1.0, 3.0, 1.0, 2.0},
    //{1.0, 2.0, 4.0, 3.0, 2.0},
    //{2.0, 2.0, 1.0, 2.0, 1.0},
    //});

    //double determinant = mat03.DeterMatrix();
    //Console.WriteLine("determinant is: {0}", determinant);

    //determinant = mat04.DeterMatrix();
    //Console.WriteLine("determinant is: {0}", determinant);

    //determinant = mat05.DeterMatrix();
    //Console.WriteLine("determinant is: {0}", determinant);
    //Console.ReadLine();
}