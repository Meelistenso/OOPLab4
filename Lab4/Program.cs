using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Lab4
{
    static class Program
    {
        public static List<Project> Model { get; set; }
        
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new AboutForm());
        }

        public static T[] InitArray<T>(T[] array, int length)
        {
            var result = new T[length];
            for (var i = 0; i < Math.Min(length, array.Length); i++)
            {
                result[i] = array[i];
            }
            return result;
        }

        public static T[,] InitMatrix<T>(T[,] matrix, int ilength, int jlength)
        {
            var result = new T[ilength, jlength];

            int il = Math.Min(ilength, matrix.GetLength(0));
            int jl = Math.Min(jlength, matrix.Length / matrix.GetLength(0));

            for (var j = 0; j < jl; j++)
            {
                for (var i = 0; i < il; i++)
                {
                    result[i, j] = matrix[i, j];
                }
            }
            return result;
        }

        public static void FillRandom(IList<int> array)
        {
            var rand = new Random();
            for (var i = 0; i < array.Count; i++)
            {
                array[i] = rand.Next(10);
            }
        }

        public static void FillMatrixRandom(double[,] array)
        {
            var rand = new Random();
            for (var i = 0; i < array.GetLength(0); i++)
            {
                for (var j = 0; j < array.Length / array.GetLength(0); j++)
                {
                    array[i, j] = rand.Next(10);
                }
            }
        }
    }
}
