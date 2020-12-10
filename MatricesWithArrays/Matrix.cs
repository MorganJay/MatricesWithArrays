using System;

namespace MatricesWithArrays
{
    public class Matrix
    {
        private int _rows; //number of rows for matrix
        private int _columns;
        private int[,,,] _matrix; //holds values of matrix itself

        //create r*c matrix and fill it with data passed to this constructor
        public Matrix(int rows, int columns, int[,,,] array)
        {
            _rows = rows;
            _columns = columns;
            _matrix = (int[,,,])array.Clone();
        }

        public int Determinant()
        {
            var determinant = 1;
            if (_rows == _columns)
            {
                var mat = _matrix;
                if (_rows == 1)
                {
                    return mat[0, 0, 0, 0];
                }

                if (_rows == 2)
                {
                    return mat[0, 0, 0, 0] * mat[0, 0, 1, 1] - mat[0, 0, 0, 1] * mat[0, 0, 1, 0];
                }
                var b = ToRightTriangular();

                for (var i = 0; i < _rows; i++)
                {
                    determinant *= b[i, i, 0, 0];
                }
            }
            else
            {
                determinant = 0;
            }

            return determinant;
        }

        public int[,,,] ToRightTriangular()
        {
            var m = Copy();
            var n = _rows;
            var kp = _columns;
            var k = n;
            int[,] els = { };
            do
            {
                var i = k - n;
                int np;
                int p;
                if (m[0, 0, i, i] == 0)
                {
                    for (var j = i + 1; j < k; j++)
                    {
                        if (m[0, 0, j, i] != 0)
                        {
                            np = kp;
                            do
                            {
                                p = kp - np;
                                var index = Array.IndexOf(els, null);

                                if (index != -1)
                                {
                                    els[index, index] = m[0, 0, i, p] + m[0, 0, j, p];
                                }
                            } while (--np != 0); m[0, 0, i, i] = els[i, i];
                            break;
                        }
                    }
                }

                if (m[0, 0, i, i] == 0) continue;
                {
                    for (var j = i + 1; j < k; j++)
                    {
                        var multiplier = m[0, 0, j, i] / m[0, 0, i, i];
                        els.Initialize();
                        np = kp;
                        do
                        {
                            p = kp - np;
                            var index = Array.IndexOf(els, null);

                            if (index != -1)
                            {
                                els[index, index] = p <= i ? 0 : m[0, 0, j, p] - m[0, 0, i, p] * multiplier;
                            }
                        } while (--np != 0); m[0, 0, j, j] = els[j, j];
                    }
                }
            } while (--n != 0); return m;
        }

        public int[,,,] Copy()
        {
            var b = (int[,,,])_matrix.Clone();
            for (var i = 0; i < _rows; i++)
            {
                for (var j = 0; j < _columns; j++)
                {
                    b[0, 0, i, j] = _matrix[0, 0, i, j];
                }
            }

            return b;
        }
    }
}