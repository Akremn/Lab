using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


namespace Exersise_1
{
    public partial class MyMatrix

    {
        private double[,] matrix;

        public MyMatrix(MyMatrix newMatrix)
        {
            matrix = newMatrix.matrix;

        }

        public MyMatrix(double[,] matrix)
        {
            this.matrix = matrix;
        }
        public MyMatrix(double[][] jaggedMatrix)
        {
            int rows = jaggedMatrix.Length;
            int cols = jaggedMatrix[0].Length;

            for (int i = 0; i < rows; i++)
            {
                if (jaggedMatrix[i].Length != cols)
                {
                    throw new ArgumentException("is not rectangular");

                }

            }

            matrix = new double[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = jaggedMatrix[i][j];

                }
            }

        }

        public MyMatrix(String[] StringMatrix)
        {

            int rows = StringMatrix.Length;
            int cols = StringMatrix[0].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Length;

            matrix = new double[rows, cols];


            for (int i = 0; i < rows; i++)
            {
                string[] corectString = StringMatrix[i].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (cols == corectString.Length && String.Join("", corectString).All(char.IsDigit))
                {
                    double[] row = Array.ConvertAll(StringMatrix[i].Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries), double.Parse);

                    for (int j = 0; j < row.Length; j++)
                    {
                        matrix[i, j] = row[j];
                    }

                }
                else
                {
                    throw new Exception("matrix can only have number");
                }



            }
        }

        public MyMatrix(String matrix)
        {
            string[] rows = matrix.Split('\n');

            this.matrix = new double[rows.Length, rows[0].Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Length];

            for (int i = 0; i < rows.Length; i++)
            {
                double[] row = Array.ConvertAll(rows[i].Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries), double.Parse);

                for (int j = 0; j < rows[0].Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Length; j++)
                {
                    this.matrix[i, j] = row[j];
                }

            }

        }
        public override String ToString()
        {
            string output = "";

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    output += $"{matrix[i, j]} \t";
                }
                output += "\n";

            }

            return output;
        }

        //Get Set
        public int Height
        {
            get
            {
                return matrix.GetLength(0);
            }
        }


        public int Width
        {
            get
            {
                return matrix.GetLength(1);
            }
        }

        public int getHeight()
        {
            return Height;
        }

        public int getWidth()
        {
            return Width;
        }

        // Indecsator

        public double this[int i, int j]
        {
            get
            {
                return matrix[i, j];
            }
            set
            {
                if (i >= 0 && j >= 0)
                {
                    matrix[i, j] = value;
                }
            }
        }

        public double GetValue(int i, int j)
        {
            if (i >= 0 && j >= 0)
            {
                return matrix[i, j];

            }
            else
            {
                return 0;
            }
        }

        public double SetValue(int i, int j, int value)
        {
            if (i >= 0 && j >= 0)
            {
                return matrix[i, j] = value;

            }
            else
            {
                return 0;
            }
        }


    }
}