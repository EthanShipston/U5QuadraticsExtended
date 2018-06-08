/* Ethan Shipston
 * U5QuadraticExtended
 * 5/29/2018
 * The program tells you the roots of a quadratic formula and then draws the parabola
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace U5Quadratic
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int xGridStretch = 10;
        int yGridStretch = 1;
        public MainWindow()
        {
            InitializeComponent();
            //draw grid
            Line xLine = new Line();
            xLine.Stroke = Brushes.Black;
            xLine.X1 = 0;
            xLine.Y1 = canvas.Height / 2;
            xLine.X2 = canvas.Width;
            xLine.Y2 = canvas.Height / 2;
            canvas.Children.Add(xLine);
            Line yLine = new Line();
            yLine.Stroke = Brushes.Black;
            yLine.X1 = canvas.Width / 2;
            yLine.Y1 = 0;
            yLine.X2 = canvas.Width / 2;
            yLine.Y2 = canvas.Height;
            canvas.Children.Add(yLine);
        }

        private void btnRun_Click(object sender, RoutedEventArgs e)
        {
            //get zeros
            txtOutput.Text = "";
            double.TryParse(txtA.Text, out double a);
            txtOutput.Text += "a Value: " + a.ToString() + "\n";
            double.TryParse(txtB.Text, out double b);
            txtOutput.Text += "b Value: " + b.ToString() + "\n";
            double.TryParse(txtC.Text, out double c);
            txtOutput.Text += "c Value: " + c.ToString() + "\n";
            double[] intercepts = new double[2];
            intercepts[0] = ((-1 * b) + Math.Sqrt(Math.Pow(b, 2) - (4 * a * c))) / (2 * a);
            intercepts[1] = ((-1 * b) - Math.Sqrt(Math.Pow(b, 2) - (4 * a * c))) / (2 * a);
            txtOutput.Text += "x Intercept(s): " + intercepts[0] + " and " + intercepts[1];

            //draw intercepts
            Ellipse intercept1 = new Ellipse();
            intercept1.Height = 5;
            intercept1.Width = 5;
            intercept1.Stroke = Brushes.Red;
            intercept1.StrokeThickness = 5;
            intercept1.Margin = new Thickness(((canvas.Width / 2) + (intercepts[0] * xGridStretch) - (intercept1.Width / 2)), ((canvas.Height / 2) - 2.5), 0, 0);
            canvas.Children.Add(intercept1);
            Ellipse intercept2 = new Ellipse();
            intercept2.Height = 5;
            intercept2.Width = 5;
            intercept2.Stroke = Brushes.Red;
            intercept2.StrokeThickness = 5;
            intercept2.Margin = new Thickness(((canvas.Width / 2) + (intercepts[1] * xGridStretch) - (intercept2.Width / 2)), ((canvas.Height / 2) - 2.5), 0, 0);
            canvas.Children.Add(intercept2);

            //draw parabola
            double xVertex = (intercepts[0] + intercepts[1]) / 2;
            double yVertex = a * Math.Pow(xVertex, 2) + b * xVertex + c;
            Point vertex = new Point(xVertex, yVertex);
            Point zero1 = new Point(((canvas.Width / 2) + (intercepts[0] * xGridStretch) - (intercept1.Width / 2)), 0);
            Point zero2 = new Point(((canvas.Width / 2) + (intercepts[1] * xGridStretch) - (intercept2.Width / 2)), 0);

            for (int i = 0; i <= b; i++)
            {
                bool correctValues = false;
                double temp = b / i;
                if (temp + i == c)
                {
                    correctValues = true;
                }
                if ((-1 * temp) + i == c)
                {
                    correctValues = true;
                }
                if (temp + (-1 * i) == c)
                {
                    correctValues = true;
                }
                if (correctValues = true)
                {
                    MessageBox.Show(temp.ToString() + " and " + i);
                }
            }

            if (a > 0)
            {
                if (vertex.Y < 0)
                {
                    Ellipse parabola = new Ellipse();
                    parabola.Stroke = Brushes.Blue;
                    parabola.StrokeThickness = 2;
                    parabola.Height = canvas.Height + (Math.Abs(c) * yGridStretch);
                    parabola.Width = Math.Abs(Math.Abs(zero2.X) - Math.Abs(zero1.X)) * xGridStretch;
                    MessageBox.Show(parabola.Width.ToString());
                    parabola.Margin = new Thickness(((canvas.Width / 2) - (parabola.Width / 2)) + vertex.X * xGridStretch, -(((canvas.Height / 2) + vertex.Y) + Math.Abs(c) * yGridStretch), 0, 0);
                    canvas.Children.Add(parabola);
                }
            }
        }
    }
}
//
