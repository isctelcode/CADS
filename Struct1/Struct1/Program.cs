using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Struct1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //считывание данных из файла
            string[] file = File.ReadAllLines("data.txt");
            uint dimension = Convert.ToUInt32(file[0]);
            int[,] matrix = new int[dimension, dimension];
            for (int i = 0; i < dimension; i++)
            {
                int[] matrixLine = file[i + 1].Split().Select(int.Parse).ToArray();
                for (int j = 0; j < dimension; j++)
                    matrix[i, j] = matrixLine[j];
            }
            int[] vector = file[dimension + 1].Split().Select(int.Parse).ToArray();
            //создание экземпляров Matrix и Vector
            Matrix gMatrix = new Matrix(dimension, matrix);
            Vector xVector = new Vector(dimension, vector);
            if (!gMatrix.IsSymmetrical())
            {
                Console.WriteLine("Матрица тензора не симметрическая");
                return;
            }
            //создание экземпляра Calculations и расчёты
            Calculations vectorLength = new Calculations(xVector, gMatrix);
            vectorLength.VecXMat();
            Console.WriteLine(Math.Sqrt(vectorLength.VecXVec()));
        }
    }

    internal class Matrix
    {
        private uint dimension;
        private int[,] matrix;
        public int[,] getMatrix()
        {
            return matrix;
        }

        void setMatrix(int[,] matrix)
        {
            this.matrix = matrix;
        }

        public uint getDimension()
        {
            return dimension;
        }

        void setDimension(uint dimension)
        {
            this.dimension = dimension;
        }

        public Matrix(uint dimension, int[,] matrix)
        {
            this.dimension = dimension;
            this.matrix = matrix;
        }

        public bool IsSymmetrical()
        {

            for (int i = 0; i < dimension; i++)
                for (int j = 0; j < dimension; j++)
                    if (matrix[i, j] != matrix[j, i])
                        return false;
            return true;
        }
    }

    internal class Vector
    {
        private uint size;
        private int[] vector;

        public int[] getVector()
        {
            return vector;
        }

        void setVector(int[] vector)
        {
            this.vector = vector;
        }

        public uint getSize()
        {
            return size;
        }

        void setSize(uint size)
        {
            this.size = size;
        }

        public Vector(uint size, int[] vector)
        {
            this.size = size;
            this.vector = vector;
        }
    }

    internal class Calculations
    {
        private Vector vector;
        private Vector tVector;
        private Matrix matrix;
        private uint size;
        private uint dimension;

        public Calculations(Vector vector, Matrix matrix)
        {
            this.vector = vector;
            tVector = vector;
            this.matrix = matrix;
            size = vector.getSize();
            dimension = matrix.getDimension();
        }

        public void VecXMat()
        {
            int[] new_vector = new int[size];

            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    new_vector[i] += vector.getVector()[i] * matrix.getMatrix()[i, j];

            vector = new Vector(size, new_vector);
        }

        public int VecXVec()
        {
            int multiplication = 0;

            for (int i = 0; i < size; i++)
                multiplication += tVector.getVector()[i] * vector.getVector()[i];

            return multiplication;
        }
    }
}
