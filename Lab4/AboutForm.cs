using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Lab4
{
    public partial class AboutForm : Form
    {
        private int[] _array = new int[1];
        private double[,] _matrix = new double[1, 1];
        private static readonly List<Label> Lines = new List<Label>();

        public AboutForm()
        {
            InitializeComponent();

            Task2Form task2Form = new Task2Form();
            task2Form.Show();
            GetCount(_array, 0, 10);
            Lines.AddRange(new List<Label> { Line1, Line2, Line3, Line4, Line5, Line6, Line7, Line8, Line9, Line10 });
        }

        private uint GetCount(IList<int> array, int index1, int index2)
        {
            uint counter = 0;
            foreach (int item in array.Where(x => (x > index1) && (x < index2)))
            {
                counter++;
            }
            return counter;
        }

        private void UpdateCounter()
        {
            try
            {
                int index1 = int.Parse(textBoxRange1.Text);
                int index2 = int.Parse(textBoxRange2.Text);
                if (index1 < index2)
                    labelRange.Text = GetCount(_array, index1, index2).ToString();
                else
                    labelRange.Text = GetCount(_array, index2, index1).ToString();
            }
            catch
            {
                labelRange.Text = @"Ошибка";
            }
        }

        private void UpdateArray()
        {
            int text;
            if (int.TryParse(textBoxCount.Text, out text) && (text < 26) && (text > -1))
            {
                this._array = Program.InitArray(_array, text);
                labelArray.Text = "";
                foreach (var item in _array)
                {
                    labelArray.Text += item + @" ";
                }
            }
            else
            {
                labelArray.Text = text > 25 ? (@"Слишком много элементов") : (@"Ошибка");
            }
            UpdateCounter();
        }

        private void UpdateMatrix()
        {
            int text1;
            int text2;

            if (int.TryParse(textBoxSize1.Text, out text1) & int.TryParse(textBoxSize2.Text, out text2) && (text1 > -1) && (text2 > -1) && (text1 < 11) && (text2 < 11))
            {
                _matrix = Program.InitMatrix(_matrix, text1, text2);
                for (int i = 0; i < 10; i++)
                {
                    Lines[i].Text = "";

                    if (i < text1) for (int j = 0; j < text2; j++)
                        {
                            Lines[i].Text += _matrix[i, j] + @"  ";
                        }
                }
            }
            else
            {
                foreach (var line in Lines)
                {
                    line.Text = "";
                }
                Line1.Text = (text1 > 10) || (text2 > 10) ? (@"Слишком много элементов") : (@"Ошибка");
            }

            UpdateMatrixSumm();
        }

        private void UpdateMatrixSumm()
        {
            double min;
            int m = _matrix.Length / _matrix.GetLength(0);
            int n = _matrix.GetLength(0);
            double[] res = new double[m];

            try
            {
                for (int j = 0; j < m; j++)
                {
                    min = _matrix[0, j];
                    for (int i = 0; i < n; i++)
                    {
                        if (_matrix[i, j] < min)
                        {
                            min = _matrix[i, j];
                        }
                        res[j] = min;
                    }
                }
                labelSum.Text = res.Sum().ToString();
            }
            catch
            {
                labelSum.Text = @"Ошибка";
            }
        }

        private void textBoxCount_TextChanged(object sender, EventArgs e)
        {
            UpdateArray();
        }

        private void buttonFill_Click(object sender, EventArgs e)
        {
            Program.FillRandom(_array);
            UpdateArray();
        }

        private void textBoxRange1_TextChanged(object sender, EventArgs e)
        {
            UpdateCounter();
        }

        private void textBoxRange2_TextChanged_1(object sender, EventArgs e)
        {
            UpdateCounter();
        }

        private void textBoxRangeMatrix2_TextChanged(object sender, EventArgs e)
        {
            UpdateMatrix();
        }

        private void textBoxRangeMatrix1_TextChanged(object sender, EventArgs e)
        {
            UpdateMatrix();
        }

        private void buttonFillMatrix_Click(object sender, EventArgs e)
        {
            Program.FillMatrixRandom(_matrix);
            UpdateMatrix();
        }

    }
}
