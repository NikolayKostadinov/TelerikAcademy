namespace GenericMatrix.Common
{
    using System;
    using System.Text;
    using Attribute;

    [Version(1.1)]
    public class Matrix<T>
        where T : struct
    {
        private readonly T[,] matrix;
        
        public Matrix()
            : this(0, 0)
        {
        }

        public Matrix(int row, int col)
        {
            Type type = typeof(T);
            if (type != typeof(int) && type != typeof(float) && type != typeof(double))
            {
                throw new ArgumentException("Invalid Type Of <T>. \nThe type must be one of following: int, float, double"); 
            }

            this.matrix = new T[row, col];
        }

        public Matrix(T[,] item)
            : this(item.GetLength(0), item.GetLength(1)) 
        {
            this.matrix = (T[,])item.Clone();
        }

        public int Row
        {
            get 
            {
                return this.matrix.GetLength(0);
            }
        }

        public int Col
        {
            get
            {
                return this.matrix.GetLength(1);
            }
        }

        public T this[int row, int col] 
        {
            get 
            {
                if (row < 0 || row > this.matrix.GetLength(0) - 1)                    
                {
                    throw new IndexOutOfRangeException(
                        string.Format(
                        "Index out of range.\nThe row must be between 0 and {0}!", 
                        this.matrix.GetLength(0) - 1));
                }

                if (col < 0 || col > this.matrix.GetLength(1) - 1)
                {
                    throw new IndexOutOfRangeException(
                        string.Format(
                        "Index out of range.\nThe col must be between 0 and {0}!",
                        this.matrix.GetLength(1) - 1));
                }

                return this.matrix[row, col];
            }

            set 
            {
                if (row < 0 || row > this.matrix.GetLength(0) - 1)
                {
                    throw new IndexOutOfRangeException(
                        string.Format(
                        "Index out of range.\nThe row must be between 0 and {0}!",
                        this.matrix.GetLength(0) - 1));
                }

                if (col < 0 || col > this.matrix.GetLength(1) - 1)
                {
                    throw new IndexOutOfRangeException(
                        string.Format(
                        "Index out of range.\nThe col must be between 0 and {0}!",
                        this.matrix.GetLength(1) - 1));
                }

                this.matrix[row, col] = value;
            }
        }

        public static Matrix<T> operator +(Matrix<T> m1, Matrix<T> m2)
        {
            if (m1.Row != m2.Row || m1.Col != m2.Col)
            {
                throw new ArgumentException("Two matrixes must be the same rank!");
            }

            Matrix<T> result = new Matrix<T>(m1.Row, m1.Col);

            for (int i = 0; i < m1.Row; i++)
            {
                for (int j = 0; j < m1.Col; j++)
                {
                    result[i, j] = (dynamic)m1[i, j] + (dynamic)m2[i, j];
                }                
            }

            return result;
        }

        public static Matrix<T> operator -(Matrix<T> m1, Matrix<T> m2)
        {
            if (m1.Row != m2.Row || m1.Col != m2.Col)
            {
                throw new ArgumentException("Two matrixes must be the same rank!");
            }

            Matrix<T> result = new Matrix<T>(m1.Row, m1.Col);

            for (int i = 0; i < m1.Row; i++)
            {
                for (int j = 0; j < m1.Col; j++)
                {
                    result[i, j] = (dynamic)m1[i, j] - (dynamic)m2[i, j];
                }
            }

            return result;
        }

        public static Matrix<T> operator *(Matrix<T> m1, Matrix<T> m2)
        {
            if (m1.Col != m2.Row)
            {
                throw new ArgumentException("Two matrixes must be the same rank!");
            }

            Matrix<T> result = new Matrix<T>(m1.Row, m2.Col);

            for (int i = 0; i < m1.Row; i++)
            {
                for (int j = 0; j < m2.Col; j++)
                {
                    for (int k = 0; k < m1.Col; k++)
                    {
                        result[i, j] += (dynamic)m1[i, k] * (dynamic)m2[k, j]; 
                    }
                }
            }

            return result;
        }

        public static bool operator true(Matrix<T> m) 
        {
            for (int i = 0; i < m.Row; i++)
            {
                for (int j = 0; j < m.Col; j++)
                {
                    if (!m[i, j].Equals(default(T)))
                    {
                        return true;
                    }
                }                
            }

            return false;
        }

        public static bool operator false(Matrix<T> m)
        {
            for (int i = 0; i < m.Row; i++)
            {
                for (int j = 0; j < m.Col; j++)
                {
                    if (!m[i, j].Equals(default(T)))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        [Version(1.21)]
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < this.Row; i++)
            {
                for (int j = 0; j < this.Col; j++)
                {
                    sb.Append(string.Format("{0,3} ", this.matrix[i, j]));
                }

                sb.Append("\n");
            }

            return sb.ToString();
        }
    }
}
