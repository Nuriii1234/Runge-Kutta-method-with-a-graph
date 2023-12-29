using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Runge_Kutta_method_with_a_graph
{
    public partial class Form1 : Form
    {   /// <summary>
    /// Не знаю...
    /// </summary>
        public Form1()
        {
            InitializeComponent();
        }
        //-----------------------------------------------------------------------------------------
        /// <summary>
        /// При нажатии на кнопку рисуем исходный график
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            double a = 0, b = 1, h = 0.01, x, y;
            x = a;
            while (x <= b)
            {
                y = Original_Function(x);
                this.chart1.Series[0].Points.AddXY(x, y);
                x += h;
            }
        }
        //-----------------------------------------------------------------------------------------
        /// <summary>
        /// При нажатии на кнопку рисуем график, который получился из метода Рунге-Кутта
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            double x = 0;
            double y = 0.541325;
            double h = 0.1;
            double delta_Y;
            while (x < 0.95)
            {
                this.chart1.Series[1].Points.AddXY(x, y);
                var vector_K = Search_vector_K(x, y, h);
                delta_Y = (vector_K[0] + 2 * vector_K[1] + 2 * vector_K[2] + vector_K[3]) / 6;
                y += delta_Y;
                x += h;
            }
        }
        //-----------------------------------------------------------------------------------------
        /// <summary>
        /// Очищаем поле от мусора
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            this.chart1.Series[0].Points.Clear();
            this.chart1.Series[1].Points.Clear();
        }
        //-----------------------------------------------------------------------------------------
        /// <summary>
        /// Метод для нахождения значения функции от двух переменных
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public double Function(double x, double y)
        {
            double F;
            F = Math.Exp(x - y) + Math.Exp(x);
            return F;
        }
        //-----------------------------------------------------------------------------------------
        /// <summary>
        /// Нахождение коэффциентов К для метода Рунге-Кутта
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="h"></param>
        /// <returns></returns>
        public double[] Search_vector_K(double x, double y, double h)
        {
            double[] vector_K = new double[4];
            vector_K[0] = h * Function(x, y);
            vector_K[1] = h * Function(x + 0.5 * h, y + 0.5 * vector_K[0]);
            vector_K[2] = h * Function(x + 0.5 * h, y + 0.5 * vector_K[1]);
            vector_K[3] = h * Function(x + h, y + vector_K[2]);
            return vector_K;
        }
        //-----------------------------------------------------------------------------------------
        /// <summary>
        /// Нахождение у от оригинальной функции
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public double Original_Function(double x)
        {
            double F;
            F = Math.Log(Math.Exp(Math.Exp(x)) - 1);
            return F;
        }        
    }
}
